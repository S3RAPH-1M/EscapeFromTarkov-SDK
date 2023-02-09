using System;
using UnityEngine;

namespace EFT.Game.Spawning
{
    // Token: 0x02002151 RID: 8529
    public interface ISpawnPointCollider
    {
        // Token: 0x0600BEB6 RID: 48822
        bool Contains(Vector3 point);

        // Token: 0x0600BEB7 RID: 48823
        string DebugInfo();
    }
}