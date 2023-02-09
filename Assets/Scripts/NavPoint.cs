using System;
using UnityEngine;
using UnityEngine.Serialization;

// Token: 0x02000117 RID: 279
[Serializable]
public class NavPoint
{
    // Token: 0x060006DB RID: 1755 RVA: 0x00021112 File Offset: 0x0001F312
    public NavPoint(int index, Vector3 pos)
    {
        this.Index = index;
        this.Pos = pos;
    }

    // Token: 0x060006DC RID: 1756 RVA: 0x0002112F File Offset: 0x0001F32F
    public NavPoint(NavPoint other)
    {
        this.Index = other.Index;
        this.Pos = other.Pos;
        this.IsValid = other.IsValid;
        this.reasonNotValid = other.reasonNotValid;
    }

    // Token: 0x060006DD RID: 1757 RVA: 0x0002116E File Offset: 0x0001F36E
    public void SetNotValidReason(string c)
    {
        this.IsValid = false;
        this.reasonNotValid = c;
    }

    // Token: 0x0400070F RID: 1807
    [FormerlySerializedAs("causeNotValid")]
    public string reasonNotValid;

    // Token: 0x04000710 RID: 1808
    public int Index;

    // Token: 0x04000711 RID: 1809
    public bool IsValid = true;

    // Token: 0x04000712 RID: 1810
    public Vector3 Pos;
}