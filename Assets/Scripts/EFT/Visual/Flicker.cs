using UnityEngine;

namespace EFT.Visual
{
	[ExecuteInEditMode]
	public class Flicker : MonoBehaviour
	{
		protected enum ECurveType
		{
			SelectTypeForGenerate = 0,
			Random = 1,
			Sin = 2,
			Triangle = 3,
			Saw = 4,
			Square = 5
		}

		[SerializeField]
		protected float Frequency = 1f;

		[SerializeField]
		protected float Intensity = 1f;

		[SerializeField]
		protected float IntensityShift;

		[SerializeField]
		protected float TimeShift;

		[SerializeField]
		protected AnimationCurve Curve;

		[SerializeField]
		protected ECurveType Generate;

		[SerializeField]
		protected bool RandomTimeShift;

		[SerializeField]
		protected bool FullRandomCurve;

		public float CullingCoef = 1f;

		protected float RandomSeed;

		protected virtual void Awake()
		{
			if (RandomTimeShift)
			{
				TimeShift = Random.value * 300f;
			}
			RandomSeed = Random.value * 10f;
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		public void SetCurve(AnimationCurve curve)
		{
			Curve = curve;
		}

		public virtual void ManualUpdate()
		{
		}
	}
}
