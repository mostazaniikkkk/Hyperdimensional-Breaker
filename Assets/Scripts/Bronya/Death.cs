using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bronya
{
    public class Death : MonoBehaviour
    {
        public Master master;

        private void Start()
        {
            master.stats.Death += DeathAccion;
        }

        void DeathAccion()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}