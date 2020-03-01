using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] LayerMask damageLayer = 0;
    public float damage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<EnemyStats>()?.Damage(damage);
        Destroy(gameObject);
    }


    public void SetDamage(float _damage) => damage = _damage;
}
