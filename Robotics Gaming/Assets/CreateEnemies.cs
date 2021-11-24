using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public int numEnemies = 20;
    public GameObject enemy;
    Camera cam;

    void Start()
    {   
        cam = Camera.main;
        float height = 2f * cam.orthographicSize - 1;
        float width = height * cam.aspect - 1;
        float dif = width/(numEnemies-1);
        Debug.Log(width +  " " + height);

        List<GameObject> enemies = new List<GameObject>();

        Vector3 difVect = new Vector3(dif, 0, 0);
        Vector3 pos = new Vector3(-width/2, height/2, 0);

        for (int i = 0; i < numEnemies; i++){
            GameObject go = Instantiate(enemy);
            enemy.transform.position = pos;
            pos += difVect;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
