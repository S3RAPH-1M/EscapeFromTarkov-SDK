using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace AnimationEventSystem
{
	// Token: 0x02000E35 RID: 3637
	[Serializable]
	public sealed class AnimationEvent : ICloneable
	{
		// Token: 0x17000B40 RID: 2880
		// (get) Token: 0x06005707 RID: 22279 RVA: 0x001B01A2 File Offset: 0x001AE3A2
		// (set) Token: 0x06005708 RID: 22280 RVA: 0x001B01AA File Offset: 0x001AE3AA
		public string FunctionName
		{
			get
			{
				return this._functionName;
			}
			set
			{
				this._functionName = value;
				this._functionNameHash = (string.IsNullOrEmpty(this._functionName) ? 0 : this._functionName.GetHashCode());
			}
		}

		// Token: 0x17000B41 RID: 2881
		// (get) Token: 0x06005709 RID: 22281 RVA: 0x001B01D4 File Offset: 0x001AE3D4
		public int FunctionNameHash
		{
			get
			{
				return this._functionNameHash;
			}
		}

		// Token: 0x17000B42 RID: 2882
		// (get) Token: 0x0600570A RID: 22282 RVA: 0x001B01DC File Offset: 0x001AE3DC
		// (set) Token: 0x0600570B RID: 22283 RVA: 0x001B01E4 File Offset: 0x001AE3E4
		public float Time
		{
			get
			{
				return this._time;
			}
			set
			{
				this._time = Mathf.Clamp(value, 0f, 1f);
			}
		}

		// Token: 0x0600570C RID: 22284 RVA: 0x001B01FC File Offset: 0x001AE3FC
		public AnimationEvent()
		{
			this.Parameter = new AnimationEventParameter
			{
				ParamType = EAnimationEventParamType.None
			};
		}

		// Token: 0x0600570D RID: 22285 RVA: 0x001B021D File Offset: 0x001AE41D
		public bool IsTimeToFire(float previousNormalizedTime, float normalizedTime)
		{
			return this._time >= previousNormalizedTime && this._time < normalizedTime;
		}

		// Token: 0x0600570E RID: 22286 RVA: 0x001B0234 File Offset: 0x001AE434
		public bool IsConditionsSucceed(Animator animator)
		{
			if (!this.Enabled)
			{
				return false;
			}
			if (this.EventConditions == null)
			{
				return true;
			}
			for (int i = 0; i < this.EventConditions.Count; i++)
			{
				if (!this.EventConditions[i].IsSucceed(animator))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600570F RID: 22287 RVA: 0x001B0284 File Offset: 0x001AE484
		public object Clone()
		{
			AnimationEvent animationEvent = new AnimationEvent
			{
				Parameter = (AnimationEventParameter)this.Parameter.Clone(),
				Enabled = this.Enabled,
				_functionName = this._functionName,
				_functionNameHash = this._functionNameHash,
				_time = this._time
			};
			if (this.EventConditions != null)
			{
				animationEvent.EventConditions = new List<EventCondition>();
				for (int i = 0; i < this.EventConditions.Count; i++)
				{
					animationEvent.EventConditions.Add((EventCondition)this.EventConditions[i].Clone());
				}
			}
			return animationEvent;
		}

		// Token: 0x06005710 RID: 22288 RVA: 0x001B0328 File Offset: 0x001AE528
		public void Serialize(BinaryWriter writer)
		{
			this.Parameter.Serialize(writer);
			writer.Write(this.Enabled);
			writer.Write(this._functionName);
			writer.Write(this._functionNameHash);
			writer.Write(this._time);
			if (this.EventConditions == null)
			{
				writer.Write(0);
				return;
			}
			writer.Write((short)this.EventConditions.Count);
			for (int i = 0; i < this.EventConditions.Count; i++)
			{
				this.EventConditions[i].Serialize(writer);
			}
		}

		// Token: 0x06005711 RID: 22289 RVA: 0x001B03BC File Offset: 0x001AE5BC
		public void Deserialize(BinaryReader reader)
		{
			this.Parameter.Deserialize(reader);
			this.Enabled = reader.ReadBoolean();
			this._functionName = reader.ReadString();
			this._functionNameHash = reader.ReadInt32();
			this._time = reader.ReadSingle();
			short num = reader.ReadInt16();
			if (num == 0)
			{
				this.EventConditions = null;
				return;
			}
			this.EventConditions = new List<EventCondition>((int)num);
			for (int i = 0; i < (int)num; i++)
			{
				EventCondition eventCondition = new EventCondition();
				eventCondition.Deserialize(reader);
				this.EventConditions.Add(eventCondition);
			}
		}

		// Token: 0x06005712 RID: 22290 RVA: 0x001B0448 File Offset: 0x001AE648
		public override string ToString()
		{
			return string.Format("{0}({1}) : {2} | {3}", new object[]
			{
				this.FunctionName,
				this.Parameter,
				this.Time,
				this.FunctionNameHash
			});
		}

		// Token: 0x06005713 RID: 22291 RVA: 0x001B0488 File Offset: 0x001AE688
		public override bool Equals(object obj)
		{
			return obj != null && (this == obj || (!(obj.GetType() != base.GetType()) && this.Equals((AnimationEvent)obj)));
		}

		// Token: 0x06005714 RID: 22292 RVA: 0x001B04B8 File Offset: 0x001AE6B8
		protected bool Equals(AnimationEvent other)
		{
			return this.EventConditions == null == (other.EventConditions == null) && (this.EventConditions == null || this.EventConditions.SequenceEqual(other.EventConditions)) && (object.Equals(this.Parameter, other.Parameter) && this._functionName == other._functionName && this._functionNameHash == other._functionNameHash && this.Enabled == other.Enabled) && this._time.Equals(other._time);
		}

		// Token: 0x04005802 RID: 22530
		public const float MAX_EVENT_TIME = 1f;

		// Token: 0x04005803 RID: 22531
		public AnimationEventParameter Parameter;

		// Token: 0x04005804 RID: 22532
		[SerializeField]
		private string _functionName;

		// Token: 0x04005805 RID: 22533
		[SerializeField]
		private int _functionNameHash;

		// Token: 0x04005806 RID: 22534
		public bool Enabled = true;

		// Token: 0x04005807 RID: 22535
		[SerializeField]
		private float _time;

		// Token: 0x04005808 RID: 22536
		public List<EventCondition> EventConditions;
	}
}
