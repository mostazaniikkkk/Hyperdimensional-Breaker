using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 50;
    float health = 1;

    private void Awake()
    {
        health = maxHealth;
    }

    public void Damage(float cant)
    {
        health -= cant;
        if (health <= 0) Destroy(gameObject);
    }


}
