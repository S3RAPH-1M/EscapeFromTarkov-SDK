using System;

// Token: 0x0200011B RID: 283
public enum DirectionCalculationType
{
    // Token: 0x0400071E RID: 1822
    Raycast = 1,
    // Token: 0x0400071F RID: 1823
    SimpleNormals,
    // Token: 0x04000720 RID: 1824
    TryBothRaycastFirst,
    // Token: 0x04000721 RID: 1825
    TryBothNormalsFirst,
    // Token: 0x04000722 RID: 1826
    TryBothAndChooseBest
}