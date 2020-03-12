using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

   // public GameObject goals;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GoalsRight")
        {
            Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity);
            if(GameController.instance.isScore == false && GameController.instance.EndMatch)
            {
                GameController.instance.number_GoalsLeft++;
            }
        }

        if (collision.gameObject.tag == "GoalsLeft")
        {
            Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity);
            if (GameController.instance.isScore == false && GameController.instance.EndMatch)
            {
                GameController.instance.number_GoalsRight++;
            }
        }
    }
    */
}
