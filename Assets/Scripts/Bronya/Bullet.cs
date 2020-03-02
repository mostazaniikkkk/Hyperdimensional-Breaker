using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] LayerMask myLayer = 0;
    [SerializeField] LayerMask damageLayer = 0;
    public float damage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((damageLayer & 1 << collision.gameObject.layer) != 0)
        {
            collision.gameObject.GetComponent<EnemyStats>()?.Damage(damage);
            collision.transform.root.gameObject.GetComponent<Bronya.Master>()?.stats.Damage(damage);
        }
        if ((myLayer & 1 << collision.gameObject.layer) == 0)
            Destroy(gameObject);
    }


    public void SetDamage(float _damage) => damage = _damage;
}
