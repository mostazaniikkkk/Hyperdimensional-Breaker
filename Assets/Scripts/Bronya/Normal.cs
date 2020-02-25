﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bronya
{
    public class Normal : MonoBehaviour
    {
        bool grounded = false;
        public float velJump = 4.5f;
        //public float velMov = 3f;
        //public float distanceDash = 5f;
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

            //Salto muerto
            if (Input.GetKeyUp(KeyCode.Space) && !grounded){
                if (master.rigidbody2D.velocity.y > 0){
                    Vector2 vel = master.rigidbody2D.velocity;
                    vel.y = 0;
                    master.rigidbody2D.velocity = vel;
                }
            }

            //Mover
            if (/*Input.GetAxis("Horizontal") != 0*/ true)
            {
                Vector2 vel = new Vector2(Input.GetAxis("Horizontal") * master.config.walk_velocity, master.rigidbody2D.velocity.y);
                master.rigidbody2D.velocity = vel;
            }

            //Cambiar direccion
            Vector3 scale = transform.localScale;
            if (Input.GetAxis("Horizontal") > 0f && scale.x < 0)  scale.x = -scale.x; //Right
            else if (Input.GetAxis("Horizontal") < 0f && scale.x > 0) scale.x = -scale.x; //Left
            transform.localScale = scale;

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
                Vector2 size = coll.size;
                size.x *= master.transform.localScale.x;
                size.y *= master.transform.localScale.y;

                //RaycastHit2D[] hits = Physics2D.BoxCastAll((Vector2)coll.transform.position + coll.offset, coll.size, 0, direction, distanceDash, DashCollision);
                RaycastHit2D hit = Physics2D.BoxCast((Vector2)coll.transform.position + coll.offset, size * 0.95f, 0, direction, master.config.dash_normalDistance, DashCollision);
                if (hit == false) addPosition = direction.normalized * master.config.dash_normalDistance;
                else addPosition = direction.normalized * hit.distance;
                Debug.Log("Add position: " + addPosition);
                //Debug.Log("Hit: " + hit.collider.name);

                master.rigidbody2D.transform.position += (Vector3)addPosition;
            }

        }
    }
}