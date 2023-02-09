using UnityEngine;

// Token: 0x02000480 RID: 1152
public class GAttribute6 : PropertyAttribute
{
    // Token: 0x06001FDA RID: 8154 RVA: 0x00099CD3 File Offset: 0x00097ED3
    public GAttribute6(float min, float max, float round = -1f)
    {
        this.Min = min;
        this.Max = max;
        this.UseRound = (round > 0f);
        this.Round = 1f / round;
        this.InvRound = round;
    }

    // Token: 0x04001BCC RID: 7116
    public readonly float Min;

    // Token: 0x04001BCD RID: 7117
    public readonly float Max;

    // Token: 0x04001BCE RID: 7118
    public readonly float Round;

    // Token: 0x04001BCF RID: 7119
    public readonly float InvRound;

    // Token: 0x04001BD0 RID: 7120
    public readonly bool UseRound;
}