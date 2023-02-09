using System;
using JetBrains.Annotations;
using UnityEngine;

namespace EFT.Interactive
{
    // Token: 0x02002228 RID: 8744
    [Serializable]
    public abstract class MaterialData
    {
        // Token: 0x17001BE0 RID: 7136
        // (get) Token: 0x0600C466 RID: 50278 RVA: 0x00343A83 File Offset: 0x00341C83
        [CanBeNull]
        protected Material Material
        {
            get
            {
                if (!(this.Renderer == null))
                {
                    return this.Renderer.materials[this.MaterialId];
                }
                return null;
            }
        }

        // Token: 0x0600C467 RID: 50279
        public abstract void Init();

        // Token: 0x0600C468 RID: 50280
        public abstract void TurnLights(bool on);

        // Token: 0x0600C469 RID: 50281
        public abstract void SetIntensity(float intensity);

        // Token: 0x0400AD67 RID: 44391
        public Renderer Renderer;

        // Token: 0x0400AD68 RID: 44392
        public int MaterialId;
    }
}