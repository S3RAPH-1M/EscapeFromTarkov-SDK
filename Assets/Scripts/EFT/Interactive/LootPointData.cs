using System;
using UnityEngine;
using System.Collections.Generic;


namespace EFT.Interactive
{
    public class LootPointData : MonoBehaviour
    {
        [Serializable]
        public class TemplateData
        {
            public string Id;
            public bool IsContainer;
            public bool useGravity;
            public bool randomRotation;
            public bool IsGroupPosition;
            public bool IsAlwaysSpawn;
            [HideInInspector]
            public string Root;
            public List<ItemDistributionData> ItemDistribution;
        }

        [Serializable]
        public class ItemDistributionData
        {
            [HideInInspector]
            public string _id;
            public string _tpl;
            public float relativeProbability;
            public int StackObjectsCount;
            public LootType lootType;
        }

        public TemplateData template;

        public enum LootType
        {
            Item,
            AmmoBox
        }
    }
}
