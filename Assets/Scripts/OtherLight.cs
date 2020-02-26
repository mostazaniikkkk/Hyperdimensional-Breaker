using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherLight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.root.GetComponent<Bronya.BLight>()?.AddLight(GetComponent<Light>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.root.GetComponent<Bronya.BLight>()?.RemoveLight(GetComponent<Light>());
    }
}
