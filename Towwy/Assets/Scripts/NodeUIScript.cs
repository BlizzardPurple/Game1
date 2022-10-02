using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUIScript : MonoBehaviour
{
    private Node targetnode;
    public GameObject ui;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellCost;
    public Button upgradeButton;

    public void SetTarget(Node selectednode)
    {
        targetnode = selectednode;
        transform.position = targetnode.GetBuildPosition();

        if(targetnode.turretLevel <= 2)
        {
            upgradeCost.text = "Upgrade\n$" + targetnode.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Maxed";
            upgradeButton.interactable = false;
        }

        sellCost.text = "Sell\n$" + targetnode.turretBlueprint.GetSellAmount();
        //upgradeCost.text = "Upgrade\n$" + targetnode.turretBlueprint.upgradeCost;

        ui.SetActive(true);
    }
    public void Hideui()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
       targetnode.UpgradeTurret();
        BuildManager.instance.deselectnode();
    }
    public void Sell()
    {
        targetnode.SellTurret();
        BuildManager.instance.deselectnode();
    }
}
