using EFT.Airdrop;
using EFT.BufferZone;
using EFT.Game.Spawning;
using EFT.Hideout;
using EFT.Interactive;
using EFT.MovingPlatforms;
using EFT.SpeedTree;
using EFT.SynchronizableObjects;
using UnityEngine;

// Token: 0x02000514 RID: 1300
[ExecuteInEditMode]
public sealed class LocationScene : MonoBehaviour
{
	// Token: 0x0400204C RID: 8268
	public StaticLoot[] StaticLoot;

	// Token: 0x0400204D RID: 8269
	public LootableContainer[] LootableContainers;

	// Token: 0x0400204E RID: 8270
	public WorldInteractiveObject[] WorldInteractiveObjects;

	// Token: 0x0400204F RID: 8271
	public NavMeshDoorLink[] NavMeshLinks;

	// Token: 0x04002050 RID: 8272
	public SpawnPointMarker[] SpawnPointMarkers;

	// Token: 0x04002051 RID: 8273
	public BotZone[] BotZones;

	// Token: 0x04002052 RID: 8274
	public ExfiltrationPoint[] ExfiltrationPoints;

	// Token: 0x04002053 RID: 8275
	public AIPlaceInfo[] AIPlaceInfos;

	// Token: 0x04002054 RID: 8276
	public StationaryWeapon[] StationaryWeapons;

	// Token: 0x04002055 RID: 8277
	public MovingPlatform[] MovingPlatforms;

	// Token: 0x04002056 RID: 8278
	public BorderZone[] BorderZones;

	// Token: 0x04002057 RID: 8279
	public BaseRestrictableZone[] RestrictableZones;

	// Token: 0x04002058 RID: 8280
	public LampController[] Lamps;

	// Token: 0x04002059 RID: 8281
	public WindowBreaker[] Windows;

	// Token: 0x0400205A RID: 8282
	public SynchronizableObject[] SynchronizableObjects;

	// Token: 0x0400205B RID: 8283
	public AirdropPoint[] AirdropPoints;

	// Token: 0x0400205C RID: 8284
	public BufferZoneContainer[] BufferZoneContainers;

	// Token: 0x0400205D RID: 8285
	public AreasController[] AreasControllers;

	// Token: 0x0400205E RID: 8286
	public AudioSource[] AudioSources;

	public TreeWind[] treeWinds;

	public TreeWind.Settings[] treeWindSettingsPresets;
}
