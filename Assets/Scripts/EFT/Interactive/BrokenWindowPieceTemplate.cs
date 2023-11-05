using EFT.Ballistics;
using UnityEngine;

namespace EFT.Interactive
{
	public sealed class BrokenWindowPieceTemplate : MonoBehaviour
	{
		[SerializeField]
		private MeshFilter _meshFilter;

		[SerializeField]
		private MeshRenderer _meshRenderer;

		[SerializeField]
		private MeshCollider _meshCollider;

		[SerializeField]
		private BallisticCollider _ballisticCollider;

		[SerializeField]
		private GameObject _child;

		[SerializeField]
		private BoxCollider _childBoxCollider;

		[SerializeField]
		private BrokenWindowPieceCollider _childFragileGlassCollider;

	}
}
