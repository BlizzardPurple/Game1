using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    
    [Header("Unity Setup")]
    public Transform rotor;
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public Transform firepoint;
    public GameObject muzzleshotprefab;

    [Header ("Attributes")]
    public float range = 15f;
    public float turnSpeed = 10f;
    public float firerate = 1f;
    private float firecountdown = 0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f,0.5f);
    }

    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestdistance = Mathf.Infinity;
        GameObject nearestenemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            if (shortestdistance > distanceToEnemy)
            {
                nearestenemy = enemy;
                shortestdistance = distanceToEnemy;
            }
        }

        if (nearestenemy != null && shortestdistance <= range)
        {
            target = nearestenemy.transform;
            //Debug.Log("TargetUpdated");
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

        rotor.rotation = Quaternion.Euler (0f, rotation.y, 0f);

        if (firecountdown <= 0f)
        {
            Shoot();
            firecountdown = 1f / firerate;
        }

        firecountdown -= Time.deltaTime;
    }

    void Shoot ()
    {

        //Debug.Log("shoot");
        GameObject muzzleEffect = (GameObject)Instantiate(muzzleshotprefab, firepoint.position, firepoint.rotation);
        Destroy(muzzleEffect, 1f);

        GameObject Bulletgo = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation );
        bullet bullet = Bulletgo.GetComponent<bullet>();
        //Instantiate(muzzleshotprefab, firepoint.position, firepoint.rotation);

        if (bullet != null)
            bullet.Seek(target, 0);

    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
