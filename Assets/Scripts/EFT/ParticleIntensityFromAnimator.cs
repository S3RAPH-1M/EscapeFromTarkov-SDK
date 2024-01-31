using UnityEngine;

namespace EFT
{
	public class ParticleIntensityFromAnimator : MonoBehaviour
	{
		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private ParticleSystem _targetParticle;

		[SerializeField]
		private string _animatorParam;

		[SerializeField]
		private Vector2 _minMaxParamValues;

		[SerializeField]
		private Vector2 _minMaxEmissionValue;

		private float float_0;

		private Vector2 vector2_0;

		private Vector2 vector2_1;

		private float float_1;

		private float float_2;

		private void Awake()
		{
			float_1 = _minMaxParamValues.x;
			float_2 = _minMaxEmissionValue.x;
			vector2_0 = new Vector2(0f, _minMaxParamValues.y - _minMaxParamValues.x);
			vector2_1 = new Vector2(0f, _minMaxEmissionValue.y - _minMaxEmissionValue.x);
		}

		private void Update()
		{
			if (_animator.enabled)
			{
				float_0 = _animator.GetFloat(_animatorParam);
				if (float_0 <= _minMaxParamValues.x)
				{
					_targetParticle.Stop(withChildren: true);
				}
				else if (!_targetParticle.isPlaying)
				{
					_targetParticle.Play(withChildren: true);
				}
			}
		}
	}
}
