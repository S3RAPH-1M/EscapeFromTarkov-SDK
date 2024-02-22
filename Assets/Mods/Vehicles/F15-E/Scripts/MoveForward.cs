using System;
using System.Collections;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovAmbience
{


    public class MoveForward : MonoBehaviour
    {
        [SerializeField]
        public float speed; // Adjustable speed variable
        [SerializeField]
        private GameObject flyBy1;
        [SerializeField]
        private GameObject flyBy2;
        [SerializeField]
        private GameObject flyBy3;
        [SerializeField]
        public float cameraDistance;
        [SerializeField]
        public float deltaTimeMultiplier;
        [SerializeField]
        private Transform mainCameraTransform; // Serialized camera transform
        private bool activated = false;

        // Update is called once per frame
        public void Start()
        {

        }
        public void Update()
        {
            if(mainCameraTransform != null) 
            {
                transform.Translate(Vector3.forward * speed * (Time.deltaTime * deltaTimeMultiplier));

                float distanceToCamera = Vector3.Distance(transform.position, mainCameraTransform.position);

                if (!activated && distanceToCamera <= cameraDistance)
                {
                    // Randomly select one of the FlyBy objects to activate
                    int randomIndex = UnityEngine.Random.Range(0, 3); // Random index from 0 to 2 (inclusive)
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
    }
}
