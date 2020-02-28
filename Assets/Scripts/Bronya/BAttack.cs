using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bronya
{
    public class BAttack : MonoBehaviour
    {
        public GameObject robot;
        public float time_robotActive = 2f;
        public float coolDownFire = 0.3f;
        float time_aux;
        float coolDown_aux = -1;
        public KeyCode buttonAttack;
        public bool onAttack = false;
        public GameObject aim;
        public GameObject bullet;
        public float velAttack = 5f;
        public float scale = 10;
        public Master master;

        private void Update()
        {
            if (Input.GetKey(buttonAttack))
            {
                if (!robot.activeSelf)
                { 
                    robot.SetActive(true);
                }
                if (coolDown_aux < Time.time)
                {
                    Fire();
                    coolDown_aux = Time.time + coolDownFire;
                }
                time_aux = Time.time + time_robotActive;
                onAttack = true;
            }
            else
            {
                onAttack = false;
            }

            if (Time.time > time_aux) robot.SetActive(false);
        }

        void Fire()
        {
            
            GameObject obj = Instantiate(bullet, position:aim.transform.position, rotation:aim.transform.rotation);
            if (master.normal.transform.localScale.x > 0) {
                obj.GetComponent<Rigidbody2D>().velocity = -obj.transform.right.normalized * velAttack;
            }
            else
            {
                obj.GetComponent<Rigidbody2D>().velocity = obj.transform.right.normalized * velAttack;
                float scale = obj.transform.localScale.x;
                obj.transform.localScale = new Vector3(-1, 1, 1) * scale;
            }
            //obj.transform.localScale *= scale;
        }
    }
}