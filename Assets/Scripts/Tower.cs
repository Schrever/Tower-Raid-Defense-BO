using UnityEngine;

[System.Serializable]
public class TowerUpgradeStage
{
    public float range;
    public float fireRate;
    public Sprite sprite;
    public int price;
    public int sellprice;
    public GameObject projectilePrefab;

    public int visibleDmg;

}

public class Tower : MonoBehaviour
{
    public string TowerName;
    public float range = 3f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    public TowerUpgradeStage[] upgradeStages;
    public int upgradeStage = 0;
    private SpriteRenderer sr;
    public GameObject towerUpgradeUIPrefab;
    private GameObject currentUI;

    public Vector3Int cellPos;

    public int towerPrice = 1;
    public int sellprice1;
    public int visibleDmg1;


    private float fireCooldown = 0f;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        Enemy target = FindBestTarget();

        if (target != null && fireCooldown <= 0)
        {
            Shoot(target);
            fireCooldown = 1f / fireRate;
        }


    }

    Enemy FindBestTarget()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        Enemy best = null;
        float bestProgress = -1f;

        foreach (Enemy e in enemies)
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

    void Shoot(Enemy target)
    {
        GameObject p = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile pr = p.GetComponent<Projectile>();
        pr.target = target.transform;
    }

    public void Upgrade()
    {
        TowerUpgradeStage currentUpgradeStage = upgradeStages[upgradeStage];

        range = currentUpgradeStage.range;
        fireRate = currentUpgradeStage.fireRate;
        sr.sprite = currentUpgradeStage.sprite;
        projectilePrefab = currentUpgradeStage.projectilePrefab;
        CashManager.instance.UpdateCoins(-currentUpgradeStage.price);
        upgradeStage += 1;
    }

    public void Sell()
    {
        TowerUpgradeStage currentUpgradeStage = upgradeStages[upgradeStage];

        if (upgradeStage > 0)
        {
            CashManager.instance.UpdateCoins(+currentUpgradeStage.sellprice);

        }
        else
        {
            CashManager.instance.UpdateCoins(+sellprice1);

        }

        //remove cellpos function
        GameObject.FindFirstObjectByType<TowerPlacer>().occupiedTiles.Remove(cellPos);
        
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (currentUI == null)
        {
            currentUI = Instantiate(towerUpgradeUIPrefab, FindObjectOfType<Canvas>().transform);
        }

        TowerUpgradeUI currentUpgradeUI = currentUI.GetComponent<TowerUpgradeUI>();
        currentUpgradeUI.tower = this;

        currentUI.transform.position = Input.mousePosition + new Vector3(70, -50);

        if (upgradeStage >= upgradeStages.Length) return;
        currentUpgradeUI.priceTxt.text = upgradeStages[upgradeStage].price.ToString();
        currentUpgradeUI.valueTxt.text = upgradeStages[upgradeStage].sellprice.ToString();
        currentUpgradeUI.towernameTxt.text = TowerName.ToString();
        currentUpgradeUI.rangeTxt.text = upgradeStages[upgradeStage].range.ToString();

        if (upgradeStage > 0)
        {
        currentUpgradeUI.dmgTxt.text = upgradeStages[upgradeStage].visibleDmg.ToString();
        }
        else
        {
        currentUpgradeUI.dmgTxt.text = visibleDmg1.ToString();
        }

        if (upgradeStage > 0)
        {
            currentUpgradeUI.valueTxt.text = upgradeStages[upgradeStage].sellprice.ToString();
        }
        else
        {
            currentUpgradeUI.valueTxt.text = sellprice1.ToString();
        }
    }
}
