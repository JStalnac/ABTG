using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The camera is implemented like this to avoid jittering with differing fps.
 * 
 * Usage: Make your player character and use an empty object as the camera
 * that will be moved in first person with the mouse. Then link that object
 * to actualCamera. This should fix jittering issues. Not 100% sure though lol
 */

namespace Scripts.Player
{
    public class CameraMovement : MonoBehaviour
    {
        public Transform actualCamera;

        // Update is called once per frame
        void Update()
        {
            transform.position = actualCamera.position;
            transform.rotation = actualCamera.rotation;
        }
    }
}
