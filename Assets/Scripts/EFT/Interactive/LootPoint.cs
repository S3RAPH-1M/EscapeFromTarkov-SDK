using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using JsonType;
using UnityEngine;

namespace EFT.Interactive
{
	[RequireComponent(typeof(LootPointViewer))]
	[DisallowMultipleComponent]
	public sealed class LootPoint : MonoBehaviour
	{

		public LootPointMode Mode;

		public bool Enabled = true;

		public bool UseGravity = true;

		public bool RandomRotation = true;

		public float ChanceModifier;

		public bool IsAlwaysSpawn;

		public ELootRarity Rarity;

		[SerializeField]
		private List<string> _lootSets = new List<string>();

		[SerializeField]
		private string[] _filterInclusive = Array.Empty<string>();

		[SerializeField]
		private List<GroupLootPoint> _groupPositions = new List<GroupLootPoint>();

		public List<GroupLootPoint> GroupPositions => _groupPositions;

		public bool IsGroupPosition => _groupPositions.Count > 0;

		public LootPointParameters AsLootPointParameters()
		{
			LootPointParameters lootPointParameters = new LootPointParameters
			{
				Id = method_1(),
				Enabled = Enabled,
				useGravity = UseGravity,
				randomRotation = RandomRotation,
				ChanceModifier = ChanceModifier,
				IsAlwaysSpawn = IsAlwaysSpawn,
				Rarity = Rarity,
				LootSets = ((Mode == LootPointMode.LootSets) ? _lootSets.ToArray() : null),
				FilterInclusive = ((Mode == LootPointMode.Filters) ? _filterInclusive : null),
				Position = ClassVector3.FromUnityVector3(base.transform.position),
				Rotation = ClassVector3.FromUnityVector3(base.transform.rotation.eulerAngles),
				GroupPositions = (IsGroupPosition ? _groupPositions.Select((GroupLootPoint position) => position.AsWeightedLootPointSpawnPosition()).ToArray() : null),
				IsStatic = false,
				IsContainer = false
			};
			if (lootPointParameters.FilterInclusive != null)
			{
				lootPointParameters.FilterInclusive = lootPointParameters.FilterInclusive.Except(new string[2] { "57347cf924597744902c94a2", "55801d994bdc2dac148b458c" }).ToArray();
			}
			return lootPointParameters;
		}

		public void ApplyLootPointParameters(LootPointParameters parameters)
		{
			Enabled = parameters.Enabled;
			UseGravity = parameters.useGravity;
			RandomRotation = parameters.randomRotation;
			ChanceModifier = parameters.ChanceModifier;
			Rarity = parameters.Rarity;
			_lootSets = parameters.LootSets?.ToList();
			_filterInclusive = parameters.FilterInclusive?.ToArray();
			Mode = ((parameters.LootSets == null || parameters.LootSets.Length == 0) ? LootPointMode.Filters : LootPointMode.LootSets);
			base.transform.position = parameters.Position.ToUnityVector3();
			base.transform.rotation = Quaternion.Euler(parameters.Rotation.ToUnityVector3());
			if (parameters.GroupPositions != null)
			{
				WeightedLootPointSpawnPosition[] groupPositions = parameters.GroupPositions;
				foreach (WeightedLootPointSpawnPosition parameters2 in groupPositions)
				{
					method_0().ApplyParameters(parameters2);
				}
			}
			method_2();
		}

		public bool IsLootSetSelected(string id)
		{
			return _lootSets.Contains(id);
		}

		public void AddLootSet(string id)
		{
			if (!_lootSets.Contains(id))
			{
				_lootSets.Add(id);
				method_2();
			}
		}

		public void RemoveLootSet(string id)
		{
			_lootSets.Remove(id);
			method_2();
		}

		public void ClearLootSets()
		{
			_lootSets.Clear();
			method_2();
		}

		public void SetSelectedFilters(string[] selectedFilters)
		{
			_filterInclusive = selectedFilters;
			method_2();
		}

		public void AddGroupPoint()
		{
			GroupLootPoint groupLootPoint = method_0();
			groupLootPoint.Weight = 1f;
			_groupPositions.Add(groupLootPoint);
		}

		private GroupLootPoint method_0()
		{
			GameObject obj = new GameObject($"groupPoint[{_groupPositions.Count}]");
			obj.transform.parent = base.transform;
			obj.transform.localPosition = Vector3.zero;
			return obj.AddComponent<GroupLootPoint>();
		}

		public void RemoveGroupPoint(GroupLootPoint point)
		{
			_groupPositions.Remove(point);
			UnityEngine.Object.DestroyImmediate(point.gameObject);
		}

		public void RandomizeRotation()
		{
			int num = UnityEngine.Random.Range(0, 360);
			base.transform.rotation = Quaternion.Euler(new Vector3(0f, num, 0f));
		}

		private string method_1()
		{
			return base.gameObject.name + base.gameObject.GetHashCode();
		}

		private void method_2()
		{
		}

		private void OnDrawGizmos()
		{
			foreach (GroupLootPoint groupPosition in _groupPositions)
			{
				Color color = Gizmos.color;
				Gizmos.color = Color.magenta;
				Vector3 position = groupPosition.transform.position;
				Gizmos.DrawWireCube(position, Vector3.one / 3f);
				Gizmos.DrawLine(base.transform.position, position);
				Gizmos.color = color;
			}
		}
	}
}
