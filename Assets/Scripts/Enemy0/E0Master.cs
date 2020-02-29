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
            if (positionBronya.x - transform.position.x > 0)
            {
                //mirar derecha
            }
            else
            {
                //mirar izquierda
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

        #region Other Methods
        void UpdateTimeLost() => time_TimeLost = Time.time + maxTimeLost;
        #endregion
    }
}