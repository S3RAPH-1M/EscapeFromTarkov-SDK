using UnityEngine;

public class AlwaysUp : MonoBehaviour
{
	private void Update()
	{
		base.transform.LookAt(base.transform.position + base.transform.parent.forward, Vector3.up);
	}
}
