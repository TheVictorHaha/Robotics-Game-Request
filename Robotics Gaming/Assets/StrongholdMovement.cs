using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongholdMovement : MonoBehaviour
{
    public float jumpForce = 100.0f;
    public float speed = 6.0f;
    public float grav = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player = GameObject.Find("Player");
        control();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if(collision.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            Debug.Log(gameObject.name);
        }
        grav = 1.0f;
    }

    private void control()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            grav = 1.0f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
