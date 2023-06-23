using System;
using UnityEngine;

// Token: 0x0200042A RID: 1066
[Serializable]
public class BotLocationModifier
{
    // Token: 0x06001E21 RID: 7713 RVA: 0x00090E04 File Offset: 0x0008F004
    public void Validate()
    {
        this.method_0(ref this.AccuracySpeed);
        this.method_0(ref this.Scattering);
        this.method_0(ref this.GainSight);
        this.method_0(ref this.MarksmanAccuratyCoef);
        this.method_0(ref this.VisibleDistance);
        this.method_0(ref this.DistToSleep);
        this.method_0(ref this.DistToActivate);
        if (this.MagnetPower < 0f)
        {
            Debug.LogError("Wrong MagnetPower location map modification parameter in taxonomy. fix it manually!");
            this.MagnetPower = 0f;
        }
    }

    // Token: 0x06001E22 RID: 7714 RVA: 0x00090E87 File Offset: 0x0008F087
    private void method_0(ref float val)
    {
        if (val <= 0.001f)
        {
            Debug.LogError("Wrong location map modification parameter in taxonomy. fix it manually!");
            val = 1f;
        }
    }

    // Token: 0x040017CD RID: 6093
    public float AccuracySpeed = 1f;

    // Token: 0x040017CE RID: 6094
    public float Scattering = 1f;

    // Token: 0x040017CF RID: 6095
    public float GainSight = 1f;

    // Token: 0x040017D0 RID: 6096
    public float MarksmanAccuratyCoef = 1f;

    // Token: 0x040017D1 RID: 6097
    public float VisibleDistance = 1f;

    // Token: 0x040017D2 RID: 6098
    public float MagnetPower = 10f;

    // Token: 0x040017D3 RID: 6099
    public float DistToSleep = 240f;

    // Token: 0x040017D4 RID: 6100
    public float DistToActivate = 220f;

    // Token: 0x040017D5 RID: 6101
    public float DistToPersueAxemanCoef = 1f;

    // Token: 0x040017D6 RID: 6102
    public float KhorovodChance;
}