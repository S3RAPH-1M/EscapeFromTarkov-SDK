using System;
using System.IO;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E49 RID: 3657
	[Serializable]
	public sealed class EventCondition : ICloneable
	{
		// Token: 0x0600575E RID: 22366 RVA: 0x001B165C File Offset: 0x001AF85C
		static EventCondition()
		{
			EventCondition._CONDITION_DELEGATES[0] = new EventCondition.Delegate4(EventCondition.smethod_8);
			EventCondition._CONDITION_DELEGATES[1] = new EventCondition.Delegate4(EventCondition.smethod_7);
			EventCondition._CONDITION_DELEGATES[2] = new EventCondition.Delegate4(EventCondition.smethod_6);
			EventCondition._CONDITION_DELEGATES[3] = new EventCondition.Delegate4(EventCondition.smethod_5);
			EventCondition._CONDITION_DELEGATES[4] = new EventCondition.Delegate4(EventCondition.smethod_4);
			EventCondition._CONDITION_DELEGATES[5] = new EventCondition.Delegate4(EventCondition.smethod_3);
			EventCondition._CONDITION_DELEGATES[6] = new EventCondition.Delegate4(EventCondition.smethod_2);
			EventCondition._CONDITION_DELEGATES[7] = new EventCondition.Delegate4(EventCondition.smethod_1);
			EventCondition._CONDITION_DELEGATES[8] = new EventCondition.Delegate4(EventCondition.smethod_0);
		}

		// Token: 0x0600575F RID: 22367 RVA: 0x001B1720 File Offset: 0x001AF920
		private static bool smethod_0(EventCondition condition, Animator animator)
		{
			return animator.GetBool(condition._cachedNameHash) == condition.BoolValue;
		}

		// Token: 0x06005760 RID: 22368 RVA: 0x001B1736 File Offset: 0x001AF936
		private static bool smethod_1(EventCondition condition, Animator animator)
		{
			return animator.GetFloat(condition._cachedNameHash) < condition.FloatValue;
		}

		// Token: 0x06005761 RID: 22369 RVA: 0x001B174C File Offset: 0x001AF94C
		private static bool smethod_2(EventCondition condition, Animator animator)
		{
			return animator.GetFloat(condition._cachedNameHash) > condition.FloatValue;
		}

		// Token: 0x06005762 RID: 22370 RVA: 0x001B1762 File Offset: 0x001AF962
		private static bool smethod_3(EventCondition condition, Animator animator)
		{
			return animator.GetInteger(condition._cachedNameHash) <= condition.IntValue;
		}

		// Token: 0x06005763 RID: 22371 RVA: 0x001B177B File Offset: 0x001AF97B
		private static bool smethod_4(EventCondition condition, Animator animator)
		{
			return animator.GetInteger(condition._cachedNameHash) >= condition.IntValue;
		}

		// Token: 0x06005764 RID: 22372 RVA: 0x001B1794 File Offset: 0x001AF994
		private static bool smethod_5(EventCondition condition, Animator animator)
		{
			return animator.GetInteger(condition._cachedNameHash) < condition.IntValue;
		}

		// Token: 0x06005765 RID: 22373 RVA: 0x001B17AA File Offset: 0x001AF9AA
		private static bool smethod_6(EventCondition condition, Animator animator)
		{
			return animator.GetInteger(condition._cachedNameHash) > condition.IntValue;
		}

		// Token: 0x06005766 RID: 22374 RVA: 0x001B17C0 File Offset: 0x001AF9C0
		private static bool smethod_7(EventCondition condition, Animator animator)
		{
			return animator.GetInteger(condition._cachedNameHash) != condition.IntValue;
		}

		// Token: 0x06005767 RID: 22375 RVA: 0x001B17D9 File Offset: 0x001AF9D9
		private static bool smethod_8(EventCondition condition, Animator animator)
		{
			return animator.GetInteger(condition._cachedNameHash) == condition.IntValue;
		}

		// Token: 0x06005768 RID: 22376 RVA: 0x001B17EF File Offset: 0x001AF9EF
		public bool IsSucceed(Animator animator)
		{
			if (this._conditionMode == EventCondition.EConditionType.None)
			{
				this._cachedNameHash = Animator.StringToHash(this.ParameterName);
				this.method_0();
			}
			return EventCondition._CONDITION_DELEGATES[(int)this._conditionMode](this, animator);
		}

		// Token: 0x06005769 RID: 22377 RVA: 0x001B1825 File Offset: 0x001AFA25
		public string ToString(Animator animator)
		{
			return string.Format("{0} {1}: {2}", this.ParameterName, this.ConditionMode, this.IsSucceed(animator));
		}

		// Token: 0x0600576A RID: 22378 RVA: 0x001B1850 File Offset: 0x001AFA50
		private void method_0()
		{
			switch (this.ConditionParamType)
			{
			case EEventConditionParamTypes.Int:
				switch (this.ConditionMode)
				{
				case EEventConditionModes.Equal:
					this._conditionMode = EventCondition.EConditionType.IntEqual;
					return;
				case EEventConditionModes.NotEqual:
					this._conditionMode = EventCondition.EConditionType.IntNotEqual;
					return;
				case EEventConditionModes.GreaterThan:
					this._conditionMode = EventCondition.EConditionType.IntGreaterThan;
					return;
				case EEventConditionModes.LessThan:
					this._conditionMode = EventCondition.EConditionType.IntLessThan;
					return;
				case EEventConditionModes.GreaterEqualThan:
					this._conditionMode = EventCondition.EConditionType.IntGreaterEqualThan;
					return;
				case EEventConditionModes.LessEqualThan:
					this._conditionMode = EventCondition.EConditionType.IntLessEqualThan;
					return;
				default:
					return;
				}
				break;
			case EEventConditionParamTypes.Float:
			{
				EEventConditionModes conditionMode = this.ConditionMode;
				if (conditionMode == EEventConditionModes.GreaterThan)
				{
					this._conditionMode = EventCondition.EConditionType.FloatGreaterThan;
					return;
				}
				if (conditionMode != EEventConditionModes.LessThan)
				{
					return;
				}
				this._conditionMode = EventCondition.EConditionType.FloatLessThan;
				return;
			}
			case EEventConditionParamTypes.Boolean:
				this._conditionMode = EventCondition.EConditionType.BoolEqual;
				return;
			default:
				return;
			}
		}

		// Token: 0x0600576B RID: 22379 RVA: 0x001B18F4 File Offset: 0x001AFAF4
		public object Clone()
		{
			return new EventCondition
			{
				BoolValue = this.BoolValue,
				FloatValue = this.FloatValue,
				IntValue = this.IntValue,
				_conditionMode = this._conditionMode,
				_cachedNameHash = this._cachedNameHash,
				ConditionMode = this.ConditionMode,
				ConditionParamType = this.ConditionParamType,
				ParameterName = this.ParameterName
			};
		}

		// Token: 0x0600576C RID: 22380 RVA: 0x001B1968 File Offset: 0x001AFB68
		public void Serialize(BinaryWriter writer)
		{
			writer.Write(this.BoolValue);
			writer.Write(this.FloatValue);
			writer.Write(this.IntValue);
			writer.Write((short)this._conditionMode);
			writer.Write(this._cachedNameHash);
			writer.Write((short)this.ConditionMode);
			writer.Write((short)this.ConditionParamType);
			writer.Write(this.ParameterName);
		}

		// Token: 0x0600576D RID: 22381 RVA: 0x001B19D8 File Offset: 0x001AFBD8
		public void Deserialize(BinaryReader reader)
		{
			this.BoolValue = reader.ReadBoolean();
			this.FloatValue = reader.ReadSingle();
			this.IntValue = reader.ReadInt32();
			this._conditionMode = (EventCondition.EConditionType)reader.ReadInt16();
			this._cachedNameHash = reader.ReadInt32();
			this.ConditionMode = (EEventConditionModes)reader.ReadInt16();
			this.ConditionParamType = (EEventConditionParamTypes)reader.ReadInt16();
			this.ParameterName = reader.ReadString();
		}

		// Token: 0x0600576E RID: 22382 RVA: 0x001B1A45 File Offset: 0x001AFC45
		public override bool Equals(object obj)
		{
			return obj != null && (this == obj || (!(obj.GetType() != base.GetType()) && this.Equals((EventCondition)obj)));
		}

		// Token: 0x0600576F RID: 22383 RVA: 0x001B1A74 File Offset: 0x001AFC74
		public override int GetHashCode()
		{
			return (((((this.BoolValue.GetHashCode() * 397 ^ this.FloatValue.GetHashCode()) * 397 ^ this.IntValue) * 397 ^ ((this.ParameterName != null) ? this.ParameterName.GetHashCode() : 0)) * 397 ^ this._cachedNameHash) * 397 ^ (int)this._conditionMode) * 397 ^ (int)this.ConditionParamType;
		}

		// Token: 0x06005770 RID: 22384 RVA: 0x001B1AF0 File Offset: 0x001AFCF0
		protected bool Equals(EventCondition other)
		{
			return this.BoolValue == other.BoolValue && this.FloatValue.Equals(other.FloatValue) && this.IntValue == other.IntValue && this.ParameterName == other.ParameterName && this._cachedNameHash == other._cachedNameHash && this._conditionMode == other._conditionMode && this.ConditionParamType == other.ConditionParamType && this.ConditionMode == other.ConditionMode;
		}

		// Token: 0x04005846 RID: 22598
		private static readonly EventCondition.Delegate4[] _CONDITION_DELEGATES = new EventCondition.Delegate4[9];

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
