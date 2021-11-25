using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacBullet : MonoBehaviour
{
    public Vector3 point;
    public float speed = 2.5f;

    private bool oriented;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        oriented = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!oriented)
        {
            dir = point - transform.position;
            foreach (Transform child in transform)
            {
                child.transform.right = point - transform.position;
            }
            oriented = true;
        }
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }

    public void setPoint(Vector3 pt)
    {
        Debug.Log(pt);
        point = pt;
        Debug.Log(point);
    }

    public void setSpeed(float sp)
    {
        speed = sp;
    }
}
