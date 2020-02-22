using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bronya
{
    public class Boost : MonoBehaviour
    {
        float timeLimit;
        public Master master;

        private void OnEnable()
        {
            timeLimit = Time.time + master.stats.GetBoostTime;
            master.rigidbody2D.gravityScale = 0;
        }
        private void Update()
        {
            //Limite Boost
            if (timeLimit < Time.time)
            {
                //Quitar Boost
                master.SetActiveModeBoost(false);
            }

            //Comportamiento Bronya
        }
    }
}