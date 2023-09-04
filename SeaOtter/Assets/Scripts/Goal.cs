using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameOver GameOverScreen;

    private void OnTriggerEnter(Collider other)
    {
        GameOverScreen.ShowScreen();
    }
}