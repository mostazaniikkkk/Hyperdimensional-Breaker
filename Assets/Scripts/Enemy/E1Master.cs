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
    public DetectGround detectGround;

    [Header("Animation")]
    public Animator animator;
    public string parameterWalk = "Walk";
    public string parameterAlert = "Alert";
    public string parameterAttack = "Attack";

    [Header("Components")]
    public Rigidbody2D rigid2D;
    public CapsuleCollider2D capCollider;
    public SphereDetection detectionBronya;



    private void Update()
    {
        if (Bronya.Master.instance == null) return;
        animator.SetBool(parameterAlert, alert);
        if (alert)
            Alert();
        else
            NoAlert();
    }

    private void OnDrawGizmosSelected()
    {
        detectGround.Gizmo(transform, transform.localScale.x >= 0);
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
        RaycastHit2D[] hits = detectionBronya.Get();
        if (hits == null || hits.Length == 0)
        {
            Move(positionBronya);
        }
        else
        {
            if (Time.time > time_coolDown)
            {
                animator.SetTrigger(parameterAttack);
                foreach (RaycastHit2D hit in hits)
                {
                    hit.collider.transform.root.GetComponent<Bronya.Master>()?.stats.Damage(damage);
                }
                time_coolDown = Time.time + coolDown;
            }
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

        //Revisar terreno
        if (dirx != 0 && detectGround.Detect(transform, dirx > 0))
        {
            Vector2 vel = rigid2D.velocity;
            vel.x = dirx * velocity;
            rigid2D.velocity = vel;
            animator.SetBool(parameterWalk, true);
        }
        else
        {
            Vector2 vel = rigid2D.velocity;
            vel.x = 0;
            rigid2D.velocity = vel;
            animator.SetBool(parameterWalk, false);
        }

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

    #region Clases
    [System.Serializable]
    public class DetectGround
    {
        public LayerMask layerGround;
        public float distanceDetectGroundHorizontal = 0.3f;
        public float distanceDetectGroundVertical = 0.3f;
        public Vector2 offset = new Vector2(0, 0);

        public bool Detect(Transform transform, bool right)
        {
            Vector2 origin = (Vector2)transform.position + offset;
            Vector2 direction = right ? Vector2.right : Vector2.left;

            RaycastHit2D hit = Physics2D.Raycast(origin, direction, distanceDetectGroundHorizontal, layerGround);
            if (hit.collider != null) return false;

            origin = origin + direction * distanceDetectGroundHorizontal;
            direction = Vector2.down;

            hit = Physics2D.Raycast(origin, direction, distanceDetectGroundVertical, layerGround);
            if (hit.collider != null) return true;

            return false;
        }

        public void Gizmo(Transform transform, bool right)
        {
            Vector2 origin = (Vector2)transform.position + offset;
            Vector2 direction = right ? Vector2.right : Vector2.left;

            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(origin, origin + direction * distanceDetectGroundHorizontal);

            origin = origin + direction * distanceDetectGroundHorizontal;
            direction = Vector2.down;

            Gizmos.DrawLine(origin, origin + direction * distanceDetectGroundVertical);
        }
    }

    #endregion
}
