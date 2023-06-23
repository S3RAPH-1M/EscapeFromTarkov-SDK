using UnityEngine;

namespace EFT.Interactive
{
	// Token: 0x020021D2 RID: 8658
	public class ExfiltrationPoint : MonoBehaviour
	{
		// Token: 0x0400ABB2 RID: 43954
		public Collider ExtendedCollider;

		// Token: 0x0400ABB3 RID: 43955
		public Switch Switch;

		// Token: 0x0400ABB6 RID: 43958
		[SerializeField]
		private EExfiltrationStatus _status = EExfiltrationStatus.Pending;

		// Token: 0x0400ABBA RID: 43962
		public float ExfiltrationStartTime;

		// Token: 0x0400ABBC RID: 43964
		[SerializeField]
		private GameObject _root;

		// Token: 0x0400ABBE RID: 43966
		public ExitTriggerSettings Settings = new ExitTriggerSettings();

		// Token: 0x0400ABBF RID: 43967
		public ExfiltrationRequirement[] Requirements = new ExfiltrationRequirement[0];
		
		// Token: 0x0400ABC3 RID: 43971
		public string[] EligibleEntryPoints = new string[0];

		// Token: 0x0400ABC4 RID: 43972
		public bool Reusable;
	}
}