using System;
using UnityEngine;

namespace EFT.Game.Spawning
{
    // Token: 0x0200214F RID: 8527
    public interface ISpawnPoint
    {
        // Token: 0x17001AF8 RID: 6904
        // (get) Token: 0x0600BEA7 RID: 48807
        string Id { get; }

        // Token: 0x17001AF9 RID: 6905
        // (get) Token: 0x0600BEA8 RID: 48808
        string Name { get; }

        // Token: 0x17001AFA RID: 6906
        // (get) Token: 0x0600BEA9 RID: 48809
        Vector3 Position { get; }

        // Token: 0x17001AFB RID: 6907
        // (get) Token: 0x0600BEAA RID: 48810
        Quaternion Rotation { get; }

        // Token: 0x17001AFC RID: 6908
        // (get) Token: 0x0600BEAB RID: 48811
        EPlayerSideMask Sides { get; }

        // Token: 0x17001AFD RID: 6909
        // (get) Token: 0x0600BEAC RID: 48812
        ESpawnCategoryMask Categories { get; }

        // Token: 0x17001AFE RID: 6910
        // (get) Token: 0x0600BEAD RID: 48813
        string Infiltration { get; }

        // Token: 0x17001AFF RID: 6911
        // (get) Token: 0x0600BEAE RID: 48814
        string BotZoneName { get; }

        // Token: 0x17001B00 RID: 6912
        // (get) Token: 0x0600BEAF RID: 48815
        bool IsSnipeZone { get; }

        // Token: 0x17001B01 RID: 6913
        // (get) Token: 0x0600BEB0 RID: 48816
        float DelayToCanSpawnSec { get; }

        // Token: 0x17001B02 RID: 6914
        // (get) Token: 0x0600BEB1 RID: 48817
        // (set) Token: 0x0600BEB2 RID: 48818
        float NextBornTime { get; set; }

        // Token: 0x17001B03 RID: 6915
        // (get) Token: 0x0600BEB3 RID: 48819
        ISpawnPointCollider Collider { get; }

        // Token: 0x0600BEB4 RID: 48820
        void Dispose();
    }
}