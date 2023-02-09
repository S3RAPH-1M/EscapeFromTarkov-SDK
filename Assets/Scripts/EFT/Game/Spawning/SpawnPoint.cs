using System;
using UnityEngine;

namespace EFT.Game.Spawning
{
	// Token: 0x02001BB2 RID: 7090
	[Serializable]
	public class SpawnPoint : ISpawnPoint
	{
		// (get) Token: 0x0600BED0 RID: 48848 RVA: 0x0032BB63 File Offset: 0x00329D63
		public string BotZoneName
		{
			get
			{
				if (!(this.BotZone != null))
				{
					return "";
				}
				return this.BotZone.ToString();
			}
		}

		// Token: 0x17001B06 RID: 6918
		// (get) Token: 0x0600BED1 RID: 48849 RVA: 0x0032BB84 File Offset: 0x00329D84
		// (set) Token: 0x0600BED2 RID: 48850 RVA: 0x0032BB8C File Offset: 0x00329D8C
		public ISpawnPointCollider Collider { get; set; }

		// Token: 0x17001B07 RID: 6919
		// (get) Token: 0x0600BED3 RID: 48851 RVA: 0x0032BB95 File Offset: 0x00329D95
		string ISpawnPoint.Id
		{
			get
			{
				return this.Id;
			}
		}

		// Token: 0x17001B08 RID: 6920
		// (get) Token: 0x0600BED4 RID: 48852 RVA: 0x0032BB9D File Offset: 0x00329D9D
		string ISpawnPoint.Name
		{
			get
			{
				return this.Name;
			}
		}

		// Token: 0x17001B09 RID: 6921
		// (get) Token: 0x0600BED5 RID: 48853 RVA: 0x0032BBA5 File Offset: 0x00329DA5
		Vector3 ISpawnPoint.Position
		{
			get
			{
				return this.Position;
			}
		}

		// Token: 0x17001B0A RID: 6922
		// (get) Token: 0x0600BED6 RID: 48854 RVA: 0x0032BBAD File Offset: 0x00329DAD
		Quaternion ISpawnPoint.Rotation
		{
			get
			{
				return this.Rotation;
			}
		}

		// Token: 0x17001B0B RID: 6923
		// (get) Token: 0x0600BED7 RID: 48855 RVA: 0x0032BBB5 File Offset: 0x00329DB5
		EPlayerSideMask ISpawnPoint.Sides
		{
			get
			{
				return this.Sides;
			}
		}

		// Token: 0x17001B0C RID: 6924
		// (get) Token: 0x0600BED8 RID: 48856 RVA: 0x0032BBBD File Offset: 0x00329DBD
		ESpawnCategoryMask ISpawnPoint.Categories
		{
			get
			{
				return this.Categories;
			}
		}

		// Token: 0x17001B0D RID: 6925
		// (get) Token: 0x0600BED9 RID: 48857 RVA: 0x0032BBC5 File Offset: 0x00329DC5
		string ISpawnPoint.Infiltration
		{
			get
			{
				return this.Infiltration;
			}
		}

		// Token: 0x17001B0E RID: 6926
		// (get) Token: 0x0600BEDA RID: 48858 RVA: 0x0032BBCD File Offset: 0x00329DCD
		string ISpawnPoint.BotZoneName
		{
			get
			{
				if (!(this.BotZone != null))
				{
					return null;
				}
				return this.BotZone.ToString();
			}
		}

		// Token: 0x17001B0F RID: 6927
		// (get) Token: 0x0600BEDB RID: 48859 RVA: 0x0032BBEA File Offset: 0x00329DEA
		bool ISpawnPoint.IsSnipeZone
		{
			get
			{
				return this.BotZone != null && this.BotZone.SnipeZone;
			}
		}

		// Token: 0x17001B10 RID: 6928
		// (get) Token: 0x0600BEDC RID: 48860 RVA: 0x0032BC07 File Offset: 0x00329E07
		float ISpawnPoint.DelayToCanSpawnSec
		{
			get
			{
				return this.DelayToCanSpawnSec;
			}
		}

		// Token: 0x17001B11 RID: 6929
		// (get) Token: 0x0600BEDD RID: 48861 RVA: 0x0032BC0F File Offset: 0x00329E0F
		// (set) Token: 0x0600BEDE RID: 48862 RVA: 0x0032BC17 File Offset: 0x00329E17
		public float NextBornTime { get; set; }

		// Token: 0x0600BEDF RID: 48863 RVA: 0x0032BC20 File Offset: 0x00329E20
		public void Dispose()
		{
			if (this.BotZone != null)
			{
				this.BotZone.CoverPoints = null;
				this.BotZone.AmbushPoints = null;
				this.BotZone.BushPoints = null;
				if (this.BotZone.ZoneManualInfo != null)
				{
					this.BotZone.ZoneManualInfo.Points = null;
				}
			}
			this.BotZone = null;
		}
		
		// Token: 0x04008F95 RID: 36757
		public string Id;

		// Token: 0x04008F96 RID: 36758
		public string Name;

		// Token: 0x04008F97 RID: 36759
		public Vector3 Position;

		// Token: 0x04008F98 RID: 36760
		public Quaternion Rotation;

		// Token: 0x04008F99 RID: 36761
		public EPlayerSideMask Sides;

		// Token: 0x04008F9A RID: 36762
		public ESpawnCategoryMask Categories;

		// Token: 0x04008F9B RID: 36763
		public string Infiltration;

		// Token: 0x04008F9C RID: 36764
		public BotZone BotZone;

		// Token: 0x04008F9D RID: 36765
		public float DelayToCanSpawnSec = 4f;
	}
}
