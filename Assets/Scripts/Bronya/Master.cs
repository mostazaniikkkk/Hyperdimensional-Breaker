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

        //singleton
        public static Master instance;

        protected void Awake()
        {
            SetActiveModeBoost(false);
            if (instance == null)
                Debug.LogWarning("Hay 2 Master de Bronya.");
            instance = this;
        }

        private void OnDestroy()
        {
            if (instance == this) instance = null;
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