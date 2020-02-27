using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bronya
{

    public class Master : MonoBehaviour
    {
        //public BoxCollider2D boxCollider;
        public CapsuleCollider2D capCollider;
        public Rigidbody2D rigidbody2D;
        public Normal normal;
        public Boost boost;
        public Stats stats;
        public Config config;
        public BAttack attack;

        protected void Awake()
        {
            SetActiveModeBoost(false);
        }

        private void Update()
        {
            
        }

        #region Methods
        public void SetActiveModeBoost(bool setActiveBoost)
        {
            if (setActiveBoost)
            {
                normal.gameObject.SetActive(false);
                boost.gameObject.SetActive(true);
            }
            else
            {
                boost.gameObject.SetActive(false);
                normal.gameObject.SetActive(true);
            }
        }
        #endregion

    }

}