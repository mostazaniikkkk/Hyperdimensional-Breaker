using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBoost : MonoBehaviour
{
    public Bronya.Master master;
    public GameObject boostUI;
    public Text textValue;

    private void LateUpdate()
    {
        if (master.boost.timeLimit > Time.time)
        {
            boostUI.SetActive(true);

            textValue.text = ((int)((master.boost.timeLimit - Time.time) * 10)) / 10.0f + " seg";
        }
        else
        {
            boostUI.SetActive(false);
        }
    }
}
