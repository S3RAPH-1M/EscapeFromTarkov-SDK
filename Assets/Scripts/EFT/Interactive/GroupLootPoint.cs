using UnityEngine;

namespace EFT.Interactive
{
	public class GroupLootPoint : MonoBehaviour
	{
		[SerializeField]
		private float _weight;

		public float Weight
		{
			get
			{
				return _weight;
			}
			set
			{
				_weight = value;
				method_0();
			}
		}

		public WeightedLootPointSpawnPosition AsWeightedLootPointSpawnPosition()
		{
			return new WeightedLootPointSpawnPosition
			{
				Name = base.gameObject.name,
				Weight = Weight,
				Position = ClassVector3.FromUnityVector3(base.transform.position),
				Rotation = ClassVector3.FromUnityVector3(base.transform.rotation.eulerAngles)
			};
		}

		private void method_0()
		{
		}

		public void ApplyParameters(WeightedLootPointSpawnPosition parameters)
		{
			_weight = parameters.Weight;
			base.transform.position = parameters.Position.ToUnityVector3();
			base.transform.rotation = Quaternion.Euler(parameters.Rotation.ToUnityVector3());
		}
	}
}
