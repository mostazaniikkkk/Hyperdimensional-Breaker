using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Master : MonoBehaviour
{
    bool alert = false;
    bool grounded = false;
    float time_TimeLost = float.MinValue;
    float time_coolDown = float.MinValue;

    [Min(1)] public float distanceDetection = 10;
    [Min(1)] public float maxTimeLost = 5;
    [Min(1)] public float damage = 20;
    [Min(1)] public float coolDown = 1;
    [Min(0.1f)] public float velocity;
    public Vector2 distanciaBronya = new Vector2(4, 2);
    

    [Header("Animation")]
    public Animator animator;
    public string parameterAttack = "Attack";

    [Header("Components")]
    public Rigidbody2D rigid2D;
    public CapsuleCollider2D capCollider;



    private void Update()
    {
        if (Bronya.Master.instance == null) return;
        if (alert)
            Alert();
        else
            NoAlert();
    }


    void Alert()
    {
        Vector3 positionBronya = Bronya.Master.instance.normal.transform.position;

        //Quitar alerta o actualizarla
        if (Vector2.Distance(positionBronya, transform.position) > distanceDetection)
        {
            if (time_TimeLost < Time.time)
            {
                alert = false;
                return;
            }
        }
        else
        {
            UpdateTimeLost();
        }

        //Mirar
        Vector3 scale = transform.localScale;
        if (positionBronya.x - transform.position.x > 0)
        {
            if (scale.x < 0)
            {
                scale.x = -scale.x;
                transform.localScale = scale;
            }
        }
        else
        {
            if (scale.x > 0)
            {
                scale.x = -scale.x;
                transform.localScale = scale;
            }
        }

        //Ir hacia el enemygo o atacar
        Move(positionBronya);

        //Atacar
        if (Time.time > time_coolDown)
        {
            animator.SetTrigger(parameterAttack);
            time_coolDown = Time.time + coolDown;
            Attack(positionBronya);
        }
        

    }

    void NoAlert()
    {
        Vector3 positionBronya = Bronya.Master.instance.normal.transform.position;

        //Alertar
        if (Vector2.Distance(positionBronya, transform.position) <= distanceDetection)
        {
            alert = true;
            UpdateTimeLost();
            return;
        }

        //Quieto o moviendoce
    }

    void Move(Vector2 obj)
    {
        float dirx = (obj - (Vector2)transform.position).x;
        NormalizeFloat(ref dirx);

        //Mirar
        Vector3 scale = transform.localScale;
        if (dirx > 0)
        {
            if (scale.x < 0)
            {
                scale.x = -scale.x;
                transform.localScale = scale;
            }
        }
        else
        {
            if (scale.x > 0)
            {
                scale.x = -scale.x;
                transform.localScale = scale;
            }
        }

        //Moverse
        Vector2 fPos = new Vector2(obj.x, obj.y);
        Vector2 iPos = transform.position;

        fPos.y += distanciaBronya.y;

        if (dirx >= 0)
            fPos.x -= distanciaBronya.x;
        else
            fPos.x += distanciaBronya.x;

        Vector2 dir = fPos - iPos;
        dir.Normalize();

        rigid2D.velocity = dir * velocity;







    }

    void Attack(Vector2 position)
    {

    }

    #region Other Methods
    void UpdateTimeLost() => time_TimeLost = Time.time + maxTimeLost;
    void NormalizeFloat(ref float x)
    {
        if (x > 0f) x = 1;
        else if (x < 0f) x = -1;
        else x = 0;
    }
    #endregion

}
