using System.Linq;
using EFT.Interactive;
using UnityEngine;

public class GripPose : MonoBehaviour
{
	[ContextMenu("Optionally cache values and !!DESTROY!! skeleton")]
	public void CacheAndDestroy()
	{
		FingerTransforms = transform.GetComponentsInChildren<Transform>();
		Fingers = FingerTransforms.Select(x => x.localRotation).ToArray();
		_cached = true;
		for (int i = transform.childCount - 1; i >= 0; i--)
		{
			if (!Application.isPlaying)
			{
				DestroyImmediate(transform.GetChild(i).gameObject);
			}
			else
			{
				Destroy(transform.GetChild(i).gameObject);
			}
		}
		FingerTransforms = null;
	}

	public EDoorState DoorState = EDoorState.Locked | EDoorState.Shut | EDoorState.Open;
	public EHand Hand;
	public EGripType GripType;
	public Transform[] FingerTransforms;
	public Quaternion[] Fingers;
	public bool DontCache;
	[SerializeField]
	private bool _cached;

	public enum EGripType
	{
		Common,
		Alternative,
		UnderbarrelWeapon
	}

	public enum EHand
	{
		Left,
		Right
	}
}
