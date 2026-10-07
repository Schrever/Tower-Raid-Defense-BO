using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    private SpriteRenderer sr;
    public Sprite newsprite;
    public HealthManager HealthManager;

    public float range = 3f;
    public float fireRate = 1f;
    public float fireRate2 = 1f;

    public GameObject projectilePrefab;
    public Transform firePoint;
    private float fireCooldown = 0f;
    public GameObject projectilePrefab2;
    public Transform firePoint2;
    public Transform firePoint3;


    public void FobChange()
    {
        sr.sprite = newsprite;
        HealthManager.swapvisibility();
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        CounterEnemy target = FindBestTarget();

        if (target != null && fireCooldown <= 0)
        {
            Shoot(target);
            fireCooldown = 1f / fireRate;
            Shoot2(target);
            fireCooldown = 1f / fireRate2;
            Shoot3(target);
            fireCooldown = 1f / fireRate2;
        }
    }

    CounterEnemy FindBestTarget()
    {
        CounterEnemy[] enemies = GameObject.FindObjectsOfType<CounterEnemy>();

        CounterEnemy best = null;
        float bestProgress = -1f;

        foreach (CounterEnemy e in enemies)
        {
            float dist = Vector2.Distance(transform.position, e.transform.position);

            if (dist <= range)
            {
                if (e.currentWayPoint > bestProgress)
                {
                    bestProgress = e.currentWayPoint;
                    best = e;
                }
            }
        }

        return best;
    }

    void Shoot(CounterEnemy target)
    {
        GameObject p = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        EProjectile pr = p.GetComponent<EProjectile>();
        pr.target = target.transform;
    }

    void Shoot2(CounterEnemy target)
    {
        GameObject p = Instantiate(projectilePrefab2, firePoint2.position, Quaternion.identity);
        EProjectile pr = p.GetComponent<EProjectile>();
        pr.target = target.transform;
    }

    void Shoot3(CounterEnemy target)
    {
        GameObject p = Instantiate(projectilePrefab2, firePoint3.position, Quaternion.identity);
        EProjectile pr = p.GetComponent<EProjectile>();
        pr.target = target.transform;
    }

    
}
