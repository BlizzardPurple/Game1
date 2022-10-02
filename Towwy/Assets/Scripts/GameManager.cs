using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;
    public GameObject gameoverui;
    public TextMeshProUGUI deathMessage;

    private void Start()
    {
        gameEnded = false;
    }
    void Update()
    {
        if (gameEnded)
        {
            return;
        }
        if (PlayerStatus.Lives <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        //Debug.Log("GameOver!");
        gameEnded = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        deathMessage.text = "Surrendered";
        gameoverui.SetActive(true);
    }
}
