using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemy : MonoBehaviour
{
    GameObject manager;
    public float shotInt = 5.0f;
    public float lastShot = 0;
    public GameObject bullet;
    public GameObject circle;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastShot > shotInt)
        {
            Vector3 pos = manager.GetComponent<ManagerScriptSpace>().randPos();
            Debug.Log(pos);
            shoot(pos);
            lastShot = Time.time;
        }
    }
    void shoot(Vector3 point)
    {
        Instantiate(bullet).transform.position = transform.position;
        bullet.GetComponent<SpaceBullet>().setPoint(point);
    }
}
