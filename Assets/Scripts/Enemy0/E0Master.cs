using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyMaster0
{
    public class E0Master : MonoBehaviour
    {
        bool alert = false;
        [Min(1)] public float distanceDetection = 10;
        [Min(1)] public float maxTimeLost = 5;
        [Header("Components")]
        public Rigidbody2D rigid2D;
        public CapsuleCollider2D capCollider;

        private void Update()
        {
            
        }
    }
}