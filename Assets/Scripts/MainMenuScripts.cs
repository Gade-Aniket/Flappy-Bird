using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    public static MainMenuScripts Instance;
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;
    public GameObject HowToPlayPanel;
    public GameObject CreditsPanel;
    public GameObject Mountains;
    public GameObject Clouds;
    public AudioSource GameAudio;
    public AudioClip ButtonAudioClip;
    GameObject MountainGameObject;
    GameObject CloudeGameObject;

    float M_Timer;
    float C_Timer;
    //public bool Okay = false;

    // Awake is called refer to data in other scripts
    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update and MainMenu auto start>>>
    void Start()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        HowToPlayPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        //Okay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (M_Timer <= 0)
        {
            MountainGameObject = Instantiate(Mountains, new Vector3(12f, -5f, 0), Quaternion.identity);
            M_Timer = 5;
        }
        else
        {
            M_Timer -= Time.deltaTime;
        }

        if (C_Timer <= 0)
        {
            CloudeGameObject = Instantiate(Clouds, new Vector3(-1f, -3f, 0), Quaternion.identity);
            C_Timer = 12;
        }
        else
        {
            C_Timer -= Time.deltaTime;
        }

        Destroy(MountainGameObject, 12);
        Destroy(CloudeGameObject, 15);
    }

    public void PlayBtnClicked()        //In this function if you clicke on Play button then>>>
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        PlayButtonSound();
    }

    public void SettingsBtnClicked()        //In this function if you clicke on Setting button then>>>
    {
        SettingsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PlayButtonSound();
    }

    public void HowToPlayBtnClicked()        //In this function if you clicke on HowToPlay button then>>>
    {
        MainMenuPanel.SetActive(false);
        HowToPlayPanel.SetActive(true);
        PlayButtonSound();
    }

    public void CreditsBtnClicked()        //In this function if you clicke on Credits button then>>>
    {
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
        PlayButtonSound();
    }

    public void BackBtnClicked()        //In this function if you clicke on Back button then>>>
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        HowToPlayPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        PlayButtonSound();
    }

    public void DeleteHighScoreBtnClicked()
    {
        GameManager.Instance.DeleteHighScore();
    }

    public void QuitBtnClicked()
    {
        Application.Quit();
    }

    public void GameBackgroundAudio()
    {
        GameAudio.Play();
    }

    public void PlayButtonSound()
    {
        GameAudio.PlayOneShot(ButtonAudioClip);
    }

}