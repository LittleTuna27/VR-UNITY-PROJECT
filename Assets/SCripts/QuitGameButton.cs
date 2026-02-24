using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGameButton : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Game";

    private void OnTriggerEnter(Collider other)
    {
        QuitGame();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}