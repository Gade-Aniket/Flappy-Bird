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
    GameObject MGO;

    float timer;
    public bool Okay = false;

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
        Okay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            MGO = Instantiate(Mountains, new Vector3(12f, -5f, 0), Quaternion.identity);
            timer = 5;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        Destroy(MGO, 12);
    }

    public void PlayBtnClicked()        //In this function if you clicke on Play button then>>>
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void SettingsBtnClicked()        //In this function if you clicke on Setting button then>>>
    {
        SettingsPanel.SetActive(true);
    }

    public void HowToPlayBtnClicked()        //In this function if you clicke on HowToPlay button then>>>
    {
        MainMenuPanel.SetActive(false);
        HowToPlayPanel.SetActive(true);
    }

    public void CreditsBtnClicked()        //In this function if you clicke on Credits button then>>>
    {
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void BackBtnClicked()        //In this function if you clicke on Back button then>>>
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        HowToPlayPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

}