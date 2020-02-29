using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDetection : MonoBehaviour
{
    public float radio = 1;
    public LayerMask layerMask;
    public RaycastHit2D[] hits;
    public Color colorDrawSphere = Color.red;

    public RaycastHit2D[] Get()
    {
        hits = Physics2D.CircleCastAll(transform.position, radio, Vector2.zero, 0, layerMask);
        return hits;
    }

    //[ExecuteInEditMode]
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = colorDrawSphere;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
