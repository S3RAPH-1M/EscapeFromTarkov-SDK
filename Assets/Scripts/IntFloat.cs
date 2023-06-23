using System;

// Token: 0x02000118 RID: 280
[Serializable]
public class IntFloat
{
    // Token: 0x060006DE RID: 1758 RVA: 0x0002117E File Offset: 0x0001F37E
    public IntFloat(int index, float val)
    {
        this.Index = index;
        this.Value = val;
    }

    // Token: 0x04000713 RID: 1811
    public int Index;

    // Token: 0x04000714 RID: 1812
    public float Value;
}