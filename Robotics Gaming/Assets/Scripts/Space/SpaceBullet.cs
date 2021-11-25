using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBullet : MonoBehaviour
{
    public Vector3 point;
    public float speed = 2.5f;
    public GameObject fire;

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
        Debug.Log(oriented);
        if (!oriented) {
            dir = point - transform.position;
            foreach (Transform child in transform)
            {
                child.transform.right = point - transform.position;
            }
            oriented = true;
        } else
        {
            Debug.Log("testes");
        }
        transform.Translate(dir.normalized * speed * Time.deltaTime);
        if ((point - transform.position).magnitude <= 0.01f)
        {
            GameObject f = Instantiate(fire);
            f.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    public void setPoint(Vector3 pt)
    {
        Debug.Log(pt);
        point = pt;
        Debug.Log(point);
    }
}
