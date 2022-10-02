using UnityEngine;
using TMPro;

public class bullet : MonoBehaviour
{
    private Transform target;
    private EnemyScript enemyscriptcomponent;
    public float speed = 70f;
    public float bullethit = 40f;
    private float bulletslowing = 0.9f;
    public GameObject Impacteffect;
    //private Vector3 dir;
    public int directionInt;
    public float explosionRadius = 0f;
    public bool isSlowing = false;

    //private int enemieskilled = 0;
    //public TextMeshProUGUI enemieskilledtext;
    public void Seek (Transform _target, int x)
    {
        target = _target;
        //dir = directionofturret(x);
        directionInt = x;
    }

    public Vector3 directionofturret (int x)
    {
        if (x == 0)
            return  target.position - transform.position;
        if (x == 1)
            return  transform.position - target.position;
        else return target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //Vector3 dir = target.position - transform.position;
        Vector3 dir = directionofturret (directionInt);
        

        float distanceThisframe = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisframe)
        {
            HitTarget();
            return;
        }

        transform.Translate (dir.normalized * distanceThisframe, Space.World);
        //transform.LookAt(target);
    }

    void HitTarget()
    {
        //Debug.Log("Hit");
        GameObject effectsinstance = (GameObject)Instantiate(Impacteffect, transform.position, transform.rotation);
        Destroy(effectsinstance, 2f);
        Destroy(gameObject);
        

        if (explosionRadius > 0f)
        {
            Explode();
        }else
        {
            Damage(target);
        }
        
        
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
           Debug.Log("Detected");
           if (collider.CompareTag("Enemy"))
            {
                Debug.Log("HP should go down");
                Damage(collider.transform);
            }
        }
    }
    void Damage (Transform enemy)
    {
        EnemyScript enemietta = enemy.GetComponent<EnemyScript>();
        enemietta.TakeDamage(bullethit);
        if(isSlowing && enemietta.speed > 8)
        {
            enemietta.speed *= bulletslowing;
        }
        //Destroy(enemy.gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
