using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace EFT.Game.Spawning
{
	// Token: 0x02001BB9 RID: 7097
	[ExecuteInEditMode]
	public sealed class SpawnPointMarker : MonoBehaviour
	{
		public Vector3 Position
		{
			get
			{
				return base.transform.position;
			}
		}
		
		public ISpawnPoint SpawnPoint
		{
			get
			{
				return this._spawnPoint;
			}
		}

		private void UpdateSerializedFields()
		{
			if (transform.hasChanged)
			{
				_spawnPoint.Position = transform.position;
				_spawnPoint.Rotation = transform.rotation;
			}

			_spawnPoint.Name = gameObject.name;
		}

		public void OnDrawGizmos()
		{
			UpdateSerializedFields();
			if (GClass728.SpawnCategoryMask == ESpawnCategoryMask.None)
			{
				return;
			}
			bool flag = (this._spawnPoint.Categories & GClass728.SpawnCategoryMask) != ESpawnCategoryMask.None;
			EPlayerSideMask eplayerSideMask = this._spawnPoint.Sides & GClass728.PlayerSideMask;
			if (flag && eplayerSideMask != EPlayerSideMask.None)
			{
				this.method_0();
			}
		}

		// Token: 0x0600BF09 RID: 48905 RVA: 0x0032C5B4 File Offset: 0x0032A7B4
		public void OnDrawGizmosSelected()
		{
			if (GClass728.SpawnCategoryMask == ESpawnCategoryMask.None)
			{
				this.method_0();
			}
			RaycastHit raycastHit;
			if (Physics.Raycast(base.transform.position, Vector3.down, out raycastHit, 50f))
			{
				Gizmos.DrawLine(base.transform.position, raycastHit.point);
			}
			this.method_1();
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawLine(Vector3.zero, Vector3.zero + Vector3.forward * 2f * 0.3f);
			Gizmos.DrawLine(Vector3.zero + Vector3.forward * 2f * 0.3f, Vector3.zero + (Vector3.forward * 1.5f * 0.3f + Vector3.left * 0.5f * 0.3f));
			Gizmos.DrawLine(Vector3.zero + Vector3.forward * 2f * 0.3f, Vector3.zero + (Vector3.forward * 1.5f * 0.3f + Vector3.right * 0.5f * 0.3f));
			Gizmos.color = this.Color;
			float d = 0.5f;
			Gizmos.DrawCube(Vector3.zero + Vector3.up * 2f, (Vector3.forward + Vector3.right) * d);
			Gizmos.DrawCube(Vector3.zero, (Vector3.forward + Vector3.right) * d);
			Vector3 a = (Vector3.forward + Vector3.right) * d * 0.5f;
			Vector3 a2 = (Vector3.forward + Vector3.left) * d * 0.5f;
			Vector3 a3 = (Vector3.back + Vector3.right) * d * 0.5f;
			Vector3 a4 = (Vector3.back + Vector3.left) * d * 0.5f;
			Vector3 b = Vector3.up * 2f;
			Vector3 b2 = Vector3.down * 0f;
			Gizmos.DrawLine(a + b, a + b2);
			Gizmos.DrawLine(a2 + b, a2 + b2);
			Gizmos.DrawLine(a3 + b, a3 + b2);
			Gizmos.DrawLine(a4 + b, a4 + b2);
		}

		// Token: 0x0600BF0A RID: 48906 RVA: 0x0032C878 File Offset: 0x0032AA78
		private void method_0()
		{
			if (Application.isPlaying)
			{
				return;
			}
			switch (this.SpawnPoint.Sides)
			{
			case EPlayerSideMask.None:
				Gizmos.color = new Color(0f, 0f, 0f, 0.5f);
				goto IL_DD;
			case EPlayerSideMask.Usec:
				Gizmos.color = new Color(0.2f, 0.4f, 0.9f, 0.5f);
				goto IL_DD;
			case EPlayerSideMask.Bear:
				Gizmos.color = new Color(0.9f, 0.4f, 0.2f, 0.5f);
				goto IL_DD;
			case EPlayerSideMask.Savage:
				Gizmos.color = new Color(0.4f, 0.9f, 0.2f, 0.5f);
				goto IL_DD;
			case EPlayerSideMask.All:
				goto IL_DD;
			}
			Gizmos.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
			IL_DD:
			GClass773.DrawCube(base.transform.position + Vector3.up * 120f * 0.5f, base.transform.rotation, new Vector3(1f, 120f, 1f));
		}

		// Token: 0x0600BF0B RID: 48907 RVA: 0x0032C9B0 File Offset: 0x0032ABB0
		private void method_1()
		{
			if (!(this._collider == null) && this._collider.enabled)
			{
				Collider collider = this._collider;
				if (collider != null)
				{
					if (collider is BoxCollider)
					{
						return;
					}
					SphereCollider sphereCollider;
					if ((sphereCollider = (collider as SphereCollider)) != null)
					{
						SphereCollider sphereCollider2 = sphereCollider;
						Gizmos.DrawWireSphere(this.SpawnPoint.Position + sphereCollider2.center, sphereCollider2.radius);
					}
				}
				return;
			}
		}
		
		// Token: 0x04008FA9 RID: 36777
		public Color Color = new Color(0f, 1f, 0f, 1f);

		// Token: 0x04008FAA RID: 36778
		[SerializeField]
		private SpawnPoint _spawnPoint;

		// Token: 0x04008FAB RID: 36779
		[SerializeField]
		private Collider _collider;

		// Token: 0x04008FAC RID: 36780
		private string string_0;

	}
}
