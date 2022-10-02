using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static int Money;
    public int StartMoney = 10;
    public static int Lives;
    public int StartLives = 5;
    public static int kills;
    public int StartKills = 0;
    public static int rounds;


    private void Start()
    {
        Money = StartMoney;
        Lives = StartLives;
        kills = StartKills;
        rounds = 0;
    }

}
