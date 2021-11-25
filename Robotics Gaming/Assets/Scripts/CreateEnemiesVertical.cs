using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemiesVertical : MonoBehaviour
{

    public int numEnemies = 20;
    public GameObject enemy;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        float height = transform.localScale.x;
        float yPos = transform.position.y;
        float xPos = transform.position.x;
        float buffer = enemy.transform.localScale.y/2;
        height -= buffer*2;
        float dif = height/(numEnemies-1);
        Vector3 difVect = new Vector3(0, dif, 0);
        Vector3 pos = new Vector3(xPos, yPos-height/2, 0);

        for (int i = 0; i < numEnemies; i++){
            GameObject go = Instantiate(enemy);
            go.transform.position = pos;
            pos += difVect;
            // go.transform.parent = gameObject.transform;
            GameObject.Find("Manager").GetComponent<PacManager>().enemies.Add(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
