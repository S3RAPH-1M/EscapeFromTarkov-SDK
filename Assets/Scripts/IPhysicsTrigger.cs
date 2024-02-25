using UnityEngine;

public interface IPhysicsTrigger
{
	bool enabled { get; set; }

	string Description { get; }

	void OnTriggerEnter(Collider collider);

	void OnTriggerExit(Collider collider);
}
