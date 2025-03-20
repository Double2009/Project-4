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

    public TextMeshProUGUI waveCountdownText;

    private float countdown = 2f; 
    private int waveIndex = 0;

    void Update(){

        if(countdown <= 0){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves; 
        }

        countdown -= Time.deltaTime; 

        waveCountdownText.text = Mathf.Round(countdown).ToString();
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
