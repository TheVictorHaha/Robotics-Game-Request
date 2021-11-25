using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlevaniaMovement : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float speed = 5.0f;
    public float grav = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        control();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
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
        if (Input.GetKey(KeyCode.DownArrow))
        {
            grav += 0.1f;
        }
        GetComponent<Rigidbody2D>().gravityScale = grav;
    }
}
