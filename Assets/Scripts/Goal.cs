using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    //public Text variable
    public Text scoreText; 
    //score that updates
    int score;
    void Start()
    {
        int score = 0;
        //both player's scores start as 0 
        scoreText.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   //attach script to goal to detect goals 
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        //check to see if ball and goal collided
        if (otherObject.gameObject.tag == "Ball")
        {
            //add +1 to player1's score 
            score++;
            //update score diaplay
            scoreText.text = "" + score;
            //once a goal is made reset players and ball to middle of field 
        }
    }
}
