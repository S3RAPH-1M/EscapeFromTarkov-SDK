using System;
using System.Collections.Generic;
using UnityEngine;

namespace Diz.Skinning
{
    // Token: 0x020023C5 RID: 9157
    public class Skin : AbstractSkin
    {
        [SerializeField] private Transform _baseTransform;

        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

        // Token: 0x0400BAFA RID: 47866
        [SerializeField] private String[] _bonePaths;

        // Token: 0x0400BAFB RID: 47867
        [SerializeField] private String _rootBonePath;

        [Header("Set this in order to procedurally get all of the bonePaths")]
        [SerializeField]
        private Boolean _toggle;

        // Token: 0x0400BAFC RID: 47868
        private Skeleton skeleton_0;

        private void OnValidate()
        {
            if (this._toggle)
            {
                this._toggle = false;
                if (this._baseTransform != null)
                {
                    this._bonePaths = GetBonePaths(new List<String>(), this._baseTransform).ToArray();
                }
            }
        }

        private static String GetGameObjectPath(Transform transform)
        {
            String path = transform.name;
            while (transform.parent != null)
            {
                transform = transform.parent;
                path = transform.name + "/" + path;
            }

            return path;
        }

        private List<String> GetBonePaths(List<String> list, Transform inputTransform) {
            String transformName = GetGameObjectPath(inputTransform);
            if (!transformName.Contains("HumanRibcage") && transformName.Contains("Spine3/")) {
                transformName = transformName.Replace("HumanSpine3/", "HumanSpine3/Base HumanRibcage/");
            }

            list.Add($"Root_Joint/{transformName}");
            for (Int32 i = 0; i < inputTransform.childCount; i++) {
                this.GetBonePaths(list, inputTransform.GetChild(i));
            }

            return list;
        }
    }
}