using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public LayerMask layerBronya;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1<<collision.gameObject.layer) & layerBronya) != 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
