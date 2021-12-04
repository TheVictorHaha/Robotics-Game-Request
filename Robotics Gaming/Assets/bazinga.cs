using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bazinga : MonoBehaviour
{
    public float lastTime;
    public float decelTime;
    public bool input;
    public bool decel;
    public float vel;
    public float top = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            input = true;
            vel = top;
        } else if (input)
        {
            input = false;
            decel = true;
            lastTime = Time.time;
        }
        if (decel)
        {
            float elapsed = Time.time - lastTime;
            if(elapsed >= decelTime)
            {
                vel = 0;
                decel = false;
            } else
            {
                vel = (1 - elapsed / decelTime) * top;
            }
        }
        transform.Translate(Vector2.right * vel * Time.deltaTime);
    }
}
