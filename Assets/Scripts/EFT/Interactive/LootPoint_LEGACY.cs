using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EFT.Interactive
{
	public sealed class LootPoint_LEGACY : MonoBehaviour
	{
		[Serializable]
		public sealed class WeightedSpawnPosition
		{
			public Transform Transform;

			public float Weight;
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class Class2596
		{
			public static readonly Class2596 class2596_0 = new Class2596();

			public static Func<WeightedSpawnPosition, WeightedLootPointSpawnPosition> func_0;

			internal WeightedLootPointSpawnPosition method_0(WeightedSpawnPosition x)
			{
				return new WeightedLootPointSpawnPosition(x.Transform.position, x.Transform.rotation.eulerAngles, x.Weight, x.Transform.name);
			}
		}

		[SerializeField]
		private List<WeightedSpawnPosition> _groupPositions = new List<WeightedSpawnPosition>();

		public LootPointParameters Settings;

		public List<WeightedSpawnPosition> GroupPositions => _groupPositions;

		private void OnValidate()
		{
			Debug.LogError("Legacy LootPoints must be converted!");
		}

		public void Convert()
		{
			Debug.Log("Converting point " + base.gameObject.name + "...");
			LootPoint lootPoint = base.gameObject.AddComponent<LootPoint>();
			LootPointParameters parameters = AsLootPointParameters();
			lootPoint.ApplyLootPointParameters(parameters);
			foreach (WeightedSpawnPosition groupPosition in GroupPositions)
			{
				UnityEngine.Object.DestroyImmediate(groupPosition.Transform.gameObject);
			}
			UnityEngine.Object.DestroyImmediate(this);
			Debug.Log("Done");
		}

		public LootPointParameters AsLootPointParameters()
		{
			Settings.Position = ClassVector3.FromUnityVector3(base.transform.position);
			Settings.Rotation = ClassVector3.FromUnityVector3(base.transform.rotation.eulerAngles);
			Settings.FilterInclusive = Settings.FilterInclusive.Except(new string[2] { "57347cf924597744902c94a2", "55801d994bdc2dac148b458c" }).ToArray();
			Settings.GroupPositions = _groupPositions.Select((WeightedSpawnPosition x) => new WeightedLootPointSpawnPosition(x.Transform.position, x.Transform.rotation.eulerAngles, x.Weight, x.Transform.name)).ToArray();
			return Settings;
		}
	}
}
