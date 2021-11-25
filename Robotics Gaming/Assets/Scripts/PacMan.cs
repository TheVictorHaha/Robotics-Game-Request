using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    public bool sideA;
    public bool upA;
    public int moveState;
    public float speed = 5f;
    List<GameObject> collisions = new List<GameObject>();
    public GameObject circ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkOptions();
        control();
        //align();
        move();
    }
    private void checkOptions()
    {
        sideA = false;
        upA = false;
        foreach(GameObject obj in collisions)
        {
            if (obj.CompareTag("Up")) upA = true;
            if (obj.CompareTag("Side")) sideA = true;
        }
    }
    private void control()
    {
        if (Input.GetKey(KeyCode.UpArrow) && upA) moveState = 1;
        if (Input.GetKey(KeyCode.RightArrow) && sideA) moveState = 2;
        if (Input.GetKey(KeyCode.DownArrow) && upA) moveState = 3;
        if (Input.GetKey(KeyCode.LeftArrow) && sideA) moveState = 4;
        if (!checkCurr())
        {
            moveState = 0;
            align();
            foreach (GameObject obje in collisions)
            {
                if (Input.GetKey(KeyCode.UpArrow) && obje.CompareTag("Up"))
                {
                    moveState = 1;
                    if (!checkCurr()) moveState = 0;
                }
                if (Input.GetKey(KeyCode.RightArrow) && obje.CompareTag("Side"))
                {
                    moveState = 2;
                    if (!checkCurr()) moveState = 0;
                }
                if (Input.GetKey(KeyCode.DownArrow) && obje.CompareTag("Up"))
                {
                    moveState = 3;
                    if (!checkCurr()) moveState = 0;
                }
                if (Input.GetKey(KeyCode.LeftArrow) && obje.CompareTag("Side"))
                {
                    moveState = 4;
                    if (!checkCurr()) moveState = 0;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisions.Add(collision.gameObject);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collisions.Remove(collision.gameObject);
    }
    private bool checkCurr()
    {
        float rad = GetComponent<CircleCollider2D>().radius;
        rad = speed * Time.deltaTime;
        rad = 0.05f;
        foreach(GameObject obj in collisions)
        {
            if(moveState == 1 && obj.CompareTag("Up"))
            {
                circ.transform.position = transform.position + rad * Vector3.up;
                if (obj.GetComponent<Collider2D>().bounds.Contains(transform.position + rad * Vector3.up)) return true;
            }
            if (moveState == 3 && obj.CompareTag("Up"))
            {
                circ.transform.position = transform.position + rad * Vector3.down;
                if (obj.GetComponent<Collider2D>().bounds.Contains(transform.position + rad * Vector3.down)) return true;
            }
            if (moveState == 2 && obj.CompareTag("Side"))
            {
                circ.transform.position = transform.position + rad * Vector3.right;
                if (obj.GetComponent<Collider2D>().bounds.Contains(transform.position + rad * Vector3.right)) return true;
            }
            if (moveState == 4 && obj.CompareTag("Side"))
            {
                circ.transform.position = transform.position + rad * Vector3.left;
                if (obj.GetComponent<Collider2D>().bounds.Contains(transform.position + rad * Vector3.left)) return true;
            }
        }
        return false;
    }
    private void move()
    {
        switch (moveState)
        {
            case 1:
                transform.Translate(Vector2.up * speed * Time.deltaTime);
                break;
            case 2:
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                break;
            case 3:
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                break;
            case 4:
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }
    private void align()
    {
        foreach(GameObject obj in collisions)
        {
            if (obj.CompareTag("Side")) transform.position = new Vector3(transform.position.x, obj.transform.position.y);
            if (obj.CompareTag("Up")) transform.position = new Vector3(obj.transform.position.x, transform.position.y);
        }
    }
}
