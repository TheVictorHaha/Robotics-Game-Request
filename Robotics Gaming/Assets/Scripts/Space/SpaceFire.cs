using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFire : MonoBehaviour
{
    GameObject manager;
    public int health = 10;
    public List<GameObject> lightnings;
    public GameObject lightning;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager");
        foreach(GameObject fire in manager.GetComponent<ManagerScriptSpace>().fires)
        {
            drawLightning(fire);
        }
        manager.GetComponent<ManagerScriptSpace>().fires.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            manager.GetComponent<ManagerScriptSpace>().fires.Remove(gameObject);
            for (int i = 0; i < lightnings.Count; i++)
            {
                if (lightnings[i] != null && lightnings[i].GetComponent<SpaceLightning>() != null)
                {
                    lightnings[i].gameObject.GetComponent<SpaceLightning>().sd();
                }
            } 
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        health--;
    }

    private void drawLightning(GameObject other)
    {
        GameObject obj = Instantiate(lightning);
        obj.transform.position = (other.transform.position + transform.position) * 0.5f;
        obj.transform.right = transform.position - obj.transform.position;
        obj.transform.localScale = new Vector3((transform.position - other.transform.position).magnitude / 10, obj.transform.localScale.y);
        obj.GetComponent<SpaceLightning>().setParents(gameObject, other);
        lightnings.Add(obj);
        other.GetComponent<SpaceFire>().lightnings.Add(obj);
    }
}
