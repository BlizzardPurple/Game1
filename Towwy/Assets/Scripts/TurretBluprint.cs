using UnityEngine;

[System.Serializable]
public class TurretBluprint
{
    public GameObject prefabofdefense;
    public GameObject godtierprefabofdefense;
    public int cost;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }

}
