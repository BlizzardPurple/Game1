using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LivesScript : MonoBehaviour
{
    public TextMeshProUGUI livesdisplay;

    void Update()
    {
        if (PlayerStatus.Lives > 1)
        livesdisplay.text = PlayerStatus.Lives.ToString() + " Lives";
        else
        livesdisplay.text = PlayerStatus.Lives.ToString() + " Life";
    }
}

