using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameoverscore : MonoBehaviour
{
    public TextMeshProUGUI wavessurvived;
    // Start is called before the first frame update
    void OnEnable ()
    {
        wavessurvived.text = PlayerStatus.rounds.ToString();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //can also use "level1"
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
