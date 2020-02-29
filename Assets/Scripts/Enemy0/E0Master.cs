using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyMaster0
{
    public class E0Master : MonoBehaviour
    {
        bool alert = false;
        float time_TimeLost = float.MinValue;
        [Min(1)] public float distanceDetection = 10;
        [Min(1)] public float maxTimeLost = 5;
        [Header("Components")]
        public Rigidbody2D rigid2D;
        public CapsuleCollider2D capCollider;

        

        private void Update()
        {
            if (Bronya.Master.instance == null) return;
            if (alert)
                Alert();
            else
                NoAlert();
        }

        void Alert()
        {
            Vector3 positionBronya = Bronya.Master.instance.normal.transform.position;

            //Quitar alerta o actualizarla
            if (Vector2.Distance(positionBronya, transform.position) > distanceDetection)
            {
                if (time_TimeLost < Time.time)
                {
                    alert = false;
                    return;
                }
            }
            else
            {
                UpdateTimeLost();
            }

            //Mirar
            Vector3 scale = transform.localScale;
            if (positionBronya.x - transform.position.x > 0)
            {
                if (scale.x < 0)
                {
                    scale.x = -scale.x;
                    transform.localScale = scale;
                }
            }
            else
            {
                if (scale.x > 0)
                {
                    scale.x = -scale.x;
                    transform.localScale = scale;
                }
            }

            //Ir hacia el enemygo o atacar

        }

        void NoAlert()
        {
            Vector3 positionBronya = Bronya.Master.instance.normal.transform.position;

            //Alertar
            if (Vector2.Distance(positionBronya, transform.position) <= distanceDetection)
            {
                alert = true;
                UpdateTimeLost();
                return;
            }

            //Quieto o moviendoce
        }

        void Move(Vector2 dir)
        {
            
        }

        #region Other Methods
        void UpdateTimeLost() => time_TimeLost = Time.time + maxTimeLost;
        #endregion
    }
}