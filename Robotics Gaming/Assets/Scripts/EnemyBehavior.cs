using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBehavior : MonoBehaviour
{
    public void shoot(){
        Vector3 dir = transform.forward;
        dir = dir.normalized;
    }

    public void LookAt(GameObject enemy, GameObject target){
        Vector3 dir = target.transform.position - enemy.transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
