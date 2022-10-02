using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneScript : MonoBehaviour
{
   public void Nextscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ShowCredits ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Quitgame()
    {
        Application.Quit();
    }
}
