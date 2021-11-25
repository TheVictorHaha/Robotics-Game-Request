using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBehavior : MonoBehaviour
{

    CreateEnemies enemiesScript;
    List<GameObject> enemies;
    GameObject target;

    public GameObject bullet;

    public float shotInterval = 5.0f;

    void Start() {
        target = GameObject.Find("Player");
    }

    void Update() {
        enemiesScript = GetComponent<CreateEnemies>();
        enemies = enemiesScript.enemies;
        shotInterval -= Time.deltaTime;
        foreach (GameObject enemy in enemies){
            look(enemy, target);
            if (shotInterval <= 0){
                foreach (GameObject enemy2 in enemies){
                    shoot(enemy2, target, 10f);
                    shotInterval = 5.0f;
                }
            }
        }
    }
    public void shoot(GameObject enemy, GameObject target, float speed){
        GameObject tb = Instantiate(bullet);
        tb.transform.SetParent(enemy.transform);
        tb.transform.position = enemy.transform.position;
        tb.transform.rotation = enemy.transform.rotation;
        tb.transform.Rotate(new Vector3(0,0,-90));
    }

    public void look(GameObject enemy, GameObject target){
        Vector3 dir = target.transform.position - enemy.transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
