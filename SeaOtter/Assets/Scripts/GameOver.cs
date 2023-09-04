using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Canvas GameOverScreen;

    private void Awake()
    {
        GameOverScreen.gameObject.SetActive(false);
    }

    public void ShowScreen()
    {
        GameOverScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}