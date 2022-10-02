using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;
    public float starthealth = 100f;
    public float health;
    public GameObject deathEffect;
    //public TextMeshProUGUI killsdisplay;
    [Header("Do Not Touch")]
    public Image healthBar;

    void Start()
    {
        target = Waypoints.points[0];
        health = starthealth;
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            Getnextwaypoint();
            transform.LookAt(target.position);
        }

        //killsdisplay.text = PlayerStatus.kills.ToString() + "kills";
    }

    void Getnextwaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void TakeDamage(float amount)
    {
        healthBar.fillAmount = health / starthealth;

        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
        GameObject turretbuildeffect = (GameObject)Instantiate(deathEffect, gameObject.transform.position , Quaternion.identity);
        Destroy(gameObject);
        Destroy(turretbuildeffect, 1.5f);
        PlayerStatus.Money += 3;
        Spawner.enemiesAlive--;
    }

    void EndPath()
    {
        Destroy(gameObject);
        if (PlayerStatus.Lives >= 0)
        {
            PlayerStatus.Lives--;
        }
        Spawner.enemiesAlive--;
    }
}
