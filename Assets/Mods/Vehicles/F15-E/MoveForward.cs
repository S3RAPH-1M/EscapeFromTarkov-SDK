using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5f; // Adjustable speed variable
    [SerializeField] 
    private GameObject flyBy1;
    [SerializeField] 
    private GameObject flyBy2;
    [SerializeField] 
    private GameObject flyBy3;
    public float cameraDistance = 250f;
    [SerializeField] 
    private Transform mainCameraTransform; // Serialized camera transform
    private bool activated = false;

    // Update is called once per frame
    void Update()
    {
        // Move the GameObject forward based on the speed and deltaTime
        transform.Translate(Vector3.forward * speed * (Time.deltaTime* 35));

        // Calculate the distance between the camera and this GameObject
        float distanceToCamera = Vector3.Distance(transform.position, mainCameraTransform.position);

        // Activate one of the FlyBy objects based on distance
        if (!activated && distanceToCamera <= cameraDistance)
        {
            // Randomly select one of the FlyBy objects to activate
            int randomIndex = Random.Range(0, 3); // Random index from 0 to 2 (inclusive)
            switch (randomIndex)
            {
                case 0:
                    if (flyBy1 != null)
                        flyBy1.SetActive(true);
                    break;
                case 1:
                    if (flyBy2 != null)
                        flyBy2.SetActive(true);
                    break;
                case 2:
                    if (flyBy3 != null)
                        flyBy3.SetActive(true);
                    break;
            }
            activated = true;
        }
    }
}


