using System;
using JsonType;

namespace EFT.Interactive
{
	[Serializable]
	public class LootPointParameters
	{

		public string Id;

		public bool Enabled;

		public bool useGravity = true;

		public bool randomRotation;

		public float ChanceModifier;

		public bool IsAlwaysSpawn;

		public bool isAlwaysTrySpawnLoot;

		public ELootRarity Rarity;


		public string[] LootSets;


		public string[] FilterInclusive;



		public string[] FilterExclusive;

	
		public LootableContainerParameters[] FilterExtended;

		public ClassVector3 Position;

		public ClassVector3 Rotation;


		public WeightedLootPointSpawnPosition[] GroupPositions;

		public bool IsStatic;

		public bool IsContainer;

		public byte SpawnChance;

		public string LootableContainersGroupId;
	}
}
