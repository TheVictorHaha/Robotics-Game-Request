using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
    private Vector3 speedVector;
    public float speed = 0.01f;
    public float maxSpeed = 5.0f;

    public ParticleSystem pSys;
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
        float ang = 0;
        float count = 0;
        bool input = false;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (speedVector.y < maxSpeed)
            {
                speedVector += Vector3.up * speed;
            }
            ang += (90);
            count++;
            input = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (speedVector.x < maxSpeed)
            {
                speedVector += Vector3.right * speed;
            }
            ang += (0);
            count++;
            input = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (speedVector.x > -maxSpeed)
            {
                speedVector += Vector3.left * speed;
            }
            ang += (180);
            count++;
            input = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (speedVector.y > -maxSpeed)
            {
                speedVector += Vector3.down * speed;
            }
            ang += (-90);
            count++;
            input = true;
        }
        if(count > 0) setRot(ang / count);
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)) setRot(225);
        if (!input)
        {
            var e = pSys.emission;
            e.enabled = false;
            speedVector *= (1 - speed / 10);
            if (speedVector.magnitude <= 0.01) speedVector = new Vector3(0, 0);
        } else
        {
            var e = pSys.emission;
            e.enabled = true;
        }
    }

    public void setRot(float degrees)
    {
        foreach(Transform child in transform)
        {
            child.eulerAngles = new Vector3(0, 0, degrees);
        }
    }
}
