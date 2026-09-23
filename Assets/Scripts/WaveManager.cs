using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.Mathematics;

[System.Serializable]
public class WaveData
{
    public float duration = 10f;
    public int E1L1 = 5;
    public int E2L1 = 2;
    public int E3L1 = 1;
}

public class WaveManager : MonoBehaviour
{
    public WaveData[] waves;
    public Button startWaveButton;

    public GameObject E1L1Prefab;
    public GameObject E2L1Prefab;
    public GameObject E3L1Prefab;

    public Transform[] wayPoints;

    private int currentWaveIndex = 0;
    private bool waveRunning = false;

    void Start()
    {
        startWaveButton.onClick.AddListener(StartWave);    
    }

    public void StartWave()
    {
        if (waveRunning) return;
        if (currentWaveIndex >= waves.Length) return;

        StartCoroutine(RunWave());
    }

    IEnumerator RunWave()
    {
        waveRunning = true;
        startWaveButton.interactable = false;

        WaveData wave = waves[currentWaveIndex];

        for(int i = 0; i < wave.E1L1; i++)
        {
            SpawnEnemy(E1L1Prefab);
            yield return new WaitForSeconds((wave.duration / 3) / wave.E1L1);
        }

        for(int i = 0; i < wave.E2L1; i++)
        {
            SpawnEnemy(E2L1Prefab);
            yield return new WaitForSeconds((wave.duration / 3) / wave.E2L1);
        }

        for(int i = 0; i < wave.E3L1; i++)
        {
            SpawnEnemy(E3L1Prefab);
            yield return new WaitForSeconds((wave.duration / 3) / wave.E3L1);
        }

        yield return new WaitForSeconds(wave.duration / 3);

        waveRunning = false;
        startWaveButton.interactable = true;
        currentWaveIndex++;
    }

    void SpawnEnemy(GameObject prefab)
    {
        GameObject e = Instantiate(prefab, wayPoints[0].position, Quaternion.identity);
        Enemy enemy = e.GetComponent<Enemy>();
        enemy.waypoints = wayPoints;
    }

}
