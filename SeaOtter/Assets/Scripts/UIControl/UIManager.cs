using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button Button_Start;
    public Button Button_HowToPlay;
    public Button Button_Credit;
    public Button Button_Exit;
    public GameObject CreditPanel;
    public GameObject HowToPlayPanel;

    public void SceneChange()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HowToPlayButton()
    {
        HowToPlayPanel.SetActive(true);
    }

    public void CreditButton()
    {
        CreditPanel.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void CreditBackButton()
    {
        CreditPanel.SetActive(false);
    }
    public void HowToPlayBackButton()
    {
        HowToPlayPanel.SetActive(false);
    }
}
