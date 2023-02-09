using System;
using UnityEngine;

// Token: 0x02000129 RID: 297
[Serializable]
public class CoverPointPlaceSerializable
{
    // Token: 0x06000735 RID: 1845 RVA: 0x000231F1 File Offset: 0x000213F1
    public CoverPointPlaceSerializable(Vector3 origin, CoverPointDefenceInfo defenceInfo, CoverType coverType, bool isGoodInside)
    {
        this.Special = (ECoverPointSpecial)0;
        this.IsGoodInsideBuilding = isGoodInside;
        this.DefenceInfo = defenceInfo;
        this.Origin = origin;
        this.CoverType = coverType;
    }

    // Token: 0x04000767 RID: 1895
    public int Id = -1;

    // Token: 0x04000768 RID: 1896
    public Vector3 Origin;

    // Token: 0x04000769 RID: 1897
    public int[] NeighbourhoodIds;

    // Token: 0x0400076A RID: 1898
    public float DefenceLevel;

    // Token: 0x0400076B RID: 1899
    public CoverPointDefenceInfo DefenceInfo;

    // Token: 0x0400076C RID: 1900
    public CoverType CoverType;

    // Token: 0x0400076D RID: 1901
    public bool IsGoodInsideBuilding;

    // Token: 0x0400076E RID: 1902
    public ECoverPointSpecial Special;

    // Token: 0x0400076F RID: 1903
    public EnvironmentType EnvironmentType;

    // Token: 0x04000770 RID: 1904
    public int IdEnvironment;
}