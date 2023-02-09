using System;
using UnityEngine;

namespace EFT.Animations
{
    // Token: 0x02001C28 RID: 7208
    public abstract class WeaponMachinery : MonoBehaviour
    {
        // Token: 0x0600A75D RID: 42845
        public abstract void SetTransforms(TransformLinks hierarchy);

        // Token: 0x0600A75E RID: 42846
        public abstract void UpdateJoints();

        // Token: 0x0600A75F RID: 42847
        public abstract void OnRotation();
    }
}