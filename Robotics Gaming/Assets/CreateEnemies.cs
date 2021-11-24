using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public int numEnemies = 20;
    public GameObject enemy;
    
    SpriteRenderer sr;
    void Start()
    {   
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        float width = transform.localScale.x;
        float yPos = transform.position.y;
        float xPos = transform.position.x;
        float buffer = enemy.transform.localScale.x/2;
        width -= buffer*2;
        float dif = width/(numEnemies-1);

        List<GameObject> enemies = new List<GameObject>();

        Vector3 difVect = new Vector3(dif, 0, 0);
        Vector3 pos = new Vector3(xPos-width/2, yPos, 0);

        for (int i = 0; i < numEnemies; i++){
            GameObject go = Instantiate(enemy);
            go.transform.position = pos;
            pos += difVect;
            go.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
