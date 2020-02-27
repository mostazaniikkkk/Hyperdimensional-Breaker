using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bronya
{
    public class BHeal : MonoBehaviour
    {
        public LayerMask layerBronya;
        public float heal = 25f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & layerBronya) != 0)
            {
                collision.transform.root.GetComponent<Master>().stats.Heal(heal);
                Destroy(gameObject);
            }
        }
    }
}