using System;
using UnityEngine;

namespace EFT.Interactive
{
    // Token: 0x020021D0 RID: 8656
    [Serializable]
    public class ExitTriggerSettings
    {
        // Token: 0x0400ABA9 RID: 43945
        public string Name;

        // Token: 0x0400ABAA RID: 43946
        public EExfiltrationType ExfiltrationType;

        // Token: 0x0400ABAB RID: 43947
        public float ExfiltrationTime;

        // Token: 0x0400ABAC RID: 43948
        public int PlayersCount;

        // Token: 0x0400ABAD RID: 43949
        [Header("Presence settings")]
        public float Chance;

        // Token: 0x0400ABAE RID: 43950
        public float MinTime;

        // Token: 0x0400ABAF RID: 43951
        public float MaxTime;

        // Token: 0x0400ABB0 RID: 43952
        public int StartTime;

        // Token: 0x0400ABB1 RID: 43953
        public string EntryPoints;
    }
}