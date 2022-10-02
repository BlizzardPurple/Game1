using System.Collections;
using UnityEngine;

public class DoubleTurret : MonoBehaviour
{
    private Transform target;

    [Header("Unity Setup")]
    public Transform rotor;
    private string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public Transform firepointf;
    public Transform firepointb;

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
        Vector3 dirF = target.position - transform.position;
        //Vector3 dirB = transform.position - target.position;
        Quaternion lookRotation = Quaternion.LookRotation(dirF);
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
        GameObject BulletgoF = (GameObject)Instantiate(bulletPrefab, firepointf.position, firepointf.rotation);
        bullet bulletf = BulletgoF.GetComponent<bullet>();

        GameObject BulletgoB = (GameObject)Instantiate(bulletPrefab, firepointb.position, firepointb.rotation);
        bullet bulletb = BulletgoB.GetComponent<bullet>();


        if (bulletf != null)
            bulletf.Seek(target,0);

        if (bulletb != null)
            bulletb.Seek(target,1);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}