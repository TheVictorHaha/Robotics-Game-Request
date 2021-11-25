using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacEnemy : MonoBehaviour
{
    public GameObject bullet;
    PacManager script;

    // Start is called before the first frame update
    void Start()
    {
        script = GetComponent<PacManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot(Vector3 point)
    {
        // GameObject b = Instantiate(bullet);
        // script.bullets.Add(b);
        // b.transform.position = transform.position;
        Instantiate(bullet).transform.position = transform.position;
        bullet.GetComponent<PacBullet>().setPoint(point);
    }

    public void lookAt(Vector3 point)
    {
        foreach(Transform child in transform)
        {
            child.right = point - transform.position;
        }
    }
}
