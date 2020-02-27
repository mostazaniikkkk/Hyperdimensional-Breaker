using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bronya
{
    public class BAnim : MonoBehaviour
    {
        public Master master;
        public Animator animator;
        public string fireParameter = "fire";
        public string walkParameter = "walk";

        private void LateUpdate()
        {
            //Walk
            float vel = master.rigidbody2D.velocity.x;
            bool ground = master.normal.grounded;

            if (ground && vel != 0)
                animator.SetBool(walkParameter, true);
            else
                animator.SetBool(walkParameter, false);

            //Fire


            
        }
    }
}
