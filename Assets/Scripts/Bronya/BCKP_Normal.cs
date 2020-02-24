using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bronya
{
    public class BCKP_Normal : MonoBehaviour
    {
        bool grounded = false;
        public float velJump = 4.5f;
        public float velMov = 3f;
        public float distanceDash = 5f;
        public LayerMask DashCollision = -1;
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
            if (/*Input.GetAxis("Horizontal") != 0*/ true)
            {
                Vector2 vel = new Vector2(Input.GetAxis("Horizontal") * velMov, master.rigidbody2D.velocity.y);
                master.rigidbody2D.velocity = vel;
            }

            //Cambiar direccion
            float valueScale = 1f;
            if (Input.GetAxis("Horizontal") > 0f) transform.localScale = new Vector3(1, 1, 1) * valueScale; //Right
            else if (Input.GetAxis("Horizontal") < 0f) transform.localScale = new Vector3(-1, 1, 1) * valueScale; //Left

            //Saltar
            if (grounded && Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 vel = master.rigidbody2D.velocity;
                vel += Vector2.up * velJump;
                master.rigidbody2D.velocity = vel;
            }

            //Dash
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("Dash");
                BoxCollider2D coll = master.boxCollider;
                Vector2 direction = new Vector2(transform.localScale.x, 0).normalized;
                Vector2 addPosition;

                //RaycastHit2D[] hits = Physics2D.BoxCastAll((Vector2)coll.transform.position + coll.offset, coll.size, 0, direction, distanceDash, DashCollision);
                RaycastHit2D hit = Physics2D.BoxCast((Vector2)coll.transform.position + coll.offset, coll.size * 0.95f, 0, direction, distanceDash, DashCollision);
                if (hit == false) addPosition = direction.normalized * distanceDash;
                else addPosition = direction.normalized * hit.distance;
                Debug.Log("Add position: " + addPosition);
                //Debug.Log("Hit: " + hit.collider.name);

                master.rigidbody2D.transform.position += (Vector3)addPosition;
            }

        }
    }
}