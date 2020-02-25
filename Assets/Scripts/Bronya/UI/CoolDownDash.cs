using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bronya
{
    public class CoolDownDash : MonoBehaviour
    {
        public Bronya.Master master;
        public GameObject dashUI;
        public Text textValue;

        private void LateUpdate()
        {
            if (master.config.dash_auxTime > Time.time)
            {
                dashUI.SetActive(true);

                textValue.text = ((int)((master.config.dash_auxTime - Time.time)*10))/10.0f + " seg";
            }
            else
            {
                dashUI.SetActive(false);
            }
        }
    }
}