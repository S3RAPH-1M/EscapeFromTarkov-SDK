/**
MIT License
Copyright (c) 2024 DrakiaXYZ
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
// I want syntax highlighting...
#if !(UNITY_STANDALONE)
#define VSEDITOR
#endif
#if (UNITY_EDITOR || VSEDITOR)
[ExecuteInEditMode]
public class EFTCleaner : MonoBehaviour
{
    [MenuItem("Custom Windows/DrakiaXYZ/EFT Cleaner/Setup Layers")]
    static void SetupLayers()
    {
        Debug.Log("Adding Layers.");
        Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
        if (asset != null && asset.Length > 0)
        {
            SerializedObject serializedObject = new SerializedObject(asset[0]);
            SerializedProperty layers = serializedObject.FindProperty("layers");
            AddLayerAt(layers, 8, "Player");
            AddLayerAt(layers, 9, "DoorLowPolyCollider");
            AddLayerAt(layers, 10, "PlayerCollisionTest");
            AddLayerAt(layers, 11, "Terrain");
            AddLayerAt(layers, 12, "HighPolyCollidder");
            AddLayerAt(layers, 13, "Triggers");
            AddLayerAt(layers, 14, "DisablerCullingObject");
            AddLayerAt(layers, 15, "Loot");
            AddLayerAt(layers, 16, "HitCollider");
            AddLayerAt(layers, 17, "PlayerRenderers");
            AddLayerAt(layers, 18, "LowPolyCollider");
            AddLayerAt(layers, 19, "Weapon Preview");
            AddLayerAt(layers, 20, "Shells");
            AddLayerAt(layers, 21, "CullingMask");
            AddLayerAt(layers, 22, "Interactive");
            AddLayerAt(layers, 23, "DeadBody");
            AddLayerAt(layers, 24, "Raindrops");
            AddLayerAt(layers, 25, "Menu Environment");
            AddLayerAt(layers, 26, "Foliage");
            AddLayerAt(layers, 27, "PlayerSpiritAura");
            AddLayerAt(layers, 28, "Sky");
            AddLayerAt(layers, 29, "LevelBorder");
            AddLayerAt(layers, 30, "TransparentCollider");
            AddLayerAt(layers, 31, "Grass");
            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
        }
    }
    [MenuItem("Custom Windows/DrakiaXYZ/EFT Cleaner/Show Missing Terrain")]
    static void ShowMissingTerrain()
    {
        Material terrainMaterial = null;
        // Loop through all terrain objects, and find ones where 
        foreach (Terrain terrain in Terrain.activeTerrains)
        {
            // If the terrain is lacking a material, create a new one from the "Nature/Terrain/Standard" shader, and apply it
            if (terrain.materialTemplate == null)
            {
                if (terrainMaterial == null)
                {
                    terrainMaterial = new Material(Shader.Find("Nature/Terrain/Standard"));
                }
                Debug.Log($"Applying terrain material to {terrain.name}");
                terrain.materialTemplate = terrainMaterial;
                EditorUtility.SetDirty(terrain);
            }
        }
    }
    [MenuItem("Custom Windows/DrakiaXYZ/EFT Cleaner/Show Missing Objects")]
    static void ShowMissingObjects()
    {
        int cullingMaskLayer = LayerMask.NameToLayer("CullingMask");
        int highPolyCollidderLayer = LayerMask.NameToLayer("HighPolyCollidder");
        // Loop through all the game objects, find ones where the mesh renderer is disabled, but the game object is active
        GameObject[] gameObjects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        int enabledRenderers = 0;
        int inactiveObjects = 0;
        foreach (GameObject gameObject in gameObjects)
        {
            // Skip inactive objects
            if (!gameObject.activeInHierarchy)
            {
                inactiveObjects++;
                continue;
            }
            // Skip non-cullingMask or default objects
            if (gameObject.layer != cullingMaskLayer && gameObject.layer != highPolyCollidderLayer && gameObject.layer != 0)
            {
                continue;
            }
            // If there's a LOD group, enable it
            LODGroup lodGroup;
            if (gameObject.TryGetComponent<LODGroup>(out lodGroup))
            {
                if (!lodGroup.enabled)
                {
                    lodGroup.enabled = true;
                    EditorUtility.SetDirty(lodGroup);
                }
            }
            // Skip if it has a Box Collider, and its name doesn't contain "LOD"
            BoxCollider boxCollider;
            if (!gameObject.name.Contains("LOD") && gameObject.TryGetComponent<BoxCollider>(out boxCollider))
            {
                continue;
            }
            // Disable if its name is "EFFECT", this seems to be a streets thing, lots of noise
            if (gameObject.name.Contains("EFFECT"))
            {
                if (gameObject.activeSelf)
                {
                    gameObject.SetActive(false);
                    EditorUtility.SetDirty(gameObject);
                }
                continue;
            }
            // Enable the MeshRender if not enabled
            MeshRenderer meshRenderer;
            if (gameObject.TryGetComponent<MeshRenderer>(out meshRenderer) && meshRenderer.sharedMaterial != null)
            {
                // If the name contains "stencil", disable the renderer
                if (gameObject.name.ToLower().Contains("stencil"))
                {
                    disableMeshRenderer(meshRenderer);
                }
                // If the name contains "FogSheet", it's a streets thing, disable it
                else if (gameObject.name.ToLower().Contains("fogsheet"))
                {
                    disableMeshRenderer(meshRenderer);
                }
                // If the material name contains "SHADOW_TRUE", hide it (Shoreline only maybe?)
                else if (meshRenderer.sharedMaterial.name.Contains("SHADOW_TRUE"))
                {
                    disableMeshRenderer(meshRenderer);
                }
                // If the material name contains "Default-Material_EFT", hide it (Shoreline only maybe?)
                else if (meshRenderer.sharedMaterial.name.Contains("Default-Material"))
                {
                    disableMeshRenderer(meshRenderer);
                }
                else if (!meshRenderer.enabled)
                {
                    enabledRenderers++;
                    meshRenderer.enabled = true;
                    EditorUtility.SetDirty(meshRenderer);
                }
            }
        }
        Debug.Log($"Inactive: {inactiveObjects}  Enabled: {enabledRenderers}");
    }
    static void disableMeshRenderer(MeshRenderer meshRenderer)
    {
        if (!meshRenderer.enabled)
        {
            EditorUtility.SetDirty(meshRenderer);
            meshRenderer.enabled = false;
        }
    }
    static void AddLayerAt(SerializedProperty layers, int index, string layerName, bool tryOtherIndex = true)
    {
        // Skip if a layer with the name already exists.
        for (int i = 0; i < layers.arraySize; ++i)
        {
            if (layers.GetArrayElementAtIndex(i).stringValue == layerName)
            {
                Debug.Log("Skipping layer '" + layerName + "' because it already exists.");
                return;
            }
        }
        // Extend layers if necessary
        if (index >= layers.arraySize)
        {
            layers.arraySize = index + 1;
        }
        // set layer name at index
        var element = layers.GetArrayElementAtIndex(index);
        if (string.IsNullOrEmpty(element.stringValue))
        {
            element.stringValue = layerName;
            Debug.Log($"Added layer '{layerName}' at index {index}");
        }
        else
        {
            element.stringValue = layerName;
            Debug.Log($"Set layer '{layerName}' at index {index}");
        }
    }
}
#endif