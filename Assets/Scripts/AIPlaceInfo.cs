using UnityEngine;

public class AIPlaceInfo : MonoBehaviour
{
    // Token: 0x04001B09 RID: 6921
    public int AreaId;

    // Token: 0x04001B0A RID: 6922
    public string Id;

    // Token: 0x04001B0B RID: 6923
    public ThrowGrenadePlace[] GrenadePlaces;

    // Token: 0x04001B0C RID: 6924
    public BoxCollider Collider;

    // Token: 0x04001B0D RID: 6925
    public bool IsOnTrigger = true;

    // Token: 0x04001B0E RID: 6926
    public bool BlockGrenade;

    // Token: 0x04001B0F RID: 6927
    public bool IsDark;

    // Token: 0x04001B10 RID: 6928
    public bool IsInside;

    // Token: 0x04001B11 RID: 6929
    public bool AtrZone;

    // Token: 0x04001B16 RID: 6934
    public AIPlaceInfoLogic InfoLogicAllEnemy;

    // Token: 0x04001B17 RID: 6935
    public ECoverPointSpecial CoversSpecial;

    // Token: 0x04001B1A RID: 6938
    public bool UseAsCoverGroupId = true;
}