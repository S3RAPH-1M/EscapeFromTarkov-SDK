using UnityEngine;

namespace EFT.Particles
{
	public class BasicParticleSystemMediator : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem[] _particleSystems;

		private int int_0;

		public void Emit(Vector3 position, Quaternion rotation)
		{
			if (_particleSystems.Length != 0)
			{
				ParticleSystem obj = _particleSystems[int_0];
				obj.transform.position = position;
				obj.transform.rotation = rotation;
				obj.Play(withChildren: true);
				int_0 = (int_0 + 1) % _particleSystems.Length;
			}
		}
	}
}
