using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject ObstacelsPrefab;
    public GameObject ObstacelsPrefab1;
    public GameObject ObstacelsPrefab2;
    public GameObject ObstacelsPrefab3;
    public GameObject PlayerAnimation;
    public GameObject GroundPrefab;
    public GameObject TapImg;
    public GameObject UpperBorderLine;
    GameObject OGO;
    GameObject GGO;

    public float ScoreTimer = 0;
    public float Timer;
    public bool IsGameOver = false;
    public static float Highscore;
    public float HighScore;
    public bool GameIsStarted;
    
    // Awake is called refer to data in other scripts
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetHighScore();     //In GameManager line number 120<<<
        GameIsStarted = false;
        HighScore = Highscore;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gm= Instantiate(UpperBorderLine, new Vector3(-0.1721f, 5.2201f, 0), Quaternion.identity);
        PlayerAnimation.GetComponent<Animator>().enabled = false;       //This statement to turn off the player Animatio before start the game...

        if (!GameIsStarted && Input.GetMouseButtonDown(0))      //In this condition if game is not started condition is "FALSE" and you clicke on mouse button then>>>
        {
            PlayerController.Instance.Rb.gravityScale = 0;
            GameIsStarted = true;
        }

        if (GameIsStarted && IsGameOver==false)     //In this condition if game is started condition is "True" and game is over condition is "FALSE" then>>>
        {
            TapImg.SetActive(false);
            PlayerAnimation.GetComponent<Animator>().enabled = true;
            PlayerController.Instance.Rb.gravityScale = 1;
            ScoreTimer += Time.deltaTime;
            GameplayScripts.Instance.ScoreTimeTextUpdate();      //In GameplayScripts line number 54<<<
            
            if (Timer <= 0)     //In this condition Timer less than equle to 0 then Obstacles are instantite on particular scale and position>>>
            {
                Time.timeScale = 1;

                if(ScoreTimer <= 16)
                {
                    OGO = Instantiate(ObstacelsPrefab, new Vector3(0, Random.Range(2.5f, -1.5f), 0), Quaternion.identity);
                    GGO=Instantiate(GroundPrefab, new Vector3(15.14f, -4.08f, 0), Quaternion.identity);
                }

                if (ScoreTimer>16 && ScoreTimer <= 36)
                {
                    OGO = Instantiate(ObstacelsPrefab1, new Vector3(0, Random.Range(2f, -1f), 0), Quaternion.identity);
                    GGO = Instantiate(GroundPrefab, new Vector3(15.14f, -4.08f, 0), Quaternion.identity);
                }

                if (ScoreTimer > 36 && ScoreTimer <= 56)
                {
                    OGO = Instantiate(ObstacelsPrefab2, new Vector3(0, Random.Range(1.75f, -0.75f), 0), Quaternion.identity);
                    GGO = Instantiate(GroundPrefab, new Vector3(15.14f, -4.08f, 0), Quaternion.identity);
                }

                if (ScoreTimer > 56)
                {
                    OGO = Instantiate(ObstacelsPrefab3, new Vector3(0, Random.Range(1.5f, -0.5f), 0), Quaternion.identity);
                    GGO = Instantiate(GroundPrefab, new Vector3(15.14f, -4.08f, 0), Quaternion.identity);
                }

                Destroy(OGO, 5);     //Distroy the Obstacles in 5 sec after instantiate...
                Destroy(GGO, 12);
                Timer = 2;
            }
            else
            {
                Timer -= Time.deltaTime;
            }
            
        }

        if (IsGameOver == true)     // In this condition game is over then>>>
        {
            GameplayScripts.Instance.GameOver();        //In GameplayScripts line number 37<<<

            if (ScoreTimer > Highscore)
            {
                //Game Over!!!
                Highscore = ScoreTimer;
                SaveHighScore();        //In GameManager line 115<<<
                Destroy(gm);
            }

        }

        if (Highscore == 0 || ScoreTimer > HighScore)       //In this condition manage the Highscore>>>
        {
            HighScore = ScoreTimer;
        }
        else
        {
            HighScore = Highscore;
        }

    }

    public void SaveHighScore()     //In this function save Highscore data in a Cache memory>>>
    {
        PlayerPrefs.SetFloat("HighScore", HighScore);
    }

    public void GetHighScore()      //In this function get Highscore data in a Cache memory>>>
    {
        Highscore = PlayerPrefs.GetFloat("HighScore");
    }
    
}