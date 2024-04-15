using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameplayScripts : MonoBehaviour
{
    public static GameplayScripts Instance;
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public Button PauseBtn;
    public TextMeshProUGUI ScoreTimeUpdate;
    public TextMeshProUGUI GOScoreTimeUpdate;
    public TextMeshProUGUI HighScoreUpdate;
    public AudioSource GameAudio;

    public bool IsPausePanelOn = false;

    // Awake is called refer to data in other scripts
    private void Awake()
    {
        Instance = this;
    }
    
    public void PauseBtnClicked()       //In this function if you clicke on Pause button then>>>
    {
        PausePanel.SetActive(true);
        GameOverPanel.SetActive(false);
        Time.timeScale = 0 ;
        IsPausePanelOn = true;
    }

    public void ResumeBtnCLicked()      //In this function if you clicke on Resume button then>>>
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        IsPausePanelOn = false;
    }

    public void GameOver()      //In this function game is over>>>
    {
        GameAudio.Stop();
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        PauseBtn.interactable = false;
    }

    public void ReplayBtnClicked()      //In this function you clicke on Replay button then>>>
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuBtnClicked()        //In this function you clicke on MainMenu Button then>>>
    {
        SceneManager.LoadScene(0);
    }

    public void ScoreTimeTextUpdate()       //In this function manage Score time text>>>
    {
        ScoreTimeUpdate.text = ("TIME: ") + GameManager.Instance.ScoreTimer.ToString("00000.00");
        GOScoreTimeUpdate.text = ("TIME: ") + GameManager.Instance.ScoreTimer.ToString("0.00");
        HighScoreUpdate.text = ("HIGHSCORE: ") + GameManager.Instance.HighScore.ToString("0.00");
    }

    public void GameBackgroundSound()
    {
        GameAudio.Play();
    }

}