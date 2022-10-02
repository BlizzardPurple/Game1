
using UnityEngine;

public class TripleTurret : MonoBehaviour
{
    private Transform target;

    [Header("Unity Setup")]
    public Transform rotor;
    private string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public Transform firepoint1;
    public Transform firepoint2;
    public Transform firepoint3;

    [Header("Attributes")]
    public float range = 15f;
    public float turnSpeed = 10f;
    public float firerate = 1f;
    private float firecountdown = 0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestdistance = Mathf.Infinity;
        GameObject nearestenemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (shortestdistance > distanceToEnemy)
            {
                nearestenemy = enemy;
                shortestdistance = distanceToEnemy;
            }
        }

        if (nearestenemy != null && shortestdistance <= range)
        {
            target = nearestenemy.transform;
        }
        else target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        // Barrel gonna move to target location here
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotor.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        rotor.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (firecountdown <= 0f)
        {
            Shoot();
            firecountdown = 1f / firerate;
        }

        firecountdown -= Time.deltaTime;
    }

    void Shoot()
    {

        //Debug.Log("shoot");
        GameObject Bulletgo1 = (GameObject)Instantiate(bulletPrefab, firepoint1.position, firepoint1.rotation);
        bullet bullet1 = Bulletgo1.GetComponent<bullet>();

        if (bullet1 != null)
            bullet1.Seek(target, 0);

        GameObject Bulletgo2 = (GameObject)Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
        bullet bullet2 = Bulletgo2.GetComponent<bullet>();

        if (bullet2 != null)
            bullet2.Seek(target, 0);

        GameObject Bulletgo3 = (GameObject)Instantiate(bulletPrefab, firepoint3.position, firepoint3.rotation);
        bullet bullet3 = Bulletgo3.GetComponent<bullet>();

        if (bullet3 != null)
            bullet3.Seek(target, 0);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
