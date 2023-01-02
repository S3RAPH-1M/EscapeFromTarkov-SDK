using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using EFT.Game.Spawning;
using EFT.Hideout;
using EFT.Interactive;
using EFT.MovingPlatforms;
using EFT.SpeedTree;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000514 RID: 1300
[ExecuteInEditMode]
public sealed class LocationScene : MonoBehaviour
{
	// Token: 0x04001DFA RID: 7674
	public StaticLoot[] StaticLoot;

	// Token: 0x04001DFB RID: 7675
	public LootableContainer[] LootableContainers;

	// Token: 0x04001DFC RID: 7676
	public WorldInteractiveObject[] WorldInteractiveObjects;

	// Token: 0x04001DFD RID: 7677
	public NavMeshDoorLink[] NavMeshLinks;

	// Token: 0x04001DFE RID: 7678
	public SpawnPointMarker[] SpawnPointMarkers;

	// Token: 0x04001DFF RID: 7679
	public BotZone[] BotZones;

	// Token: 0x04001E00 RID: 7680
	public ExfiltrationPoint[] ExfiltrationPoints;

	// Token: 0x04001E0D RID: 7693
	public static readonly List<LocationScene> LoadedScenes = new List<LocationScene>();

	// Token: 0x04001E0E RID: 7694
	public static readonly List<Collider> DoorsCollisionColliders = new List<Collider>();

	// Token: 0x04001E0F RID: 7695
	private readonly Dictionary<Type, Array> dictionary_0 = new Dictionary<Type, Array>();

	// Token: 0x02000515 RID: 1301
	[CompilerGenerated]
	[Serializable]
	private sealed class Class260<T>
	{
		// Token: 0x04001E10 RID: 7696
		public static readonly LocationScene.Class260<T> class260_0 = new LocationScene.Class260<T>();

		// Token: 0x04001E11 RID: 7697
		public static Func<LocationScene, IEnumerable<T>> func_0;
	}

	// Token: 0x02000516 RID: 1302
	[CompilerGenerated]
	private sealed class Class262<T> where T : Behaviour
	{
		// Token: 0x04001E13 RID: 7699
		public LocationScene scene;

	}

	// Token: 0x02000518 RID: 1304
	[CompilerGenerated]
	[Serializable]
	private sealed class Class263<T> where T : Behaviour
	{
		// Token: 0x04001E15 RID: 7701
		public static readonly LocationScene.Class263<T> class263_0 = new LocationScene.Class263<T>();

		// Token: 0x04001E16 RID: 7702
		public static Func<LocationScene, IEnumerable<T>> func_0;
	}

	// Token: 0x02000519 RID: 1305
	[CompilerGenerated]
	[StructLayout(LayoutKind.Auto)]
	private struct Struct22
	{
		public Scene scene;
	}

	// Token: 0x0200051A RID: 1306
	[CompilerGenerated]
	private sealed class Class264
	{
		// Token: 0x04001E18 RID: 7704
		public Scene scene;
	}

	// Token: 0x0200051B RID: 1307
	[CompilerGenerated]
	private sealed class Class265<T>
	{
		// Token: 0x04001E19 RID: 7705
		public bool includeInactive;
	}
}
