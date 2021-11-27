using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLightning : MonoBehaviour
{
    GameObject parent1;
    GameObject parent2;
    bool instatiated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (instatiated && !(parent1 && parent2)) Destroy(gameObject);
    }

    public void sd()
    {
        if (instatiated)
        {
            parent1.GetComponent<SpaceFire>().lightnings.Remove(gameObject);
            parent2.GetComponent<SpaceFire>().lightnings.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public void setParents(GameObject p1, GameObject p2)
    {
        parent1 = p1;
        parent2 = p2;
        instatiated = true;
    }
}
