using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> bullets = new List<GameObject>();

    Camera camera;
    public float shootInt = 5.0f;
    public float lastShot = 0;

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
                if (script)
                {
                    script.shoot(player.transform.position);
                }
            }
            lastShot = Time.time;
        }
        // foreach (GameObject bullet in bullets){
        //     if (PointInCameraView(bullet.transform.position, camera)){
        //         Destroy(bullet, 0);
        //     }
        // }
    }

    public bool PointInCameraView(Vector3 point, Camera camera) {
         Vector3 viewport = camera.WorldToViewportPoint(point);
         bool inCameraFrustum = Is01(viewport.x) && Is01(viewport.y);
         bool inFrontOfCamera = viewport.z > 0;
 
         RaycastHit depthCheck;
         bool objectBlockingPoint = false;
 
         Vector3 directionBetween = point - camera.transform.position;
         directionBetween = directionBetween.normalized;
 
         float distance = Vector3.Distance(camera.transform.position, point);
 
         if(Physics.Raycast(camera.transform.position, directionBetween, out depthCheck, distance + 0.05f)) {
             if(depthCheck.point != point) {
                 objectBlockingPoint = true;
             }
         }
 
         return inCameraFrustum && inFrontOfCamera && !objectBlockingPoint;
     }

    public bool Is01(float a) {
         return a > 0 && a < 1;
     }
}
