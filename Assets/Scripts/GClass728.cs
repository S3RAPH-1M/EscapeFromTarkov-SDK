using EFT;
using EFT.Game.Spawning;
using UnityEngine;

public class GClass728 : ScriptableObject, ISerializationCallbackReceiver
{
    public ESpawnCategoryMask spawnCategoryMask;
    public EPlayerSideMask playerSideMask;
    public bool alwaysDrawPatrolPoints;
    public bool noDrawSatelites;
    public bool drawBounds;
    
    public static ESpawnCategoryMask SpawnCategoryMask = ESpawnCategoryMask.None;
    public static EPlayerSideMask PlayerSideMask = EPlayerSideMask.All;
    public static bool AlwaysDrawPatrolPoints = false;
    public static bool NoDrawSatelites = false;
    public static bool DrawBounds = false;

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        SpawnCategoryMask = spawnCategoryMask;
        PlayerSideMask = playerSideMask;
        AlwaysDrawPatrolPoints = alwaysDrawPatrolPoints;
        NoDrawSatelites = noDrawSatelites;
        DrawBounds = drawBounds;
    }
}
