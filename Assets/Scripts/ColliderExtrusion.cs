using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderExtrusion : MonoBehaviour
{
	[SerializeField]
	private Collider _collider;

	[SerializeField]
	private float _castHalo;

	[SerializeField]
	private LayerMask _castMask;

	private const int int_0 = 16;

	private Collider[] collider_0 = new Collider[16];

	private int int_1;

	private float float_0;

	private Vector3 vector3_0;

	private WaitForEndOfFrame waitForEndOfFrame_0 = new WaitForEndOfFrame();

	private HashSet<Collider> hashSet_0 = new HashSet<Collider>();

	public Collider Collider => _collider;

	public void Init(LayerMask castMask)
	{
		_castMask = castMask;
	}

	public void SetCollider(Collider newCollider)
	{
		if (newCollider != null)
		{
			_collider = newCollider;
		}
	}

	private void method_0()
	{
		Bounds bounds = _collider.bounds;
		float_0 = Mathf.Max(Mathf.Max(bounds.extents.x, bounds.extents.y), bounds.extents.z) + _castHalo;
	}

	public void AddIgnoredCollider(Collider collider)
	{
		hashSet_0.Add(collider);
	}

	public void RemoveIgnoredCollider(Collider collider)
	{
		hashSet_0.Remove(collider);
	}

	private bool method_1(Collider collider)
	{
		if (!(collider == _collider))
		{
			return hashSet_0.Contains(collider);
		}
		return true;
	}

	public void Calculate()
	{
		Transform transform = _collider.transform;
		Calculate(transform.position, transform.rotation);
	}

	public void CalculateThroughMotion(Vector3 motion)
	{
		Transform transform = _collider.transform;
		Calculate(transform.position + motion, transform.rotation);
	}

	public IEnumerator CalculateCoroutine(Vector3 position)
	{
		Vector3 vector = position;
		RefreshNeighbours(vector, Vector3.zero);
		int num = 0;
		for (int i = 0; i < int_1; i++)
		{
			Collider collider = collider_0[i];
			if (!method_1(collider))
			{
				if (Physics.ComputePenetration(_collider, vector, _collider.transform.rotation, collider, collider.transform.position, collider.transform.rotation, out var direction, out var distance))
				{
					vector += direction * (distance + 0.001f);
					num++;
				}
				yield return waitForEndOfFrame_0;
			}
		}
		if (num > 0)
		{
			vector3_0 = vector - position;
		}
		else
		{
			vector3_0 = Vector3.zero;
		}
	}

	public void Calculate(Vector3 position, Quaternion rotation, float depenetrationModification = 0.001f)
	{
		RefreshNeighbours(position, Vector3.zero);
		vector3_0 = CalculateDepenetration(position, rotation, depenetrationModification);
	}

	public void RefreshNeighbours(Vector3 position, Vector3 motion)
	{
		method_0();
		Vector3 position2 = position + (_collider.bounds.center - _collider.transform.position) + motion / 2f;
		int_1 = Physics.OverlapSphereNonAlloc(position2, float_0 + motion.magnitude / 2f, collider_0, _castMask, QueryTriggerInteraction.Ignore);
	}

	public Vector3 CalculateDepenetration(Vector3 position, Quaternion rotation, float depenetrationModification = 0.001f)
	{
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < int_1; i++)
		{
			Collider collider = collider_0[i];
			if (!method_1(collider) && Physics.ComputePenetration(_collider, position, rotation, collider, collider.transform.position, collider.transform.rotation, out var direction, out var distance))
			{
				zero += direction * (distance + depenetrationModification);
			}
		}
		return zero;
	}

	public Vector3 GetDepenetration()
	{
		return vector3_0;
	}
}
