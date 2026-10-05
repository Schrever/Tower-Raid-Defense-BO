using UnityEngine;

public class CounterSelectionUI : MonoBehaviour
{
    public static GameObject SelectedTowerPrefab;
    public Transform[] wayPoints;


    void SpawnEnemy(GameObject prefab)
    {
        GameObject e = Instantiate(prefab, wayPoints[0].position, Quaternion.identity);
        CounterEnemy enemy = e.GetComponent<CounterEnemy>();
        enemy.waypoints = wayPoints;
    }

    public void SelectTower(GameObject towerPrefab)
    {
        if(towerPrefab == SelectedTowerPrefab)
        {
            SelectedTowerPrefab = null;
            return;
        }


        if(towerPrefab.GetComponent<CounterEnemy>().Price <= CashManager.instance.coins)
        {
            SelectedTowerPrefab = towerPrefab;
            CashManager.instance.UpdateCoins(-towerPrefab.GetComponent<CounterEnemy>().Price);
            SpawnEnemy(towerPrefab);
        }
    }

    
}
