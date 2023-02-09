using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EFT;
using UnityEngine;

// Token: 0x02000126 RID: 294
public class GClass256
{
	// Token: 0x170001C6 RID: 454
	// (get) Token: 0x06000729 RID: 1833 RVA: 0x00022FDC File Offset: 0x000211DC
	// (set) Token: 0x0600072A RID: 1834 RVA: 0x00022FE4 File Offset: 0x000211E4
	public int Owner { get; private set; } = -1;

	// Token: 0x170001C7 RID: 455
	// (get) Token: 0x0600072B RID: 1835 RVA: 0x00022FED File Offset: 0x000211ED
	// (set) Token: 0x0600072C RID: 1836 RVA: 0x00022FF5 File Offset: 0x000211F5
	public int PrevOwner { get; private set; }

	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x0600072D RID: 1837 RVA: 0x00023000 File Offset: 0x00021200
	public bool IsFree
	{
		get
		{
			if (this.Neighbourhoods != null)
			{
				for (int i = 0; i < this.Neighbourhoods.Length; i++)
				{
					if (this.Neighbourhoods[i].Owner > 0)
					{
						return false;
					}
				}
			}
			return this.Owner <= 0;
		}
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x00023050 File Offset: 0x00021250
	public GClass256(CoverPointPlaceSerializable data)
	{
		this.Id = data.Id;
		this.Origin = data.Origin;
		this.DefenceInfo = data.DefenceInfo;
		this.DefenceLevel = data.DefenceLevel;
		this.NeighbourhoodsIds = data.NeighbourhoodIds;
		this.CoverType = data.CoverType;
		this.Special = data.Special;
		this.EnvironmentType = data.EnvironmentType;
		this.IdEnvironment = data.IdEnvironment;
	}

	// Token: 0x0600072F RID: 1839 RVA: 0x000230DD File Offset: 0x000212DD
	public bool IsFreeById(int testId)
	{
		return this.Owner <= 0 || testId == this.Owner;
	}

	// Token: 0x06000730 RID: 1840 RVA: 0x000230F3 File Offset: 0x000212F3
	public void SetFree()
	{
		this.Owner = -1;
	}

	// Token: 0x06000732 RID: 1842 RVA: 0x00023118 File Offset: 0x00021318
	public void UpdateCoversFromIds(List<CustomNavigationPoint> allPoints)
	{
		if (this.NeighbourhoodsIds != null && this.NeighbourhoodsIds.Length != 0)
		{
			GClass256[] array = new GClass256[this.NeighbourhoodsIds.Length];
			for (int i = 0; i < this.NeighbourhoodsIds.Length; i++)
			{
				GClass256.Class98 @class = new GClass256.Class98();
				@class.id = this.NeighbourhoodsIds[i];
				CustomNavigationPoint customNavigationPoint = allPoints.FirstOrDefault(new Func<CustomNavigationPoint, bool>(@class.method_0));
				if (customNavigationPoint == null)
				{
					Debug.LogError(string.Concat(new object[]
					{
						"Wrong id for neighbourhood:",
						@class.id,
						"    myIdIs:",
						this.Id
					}));
					return;
				}
				array[i] = customNavigationPoint.CovPointsPlace;
			}
			this.Neighbourhoods = array;
			return;
		}
		this.Neighbourhoods = null;
	}

	// Token: 0x04000757 RID: 1879
	public int Id = -1;

	// Token: 0x04000758 RID: 1880
	public Vector3 Origin;

	// Token: 0x04000759 RID: 1881
	public GClass256[] Neighbourhoods;

	// Token: 0x0400075A RID: 1882
	public int[] NeighbourhoodsIds;

	// Token: 0x0400075B RID: 1883
	public float DefenceLevel;

	// Token: 0x0400075C RID: 1884
	public CoverPointDefenceInfo DefenceInfo;

	// Token: 0x0400075D RID: 1885
	public CoverType CoverType;

	// Token: 0x0400075E RID: 1886
	public ECoverPointSpecial Special;

	// Token: 0x0400075F RID: 1887
	public EnvironmentType EnvironmentType;

	// Token: 0x04000760 RID: 1888
	public int IdEnvironment;

	// Token: 0x04000761 RID: 1889
	[CompilerGenerated]
	private int int_0;

	// Token: 0x04000762 RID: 1890
	[CompilerGenerated]
	private int int_1;

	// Token: 0x02000127 RID: 295
	[CompilerGenerated]
	private sealed class Class98
	{
		// Token: 0x06000734 RID: 1844 RVA: 0x000231DC File Offset: 0x000213DC
		internal bool method_0(CustomNavigationPoint x)
		{
			return x.CovPointsPlace.Id == this.id;
		}

		// Token: 0x04000763 RID: 1891
		public int id;
	}
}