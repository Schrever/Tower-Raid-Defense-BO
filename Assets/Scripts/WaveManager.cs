using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.Mathematics;
using TMPro;

[System.Serializable]
public class WaveData
{
    public float duration = 10f;
    public int E1L1 = 5;
    public int E2L1 = 2;
    public int E3L1 = 1;
    public int E1L2 = 5;
    public int E2L2 = 2;
    public int E3L2 = 1;
    public int E1L3 = 5;
    public int E2L3 = 2;
    public int E3L3 = 1;
}

public class WaveManager : MonoBehaviour
{
    public WaveData[] waves;
    public Button startWaveButton;

    public GameObject E1L1Prefab;
    public GameObject E2L1Prefab;
    public GameObject E3L1Prefab;
    public GameObject E1L2Prefab;
    public GameObject E2L2Prefab;
    public GameObject E3L2Prefab;
    public GameObject E1L3Prefab;
    public GameObject E2L3Prefab;
    public GameObject E3L3Prefab;

    public Transform[] wayPoints;

    public TextMeshProUGUI WaveTxt;

    public int currentWaveIndex = 0;
    private bool waveRunning = false;
    public EnemyBase enemyBase;
    

    void Start()
    {
        startWaveButton.onClick.AddListener(StartWave);    
    }

    public void StartWave()
    {
        if (waveRunning) return;
        if (currentWaveIndex >= waves.Length) return;

        StartCoroutine(RunWave());

        if(currentWaveIndex > 39)
        {
            Flipscript();
        }
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

        for(int i = 0; i < wave.E1L2; i++)
        {
            SpawnEnemy(E1L2Prefab);
            yield return new WaitForSeconds((wave.duration / 3) / wave.E1L2);
        }

        for(int i = 0; i < wave.E2L2; i++)
        {
            SpawnEnemy(E2L2Prefab);
            yield return new WaitForSeconds((wave.duration / 3) / wave.E2L2);
        }

        for(int i = 0; i < wave.E3L2; i++)
        {
            SpawnEnemy(E3L2Prefab);
            yield return new WaitForSeconds((wave.duration / 3) / wave.E3L2);
        }

        for(int i = 0; i < wave.E1L3; i++)
        {
            SpawnEnemy(E1L3Prefab);
            yield return new WaitForSeconds((wave.duration / 3) / wave.E1L3);
        }

        for(int i = 0; i < wave.E2L3; i++)
        {
            SpawnEnemy(E2L3Prefab);
            yield return new WaitForSeconds((wave.duration / 3) / wave.E2L3);
        }

        for(int i = 0; i < wave.E3L3; i++)
        {
            SpawnEnemy(E3L3Prefab);
            yield return new WaitForSeconds((wave.duration / 3) / wave.E3L3);
        }

        yield return new WaitForSeconds(wave.duration / 3);

        waveRunning = false;
        startWaveButton.interactable = true;
        currentWaveIndex++;
        WaveTxt.text = (currentWaveIndex + 1).ToString();
    }

    void SpawnEnemy(GameObject prefab)
    {
        GameObject e = Instantiate(prefab, wayPoints[0].position, Quaternion.identity);
        Enemy enemy = e.GetComponent<Enemy>();
        enemy.waypoints = wayPoints;
    }

    void Flipscript()
    {
        enemyBase.FobChange();
        WaveTxt.text = "ATTACK";

    }

    void Update()
    {
        
    }

}
