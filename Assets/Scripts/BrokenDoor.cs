using System.Collections;
using UnityEngine;

public class BrokenDoor : MonoBehaviour
{
	public Rigidbody[] Splinters;

	public Vector3 ExplosionCenter;

	public ParticleSystem VFX;

	[Header("Turned ON when breaking door")]
	public GameObject[] On;

	[Header("Turned OFF when breaking door")]
	public GameObject[] Off;

	public Collider[] IgnoreColliders;
}
