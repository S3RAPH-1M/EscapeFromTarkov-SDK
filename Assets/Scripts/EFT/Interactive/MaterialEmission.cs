using System;
using UnityEngine;

namespace EFT.Interactive
{
    // Token: 0x0200222A RID: 8746
    [Serializable]
    public sealed class MaterialEmission : MaterialData
    {
        // Token: 0x0600C46F RID: 50287 RVA: 0x00343B16 File Offset: 0x00341D16
        public override void Init()
        {
            if (base.Material == null)
            {
                return;
            }
            if (this._maxEmissionVisibility < 0f)
            {
                this._maxEmissionVisibility = base.Material.GetFloat(MaterialEmission._emissionVisibility);
            }
        }

        // Token: 0x0600C470 RID: 50288 RVA: 0x00343B4A File Offset: 0x00341D4A
        public override void TurnLights(bool on)
        {
            if (base.Material == null)
            {
                return;
            }
            base.Material.SetFloat(MaterialEmission._emissionVisibility, on ? this._maxEmissionVisibility : 0f);
        }

        // Token: 0x0600C471 RID: 50289 RVA: 0x00343B7B File Offset: 0x00341D7B
        public override void SetIntensity(float intensity)
        {
            if (base.Material == null)
            {
                return;
            }
            base.Material.SetFloat(MaterialEmission._emissionVisibility, this._maxEmissionVisibility * intensity);
        }

        // Token: 0x0600C472 RID: 50290 RVA: 0x00343BA4 File Offset: 0x00341DA4
        public void SetMaxEmissionVisibility(float value)
        {
            this._maxEmissionVisibility = value;
        }

        // Token: 0x0400AD6C RID: 44396
        [SerializeField]
        private float _maxEmissionVisibility = -1f;

        // Token: 0x0400AD6D RID: 44397
        private static readonly int _emissionVisibility = Shader.PropertyToID("_EmissionVisibility");
    }
}