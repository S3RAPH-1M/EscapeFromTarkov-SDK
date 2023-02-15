using System;
using System.Globalization;
using System.IO;

namespace AnimationEventSystem
{
	// Token: 0x02000E38 RID: 3640
	[Serializable]
	public sealed class AnimationEventParameter : ICloneable
	{
		// Token: 0x06005716 RID: 22294 RVA: 0x001B0580 File Offset: 0x001AE780
		public object Clone()
		{
			return new AnimationEventParameter
			{
				BoolParam = this.BoolParam,
				FloatParam = this.FloatParam,
				IntParam = this.IntParam,
				StringParam = this.StringParam,
				ParamType = this.ParamType
			};
		}

		// Token: 0x06005717 RID: 22295 RVA: 0x001B05D0 File Offset: 0x001AE7D0
		public void Serialize(BinaryWriter writer)
		{
			writer.Write((short)this.ParamType);
			if (this.ParamType == EAnimationEventParamType.None)
			{
				return;
			}
			writer.Write(this.BoolParam);
			writer.Write(this.FloatParam);
			writer.Write(this.IntParam);
			writer.Write(this.StringParam);
		}

		// Token: 0x06005718 RID: 22296 RVA: 0x001B0624 File Offset: 0x001AE824
		public void Deserialize(BinaryReader reader)
		{
			this.ParamType = (EAnimationEventParamType)reader.ReadInt16();
			if (this.ParamType == EAnimationEventParamType.None)
			{
				return;
			}
			this.BoolParam = reader.ReadBoolean();
			this.FloatParam = reader.ReadSingle();
			this.IntParam = reader.ReadInt32();
			this.StringParam = reader.ReadString();
		}

		// Token: 0x06005719 RID: 22297 RVA: 0x001B0678 File Offset: 0x001AE878
		public override string ToString()
		{
			switch (this.ParamType)
			{
			case EAnimationEventParamType.None:
				return "";
			case EAnimationEventParamType.Int32:
				return this.IntParam.ToString();
			case EAnimationEventParamType.Float:
				return this.FloatParam.ToString(CultureInfo.InvariantCulture);
			case EAnimationEventParamType.String:
				return this.StringParam;
			case EAnimationEventParamType.Boolean:
				return this.BoolParam.ToString();
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x0600571A RID: 22298 RVA: 0x001B06E4 File Offset: 0x001AE8E4
		public object GetParameter()
		{
			switch (this.ParamType)
			{
			case EAnimationEventParamType.Int32:
				return this.IntParam;
			case EAnimationEventParamType.Float:
				return this.FloatParam;
			case EAnimationEventParamType.String:
				return this.StringParam;
			case EAnimationEventParamType.Boolean:
				return this.BoolParam;
			default:
				return null;
			}
		}

		// Token: 0x0600571B RID: 22299 RVA: 0x001B073C File Offset: 0x001AE93C
		public string GetSelectedParameterFieldName()
		{
			switch (this.ParamType)
			{
			case EAnimationEventParamType.Int32:
				return "IntParam";
			case EAnimationEventParamType.Float:
				return "FloatParam";
			case EAnimationEventParamType.String:
				return "StringParam";
			case EAnimationEventParamType.Boolean:
				return "BoolParam";
			default:
				return "";
			}
		}

		// Token: 0x0600571C RID: 22300 RVA: 0x001B0785 File Offset: 0x001AE985
		public override bool Equals(object obj)
		{
			return obj != null && (this == obj || (!(obj.GetType() != base.GetType()) && this.Equals((AnimationEventParameter)obj)));
		}

		// Token: 0x0600571D RID: 22301 RVA: 0x001B07B4 File Offset: 0x001AE9B4
		public override int GetHashCode()
		{
			return (((this.BoolParam.GetHashCode() * 397 ^ this.FloatParam.GetHashCode()) * 397 ^ this.IntParam) * 397 ^ ((this.StringParam != null) ? this.StringParam.GetHashCode() : 0)) * 397 ^ (int)this.ParamType;
		}

		// Token: 0x0600571E RID: 22302 RVA: 0x001B0818 File Offset: 0x001AEA18
		protected bool Equals(AnimationEventParameter other)
		{
			return this.BoolParam == other.BoolParam && this.FloatParam.Equals(other.FloatParam) && this.IntParam == other.IntParam && this.StringParam == other.StringParam && this.ParamType == other.ParamType;
		}

		// Token: 0x0400580F RID: 22543
		public bool BoolParam;

		// Token: 0x04005810 RID: 22544
		public float FloatParam;

		// Token: 0x04005811 RID: 22545
		public int IntParam;

		// Token: 0x04005812 RID: 22546
		public string StringParam;

		// Token: 0x04005813 RID: 22547
		public EAnimationEventParamType ParamType;
	}
}
