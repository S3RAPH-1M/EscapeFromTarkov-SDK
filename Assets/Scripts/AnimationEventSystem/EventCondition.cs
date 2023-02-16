using System;
using System.IO;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E49 RID: 3657
	[Serializable]
	public sealed class EventCondition
	{
		// Token: 0x04005847 RID: 22599
		public bool BoolValue;

		// Token: 0x04005848 RID: 22600
		public float FloatValue;

		// Token: 0x04005849 RID: 22601
		public int IntValue;

		// Token: 0x0400584A RID: 22602
		public string ParameterName;

		// Token: 0x0400584B RID: 22603
		private int _cachedNameHash;

		// Token: 0x0400584C RID: 22604
		private EventCondition.EConditionType _conditionMode = EventCondition.EConditionType.None;

		// Token: 0x0400584D RID: 22605
		public EEventConditionParamTypes ConditionParamType;

		// Token: 0x0400584E RID: 22606
		public EEventConditionModes ConditionMode;

		// Token: 0x02000E4A RID: 3658
		// (Invoke) Token: 0x06005773 RID: 22387
		private delegate bool Delegate4(EventCondition condition, Animator animator);

		// Token: 0x02000E4B RID: 3659
		private enum EConditionType
		{
			// Token: 0x04005850 RID: 22608
			None = -1,
			// Token: 0x04005851 RID: 22609
			IntEqual,
			// Token: 0x04005852 RID: 22610
			IntNotEqual,
			// Token: 0x04005853 RID: 22611
			IntGreaterThan,
			// Token: 0x04005854 RID: 22612
			IntLessThan,
			// Token: 0x04005855 RID: 22613
			IntGreaterEqualThan,
			// Token: 0x04005856 RID: 22614
			IntLessEqualThan,
			// Token: 0x04005857 RID: 22615
			FloatGreaterThan,
			// Token: 0x04005858 RID: 22616
			FloatLessThan,
			// Token: 0x04005859 RID: 22617
			BoolEqual,
			// Token: 0x0400585A RID: 22618
			EConditionTypeEnumsCount
		}
	}
}
