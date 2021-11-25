using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDetect : MonoBehaviour
{
    public int maxJumps = 1;
    public int jumps;
    // Start is called before the first frame update
    void Start()
    {
        jumps = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Platform")
        {
            jumps = 1;
        }
    }
}
