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

        private void Update()
        {
            if (Input.GetKey(buttonAttack))
            {
                if (!robot.activeSelf)
                { 
                    robot.SetActive(true);
                }
                else if (coolDown_aux < Time.time)
                {
                    Debug.Log("Fire");
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
    }
}