using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenOptions()
    {
        // Show options UI (enable a panel, etc.)
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
