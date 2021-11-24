using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
    private Vector3 speedVector;
    public float speed = 0.01f;
    public float maxSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        speedVector = new Vector3(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        control();
        transform.position += speedVector * Time.deltaTime;
    }

    void control()
    {
        bool input = false;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (speedVector.y < maxSpeed)
            {
                speedVector += Vector3.up * speed;
            }
            input = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (speedVector.x < maxSpeed)
            {
                speedVector += Vector3.right * speed;
            }
            input = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (speedVector.x > -maxSpeed)
            {
                speedVector += Vector3.left * speed;
            }
            input = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (speedVector.y > -maxSpeed)
            {
                speedVector += Vector3.down * speed;
            }
            input = true;
        }
        if (!input)
        {
<<<<<<< Updated upstream
            speedVector *= (1 - speed / 100);
            if (speedVector.magnitude <= 0.1) speedVector = new Vector3(0, 0);
=======
            speedVector *= (1 - speed / 10);
            if (speedVector.magnitude <= 0.01) speedVector = new Vector3(0, 0);
>>>>>>> Stashed changes
        }
    }
}
