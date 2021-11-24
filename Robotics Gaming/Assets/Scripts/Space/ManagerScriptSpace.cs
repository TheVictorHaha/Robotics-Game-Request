using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScriptSpace : MonoBehaviour
{
    public GameObject cam;
    public GameObject circ;
    // Start is called before the first frame update
    void Start()
    {
        if (!cam) cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            circ.transform.position = randPos();
        }
    }

    public Vector3 randPos()
    {
        var upperLeftScreen = new Vector3(0, Screen.height);
        var upperRightScreen = new Vector3(Screen.width, Screen.height);
        var lowerLeftScreen = new Vector3(0, 0);
        var lowerRightScreen = new Vector3(Screen.width, 0);

        //Corner locations in world coordinates
        var upperLeft = cam.GetComponent<Camera>().ScreenToWorldPoint(upperLeftScreen);
        var upperRight = cam.GetComponent<Camera>().ScreenToWorldPoint(upperRightScreen);
        var lowerLeft = cam.GetComponent<Camera>().ScreenToWorldPoint(lowerLeftScreen);
        var lowerRight = cam.GetComponent<Camera>().ScreenToWorldPoint(lowerRightScreen);

        return new Vector3(Random.Range(upperLeft.x, upperRight.x), Random.Range(upperLeft.y, lowerLeft.y));
    }
}
