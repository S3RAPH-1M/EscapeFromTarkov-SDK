using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "TagBank", menuName = "ScriptableObjects/TarkovCustomVoices/TagBank", order = 1)]
public class TagBank : ScriptableObject
{
	// Token: 0x060033AA RID: 13226 RVA: 0x000E6588 File Offset: 0x000E4788
	public TaggedClip Match(ETagStatus combat = ETagStatus.Unaware | ETagStatus.Aware | ETagStatus.Combat, ETagStatus speakerGroup = ETagStatus.Solo | ETagStatus.Coop, ETagStatus targetGroup = ETagStatus.TargetSolo | ETagStatus.TargetMultiple, ETagStatus health = ETagStatus.Healthy | ETagStatus.Injured | ETagStatus.BadlyInjured | ETagStatus.Dying, ETagStatus side = ETagStatus.Bear | ETagStatus.Usec | ETagStatus.Scav, ETagStatus exUsecBoss = ETagStatus.Birdeye | ETagStatus.Knight | ETagStatus.BigPipe)
	{
		return this.Match((int)(combat | speakerGroup | targetGroup | health | side | exUsecBoss));
	}

	// Token: 0x060033AB RID: 13227 RVA: 0x000E65A0 File Offset: 0x000E47A0
	public TaggedClip Match(int mask)
	{
		if (this.list_1 == null)
		{
			this.list_1 = new List<TaggedClip>(this.Clips.Length);
			this.list_0 = new List<TaggedClip>(this.Clips.Length);
		}
		else
		{
			this.list_1.Clear();
			this.list_0.Clear();
		}
		List<TaggedClip> list = this.list_1;
		List<TaggedClip> list2 = this.list_0;
		for (int i = 0; i < this.Clips.Length; i++)
		{
			TaggedClip taggedClip = this.Clips[i];
			if (this.IgnoreTags || TagBank.Compare((int)taggedClip.Mask, mask))
			{
				if (taggedClip.Exclude)
				{
					list2.Add(taggedClip);
				}
				else
				{
					list.Add(taggedClip);
				}
			}
		}
		if (list.Count == 1)
		{
			for (int j = 0; j < list2.Count; j++)
			{
				list2[j].Exclude = false;
			}
		}
		else if (list.Count == 0)
		{
			for (int k = 0; k < list2.Count; k++)
			{
				list2[k].Exclude = false;
			}
			list = list2;
		}
		if (list.Count == 0)
		{
			return null;
		}
		int num = global::UnityEngine.Random.Range(0, list.Count);
		TaggedClip taggedClip2 = list[num];
		taggedClip2.Exclude = true;
		this.list_0.Clear();
		this.list_1.Clear();
		return taggedClip2;
	}

	// Token: 0x060033AC RID: 13228 RVA: 0x000E66E8 File Offset: 0x000E48E8
	public void OnValidate()
	{
		this.Clips = this.SpreadGroups.SelectMany(new Func<SpreadGroup, IEnumerable<TaggedClip>>(TagBank.Class389.class389_0.method_0)).ToArray<TaggedClip>();
		for (int i = 0; i < this.Clips.Length; i++)
		{
			this.Clips[i].NetId = i;
			if (this.Clips[i].Clip != null)
			{
				this.Clips[i].Length = this.Clips[i].Clip.length;
			}
		}
	}

	// Token: 0x060033AD RID: 13229 RVA: 0x000E6780 File Offset: 0x000E4980
	public static bool Compare(int mask1, int @event)
	{
		int num = 0;
		for (int i = 0; i < TagBank.Sizes.Length; i++)
		{
			int num2 = TagBank.Sizes[i];
			if (i > 0)
			{
				num += TagBank.Sizes[i - 1];
			}
			int bits = TagBank.GetBits(mask1, num, num2);
			int bits2 = TagBank.GetBits(@event, num, num2);
			if (bits != 0 && bits2 != 0 && (bits & bits2) == 0)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060033AE RID: 13230 RVA: 0x000E67DC File Offset: 0x000E49DC
	public static int GetBits(int mask, int offset, int width)
	{
		return ((1 << width) - 1 << offset) & mask;
	}

	// Token: 0x04002B5D RID: 11101
	public EPhraseTrigger Trigger;

	// Token: 0x04002B5E RID: 11102
	public SpreadGroup[] SpreadGroups = Array.Empty<SpreadGroup>();

	// Token: 0x04002B5F RID: 11103
	public TaggedClip[] Clips;

	// Token: 0x04002B60 RID: 11104
	public Chain ChainEvent;

	// Token: 0x04002B61 RID: 11105
	public static int[] Sizes = new int[] { 3, 2, 3, 2, 4, 3 };

	// Token: 0x04002B62 RID: 11106
	public int Importance;

	// Token: 0x04002B63 RID: 11107
	public float Blocker;

	// Token: 0x04002B64 RID: 11108
	public bool IgnoreTags;

	// Token: 0x04002B65 RID: 11109
	private List<TaggedClip> list_0;

	// Token: 0x04002B66 RID: 11110
	private List<TaggedClip> list_1;

	// Token: 0x02000772 RID: 1906
	[CompilerGenerated]
	[Serializable]
	public class Class389
	{
		// Token: 0x060033B3 RID: 13235 RVA: 0x000E6824 File Offset: 0x000E4A24
		public IEnumerable<TaggedClip> method_0(SpreadGroup g)
		{
			return g.Clips;
		}

		// Token: 0x04002B67 RID: 11111
		public static readonly TagBank.Class389 class389_0 = new TagBank.Class389();

		// Token: 0x04002B68 RID: 11112
		public static Func<SpreadGroup, IEnumerable<TaggedClip>> func_0;
	}
}
