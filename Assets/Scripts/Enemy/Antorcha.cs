using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antorcha : MonoBehaviour
{

    public float radio = 10f;
    public float coolDownSpawn = 7;
    float time_coolDownSpawn = float.MinValue;
    public GameObject enemySpawn;

    private void Update()
    {
        if (CalcDistance < radio && time_coolDownSpawn <= Time.time)
        {
            time_coolDownSpawn = Time.time + coolDownSpawn;
            GameObject enemy = Instantiate(enemySpawn,transform.position, Quaternion.identity);
        }
    }

    float CalcDistance => Vector2.Distance(transform.position, Bronya.Master.instance.normal.transform.position);


}
