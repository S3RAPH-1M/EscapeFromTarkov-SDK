using UnityEngine;

public interface IPhysicsTriggerWithStay : IPhysicsTrigger
{
	void OnTriggerStay(Collider collider);
}
