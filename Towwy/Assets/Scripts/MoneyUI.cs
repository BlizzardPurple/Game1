using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneydisplay;

    void Update()
    {
        moneydisplay.text = "$" + PlayerStatus.Money.ToString();
    }
}
