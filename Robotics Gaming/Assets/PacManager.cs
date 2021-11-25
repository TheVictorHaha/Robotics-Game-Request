using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> bullets = new List<GameObject>();

    Camera camera;
    public float shootInt = 5.0f;
    float lastShot = 0;

    public float fireProbability = 0.25f;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject enemy in enemies)
        {
            PacEnemy script = enemy.GetComponent<PacEnemy>();
            Debug.Log(enemy.transform.position);
            script.lookAt(player.transform.position);
        }
        if (Time.time - lastShot > shootInt)
        {
            foreach(GameObject enemy in enemies)
            {
                PacEnemy script = enemy.GetComponent<PacEnemy>();
                Debug.Log(lastShot + ", " + Time.time);
                if (Random.value <= fireProbability)
                {
                    script.shoot(player.transform.position);
                }
            }
            lastShot = Time.time;
        }
    }
}
