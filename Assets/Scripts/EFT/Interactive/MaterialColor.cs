using System;
using UnityEngine;

namespace EFT.Interactive
{
    // Token: 0x02002229 RID: 8745
    [Serializable]
    public sealed class MaterialColor : MaterialData
    {
        // Token: 0x0600C46B RID: 50283 RVA: 0x000134BD File Offset: 0x000116BD
        public override void Init()
        {
        }

        // Token: 0x0600C46C RID: 50284 RVA: 0x00343AA7 File Offset: 0x00341CA7
        public override void TurnLights(bool on)
        {
            if (base.Material == null)
            {
                return;
            }
            base.Material.SetColor(this.ParemeterName, on ? this.ColorOn : this.ColorOff);
        }

        // Token: 0x0600C46D RID: 50285 RVA: 0x00343ADA File Offset: 0x00341CDA
        public override void SetIntensity(float intensity)
        {
            if (base.Material == null)
            {
                return;
            }
            base.Material.SetColor(this.ParemeterName, Color.Lerp(this.ColorOff, this.ColorOn, intensity));
        }

        // Token: 0x0400AD69 RID: 44393
        public string ParemeterName;

        // Token: 0x0400AD6A RID: 44394
        [ColorUsage(true, true)]
        public Color ColorOn;

        // Token: 0x0400AD6B RID: 44395
        [ColorUsage(true, true)]
        public Color ColorOff;
    }
}