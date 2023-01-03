using System.Collections.Generic;
using UnityEngine;

namespace Diz.Skinning
{
    public class Skin : AbstractSkin
    {
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

        [SerializeField] private string[] _bonePaths;

        [SerializeField] private string _rootBonePath;

#if UNITY_EDITOR
        [ContextMenu("Procedurally get all bone paths")]
        private void HydrateBonePaths()
        {
            _bonePaths = GetBonePaths(new List<string>(), _skinnedMeshRenderer.bones).ToArray();
        }

        private List<string> GetBonePaths(List<string> list, Transform[] bonesTransforms)
        {
            var rootTransform = UnityEditor.Experimental.SceneManagement.PrefabStageUtility.GetPrefabStage(gameObject)
                .prefabContentsRoot.transform;
            
            foreach (var t in bonesTransforms)
            {
                var bonePath = t.name;
                var parent = t.parent;
                while (parent != rootTransform)
                {
                    var parentName = parent.name;

                    bonePath = parentName + "/" + bonePath;
                    parent = parent.parent;
                }

                if (bonePath.Contains("Root_Joint"))
                {
                    list.Add(bonePath.Replace("Skeleton/", ""));
                }
                else
                {
                    list.Add(bonePath.Replace("Skeleton", "Root_Joint"));
                }
            }

            _rootBonePath = list[0];
            return list;
        }
#endif
    }
}