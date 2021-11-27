using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScriptSpace : MonoBehaviour
{
    public GameObject cam;
    public List<GameObject> fires;
    public GameObject lightning;
    // Start is called before the first frame update
    void Start()
    {
        if (!cam) cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 randPos()
    {
        var upperLeftScreen = new Vector3(0, Screen.height * 3 / 4);
        var upperRightScreen = new Vector3(Screen.width, Screen.height * 3 / 4);
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
