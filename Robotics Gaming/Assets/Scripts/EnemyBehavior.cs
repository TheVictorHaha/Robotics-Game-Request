using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBehavior : MonoBehaviour
{
    // Update is called once per frame
    GameObject target;

    void Start() {
        target = GameObject.Find("Player");
    }
    void Update()
    {
        transform.LookAt(target.transform, transform.up);
    }
}
