using UnityEngine;
using UnityEngine.AI;

namespace EFT.Interactive
{
    // Token: 0x02002249 RID: 8777
    public class WorldInteractiveObject : InteractableObject
    {
        public virtual float CurrentAngle
        {
            get
            {
                return this._currentAngle;
            }
            protected set
            {
                this._currentAngle = value;
                if (base.transform.parent != null)
                {
                    base.transform.rotation = this.GetDoorRotation(this._currentAngle) * base.transform.parent.rotation;
                }
            }
        }
        
        public virtual EDoorState DoorState
        {
            get
            {
                return this._doorState;
            }
            set
            {
                EDoorState doorState = this._doorState;
                this._doorState = value;
            }
        }
        
        public virtual void OnEnable()
        {
            this.CurrentAngle = this.GetAngle(this.DoorState);
        }
        
        public Quaternion GetDoorRotation(float currentAngle)
        {
            return Quaternion.AngleAxis(currentAngle, GetRotationAxis(DoorAxis, transform.parent));
        }

        // Token: 0x0600C552 RID: 50514 RVA: 0x00346878 File Offset: 0x00344A78
        public static Vector3 GetRotationAxis(EDoorAxis doorAxis, Transform objectTransform)
        {
            if (objectTransform == null) return Vector3.zero;
            switch (doorAxis)
            {
                case EDoorAxis.X:
                    return objectTransform.right;
                case EDoorAxis.Y:
                    return objectTransform.up;
                case EDoorAxis.Z:
                    return objectTransform.forward;
                case EDoorAxis.XNegative:
                    return -objectTransform.right;
                case EDoorAxis.YNegative:
                    return -objectTransform.up;
                case EDoorAxis.ZNegative:
                    return -objectTransform.forward;
                default:
                    return Vector3.zero;
            }
        }

        // Token: 0x0600C556 RID: 50518 RVA: 0x00346AEC File Offset: 0x00344CEC
        public virtual float GetAngle(EDoorState state)
        {
            if (state - EDoorState.Locked <= 1) return CloseAngle;
            if (state != EDoorState.Open) return _currentAngle;
            return OpenAngle;
        }

        // Token: 0x0600C558 RID: 50520 RVA: 0x00346B30 File Offset: 0x00344D30
        public override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position,
                GetDoorRotation(GetAngle(EDoorState.Shut)) * GetRotationAxis(DoorForward, transform));
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position,
                GetDoorRotation(GetAngle(EDoorState.Open)) * GetRotationAxis(DoorForward, transform));
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(transform.parent.rotation * interactPosition1 + transform.position, Vector3.one * 0.1f);
            Gizmos.DrawCube(transform.parent.rotation * interactPosition2 + transform.position, Vector3.one * 0.1f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.TransformPoint(viewTarget1), 0.05f);
        }

        // Token: 0x0400AE18 RID: 44568
        [Header("States that take control of a player")]
        public EDoorState Snap = EDoorState.Locked | EDoorState.Shut | EDoorState.Open | EDoorState.Interacting;

        // Token: 0x0400AE19 RID: 44569
        public string KeyId;

        // Token: 0x0400AE1A RID: 44570
        public string Id;

        // Token: 0x0400AE1B RID: 44571
        [SerializeField] protected float _currentAngle;

        // Token: 0x0400AE1C RID: 44572
        public Vector3 interactPosition1;

        // Token: 0x0400AE1D RID: 44573
        public Vector3 interactPosition2;

        // Token: 0x0400AE1E RID: 44574
        public Vector3 viewTarget1;

        public DoorHandle LockHandle;

        // Token: 0x0400AE20 RID: 44576
        public float OpenAngle = 60f;

        // Token: 0x0400AE21 RID: 44577
        public float CloseAngle;

        // Token: 0x0400AE22 RID: 44578
        public EDoorAxis DoorAxis = EDoorAxis.Z;

        // Token: 0x0400AE23 RID: 44579
        public EDoorAxis DoorForward = EDoorAxis.Z;

        // Token: 0x0400AE24 RID: 44580
        [Header("Animations")] public bool interactWithoutAnimation;

        // Token: 0x0400AE25 RID: 44581
        public int PushID;

        // Token: 0x0400AE26 RID: 44582
        public int CloseID;

        public AudioClip[] ShutSound;

        public AudioClip[] SqueakSound;

        public AudioClip[] OpenSound;

        // Token: 0x0400AE2A RID: 44586
        public float ShutShift;

        // Token: 0x0400AE2B RID: 44587
        public NavMeshObstacle Obstacle;

        // Token: 0x0400AE2C RID: 44588
        [SerializeField] protected EDoorState _doorState;

        // Token: 0x0400AE2F RID: 44591
        [SerializeField] protected DoorHandle _handle;

        // Token: 0x0400AE31 RID: 44593
        [SerializeField] private bool _forceLocalInteraction;

        // Token: 0x0400AE32 RID: 44594
        [Space(10f)] [Header("Actions")] public bool Operatable = true;

        public enum EDoorAxis
        {
            // Token: 0x0400AE4A RID: 44618
            X,

            // Token: 0x0400AE4B RID: 44619
            Y,

            // Token: 0x0400AE4C RID: 44620
            Z,

            // Token: 0x0400AE4D RID: 44621
            XNegative,

            // Token: 0x0400AE4E RID: 44622
            YNegative,

            // Token: 0x0400AE4F RID: 44623
            ZNegative
        }

        // Token: 0x0200224C RID: 8780
        public enum EInteractionAction
        {
            // Token: 0x0400AE51 RID: 44625
            Pull,

            // Token: 0x0400AE52 RID: 44626
            Push
        }

        // Token: 0x0200224D RID: 8781
        public enum ERotationInterpolationMode
        {
            // Token: 0x0400AE54 RID: 44628
            ViewTarget,

            // Token: 0x0400AE55 RID: 44629
            ViewTargetWithZeroPitch,

            // Token: 0x0400AE56 RID: 44630
            ViewTargetAsOrientation
        }
    }
}