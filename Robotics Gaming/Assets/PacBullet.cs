using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacBullet : MonoBehaviour
{
    public Vector3 point;
    public float speed = 2.5f;

    private bool oriented;
    private Vector3 dir;

    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        oriented = false;
        cam = Camera.main.gameObject;
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

        var upperLeftScreen = new Vector3(0, Screen.height);
        var upperRightScreen = new Vector3(Screen.width, Screen.height);
        var lowerLeftScreen = new Vector3(0, 0);
        var lowerRightScreen = new Vector3(Screen.width, 0);

        //Corner locations in world coordinates
        var upperLeft = cam.GetComponent<Camera>().ScreenToWorldPoint(upperLeftScreen);
        var upperRight = cam.GetComponent<Camera>().ScreenToWorldPoint(upperRightScreen);
        var lowerLeft = cam.GetComponent<Camera>().ScreenToWorldPoint(lowerLeftScreen);
        var lowerRight = cam.GetComponent<Camera>().ScreenToWorldPoint(lowerRightScreen);
        if (transform.position.y > upperRight.y || transform.position.y < lowerLeft.y) Destroy(gameObject);
        if (transform.position.x > upperRight.x || transform.position.x < upperLeft.x) Destroy(gameObject);
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
