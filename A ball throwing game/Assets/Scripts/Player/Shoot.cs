using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Player
{
    public class Shoot : MonoBehaviour
    {
        public Transform FirePoint;
        public GameObject Ball;
        public GameObject Balls;
        public Transform cameraRotation;

        void Update() 
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject ball = Instantiate(Ball, FirePoint.position, cameraRotation.rotation);
                
                ball.transform.SetParent(Balls.transform);
            }
        }
    }
}
