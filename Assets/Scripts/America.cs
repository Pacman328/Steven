using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class America : MonoBehaviour
{
    public float leftRightSpeed;
    public float upDownSpeed;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;

    private Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(up))
        {
            rb.velocity = new Vector2(0, upDownSpeed);
        }

        else
        {
           //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (Input.GetKey(down))
        {
            rb.velocity = new Vector2(0, -upDownSpeed);
        }

        else
        {
          // GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(leftRightSpeed, rb.velocity.y);
        }

        else
        {
          // GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (Input.GetKey(left))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-leftRightSpeed, rb.velocity.y);
        }

        else
        {
         // GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
