using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts;

namespace Scripts.Ball
{
    public class Ball : MonoBehaviour, IDamageable
    {
        public Vector3 InitialVelocity;

        Rigidbody rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.AddRelativeForce(InitialVelocity);

            Invoke(nameof(Die), 5);
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        public void TakeDamage()
        {
            throw new System.NotImplementedException();
        }

    }
}
