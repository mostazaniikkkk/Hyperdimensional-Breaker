using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bronya
{
    public class Normal : MonoBehaviour
    {
        bool grounded = false;
        public float velJump = 4.5f;
        public float velMov = 3f;
        public Master master;

        private void OnEnable()
        {
            master.rigidbody2D.gravityScale = 1;
        }

        private void Update()
        {
            master.stats.IncreaseBoost(20f * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.R))
            {
                //Preguntar si el boost esta activo
                if (master.stats.BoostReady)
                {
                    //Gastar el boost
                    master.stats.UseBoost();
                    //Active Boost cambiando gameObjects
                    master.SetActiveModeBoost(true);
                    return;
                }
            }

            Movement();
        }

        void Movement()
        {
            //Ground
            List<ContactPoint2D> contacts = new List<ContactPoint2D>();
            bool temp_isGrounded = false;
            master.boxCollider.GetContacts(contacts: contacts);
            for (int i = 0; i < contacts.Count; i++)
            {
                if (Vector2.Angle(contacts[i].normal, Vector2.up) <= 60)
                    temp_isGrounded = true;
            }
            grounded = temp_isGrounded;


            //Mover
            if (Input.GetAxis("Horizontal") != 0)
            {
                Vector2 vel = new Vector2(Input.GetAxis("Horizontal") * velMov, master.rigidbody2D.velocity.y);
                master.rigidbody2D.velocity = vel;
            }

            //Saltar
            if (grounded && Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 vel = master.rigidbody2D.velocity;
                vel += Vector2.up * velJump;
                master.rigidbody2D.velocity = vel;
            }
        }
    }
}