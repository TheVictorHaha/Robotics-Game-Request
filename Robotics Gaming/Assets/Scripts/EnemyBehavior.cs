using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBehavior : MonoBehaviour
{

    CreateEnemies enemiesScript;
    List<GameObject> enemies;
    GameObject target;

    public GameObject bullet;

    public float shotInterval = 3.0f;

    void Start() {
        target = GameObject.Find("Player");
    }

    void Update() {
        enemiesScript = GetComponent<CreateEnemies>();
        enemies = enemiesScript.enemies;
        float lastShot = 0.0f;
        foreach (GameObject enemy in enemies){
            look(enemy, target);
            if (Time.time - lastShot > shotInterval){
                Debug.Log("Time!");
                shoot(enemy, target);
                lastShot = Time.time;
            }
        }
    }
    public void shoot(GameObject enemy, GameObject target){
        GameObject tb = Instantiate(bullet);
        tb.transform.SetParent(enemy.transform);
        tb.layer = 10;
        tb.transform.position = enemy.transform.position;
        Vector3 dir = transform.forward;
        dir = dir.normalized;
    }

    public void look(GameObject enemy, GameObject target){
        Vector3 dir = target.transform.position - enemy.transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
