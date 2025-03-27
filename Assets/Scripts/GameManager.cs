using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5.1f; 
    public float timeBetweenSpawn = 0.2f;

    public Text waveCountdownText;

    private float countdown = 2f; 
    private int waveIndex = 0;

    void Update(){

        if(countdown <= 0){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves; 
        }

        countdown -= Time.deltaTime; 

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    
    IEnumerator SpawnWave(){
        
        waveIndex++;

        for(int i = 0; i < waveIndex; i++){
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }

    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    
}
