using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class EndlessSpawner : MonoBehaviour
{
    public static int enemiesAlive;

    public Transform enemyPrefab1;
    public Transform enemyPrefab2;
    public Transform enemyPrefab3;

    public Transform spawnPoint;
    public Vector3 spawnPosition;
    //public WaveSSS[] waves;

    private EnemyScript enemyscriptcompo1;
    private EnemyScript enemyscriptcompo2;
    private EnemyScript enemyscriptcompo3;


    public float spawnrate = 5.5f;
    private float countdown = 8f; //initial onli
    private int waveIndex = 1;
    public float difficultyindex = 1.15f;
    private float originalhealth = 100f;

    public TextMeshProUGUI waveCountdownText;

    private void Start()
    {
        enemyscriptcompo1 = enemyPrefab1.GetComponent<EnemyScript>();
        enemyscriptcompo1.starthealth = originalhealth;
        enemyscriptcompo2 = enemyPrefab2.GetComponent<EnemyScript>();
        enemyscriptcompo2.starthealth = originalhealth;
        enemyscriptcompo3 = enemyPrefab3.GetComponent<EnemyScript>();
        enemyscriptcompo3.starthealth = originalhealth;

        //waveIndex = 0;
    }

    void Update()
    {

       /* if (enemiesAlive > 0)
        {
            return;
        }*/

        if (countdown <= 0f)
        {
            StartCoroutine(spawnwave());
            countdown = spawnrate;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        //waveCountdownText.text = Mathf.Round(countdown).ToString();
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator spawnwave()
    {
        //Debug.Log("Wave Incoming");

        PlayerStatus.rounds++;

        //WaveSSS wave = waves[waveIndex];

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        enemyscriptcompo1.starthealth *= difficultyindex;
        enemyscriptcompo2.starthealth *= difficultyindex;
        enemyscriptcompo3.starthealth *= difficultyindex;

        waveIndex++;

        /*if (waveIndex == waves.Length)
        {
            this.enabled = false;
        }*/
    }

    void SpawnEnemy()
    {
        int delta = Random.Range(1, 4);
        if (delta == 1)
        {
            Instantiate(enemyPrefab1, spawnPoint.position + spawnPosition, spawnPoint.rotation);
        }
        if (delta == 2)
        {
            Instantiate(enemyPrefab2, spawnPoint.position + spawnPosition, spawnPoint.rotation);
        }
        if (delta >= 3)
        {
            Instantiate(enemyPrefab3, spawnPoint.position + spawnPosition, spawnPoint.rotation);
        }
        //Instantiate(enemy, spawnPoint.position + spawnPosition, spawnPoint.rotation);
        //enemiesAlive++;
    }

}
