using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bronya
{
    public class Stats : MonoBehaviour
    {
        #region Delegado
        public delegate void Event();

        public Event Death;
        #endregion

        #region Variables
        [SerializeField] private float Health = 100;
        [SerializeField] private float Health_Max = 100;

        [SerializeField] private float Boost = 0;
        [SerializeField] private float Boost_Max = 100;
        [SerializeField] private float Boost_Time = 5f;
        #endregion

        

        #region Methods
        #region Health
        public void Heal(float cant)
        {
            Health += cant;
            if (Health > Health_Max) Health = Health_Max;
        }

        public void Damage(float cant)
        {
            Health -= cant;
            if (Health <= 0)
            {
                Health = 0;
                Death?.Invoke();
            }
        }

        public float GetHealth => Health;
        #endregion
        #region Boost
        public bool BoostReady => Boost >= Boost_Max;

        public void IncreaseBoost(float cant)
        {
            Boost += cant;
            if (Boost >= Boost_Max) Boost = Boost_Max;
        }

        public void UseBoost()
        {
            Boost = 0f;
        }

        public float GetBoostTime => Boost_Time;
        #endregion
        #endregion
    }
}