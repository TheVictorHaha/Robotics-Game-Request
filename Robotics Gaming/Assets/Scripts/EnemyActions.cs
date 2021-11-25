using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{   
    GameObject target; 
    EnemyBehavior eb;
    CreateEnemies enemiesScript;
    List<GameObject> enemies;

    void Start() {
        target = GameObject.Find("Player");
        eb = GetComponent<EnemyBehavior>();
        enemiesScript = GetComponent<CreateEnemies>();
        enemies = enemiesScript.enemies;
    }
    void Update() {
        foreach (GameObject enemy in enemies){
            eb.LookAt(enemy, target);
        }
    }
}
