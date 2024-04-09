using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacelController : MonoBehaviour
{
    float speed;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.ScoreTimer <= 10)                                               //Obstacle 0...
        {
            speed = 2;
        }

        if(GameManager.Instance.ScoreTimer > 10 && GameManager.Instance.ScoreTimer <= 13)
        {
            speed = 2.25f;
        }

        if (GameManager.Instance.ScoreTimer > 13 && GameManager.Instance.ScoreTimer <= 16)      //Mid 0...
        {
            speed = 2.5f;
        }

        if (GameManager.Instance.ScoreTimer > 16 && GameManager.Instance.ScoreTimer <= 19)
        {
            speed = 2.75f;
        }
                                                                                            
        if (GameManager.Instance.ScoreTimer > 19 && GameManager.Instance.ScoreTimer <= 29)      //Obstacle 1...
        {
            speed = 3;
        }

        if (GameManager.Instance.ScoreTimer > 29 && GameManager.Instance.ScoreTimer <= 32)
        {
            speed = 3.25f;
        }

        if (GameManager.Instance.ScoreTimer > 32 && GameManager.Instance.ScoreTimer <= 35)      //Mid 1...
        {
            speed = 3.5f;
        }

        if (GameManager.Instance.ScoreTimer > 35 && GameManager.Instance.ScoreTimer <= 38)
        {
            speed = 3.75f;
        }
        
        if (GameManager.Instance.ScoreTimer > 38 && GameManager.Instance.ScoreTimer <= 48)      //Obstacle 2...
        {
            speed = 4;
        }

        if (GameManager.Instance.ScoreTimer > 48 && GameManager.Instance.ScoreTimer <= 51)
        {
            speed = 4.25f;
        }

        if (GameManager.Instance.ScoreTimer > 51 && GameManager.Instance.ScoreTimer <= 54)      //Mid 2...
        {
            speed = 4.5f;
        }

        if (GameManager.Instance.ScoreTimer > 54 && GameManager.Instance.ScoreTimer <= 57)
        {
            speed = 4.75f;
        }
        
        if (GameManager.Instance.ScoreTimer > 57)                                               //Obstacle 3...
        {
            speed = 5;
        }

        if (GameManager.Instance.IsGameOver==false  && GameManager.Instance.GameIsStarted)     //In this condition game over is "FALSE" then>>>
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }
}