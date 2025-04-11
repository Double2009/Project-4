using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float startSpeed = 10f; 

    [HideInInspector]
    public float speed;

    [Header("Unity Stuff")]
    public Image healthBar; 
    public float startHealth = 100f; 
    public int moneyGained = 50; 

    private float health; 

    private bool isDead = false;

    public GameObject deathEffect;

    void Start(){
        speed = startSpeed; 
        health = startHealth; 
    }

    public void Slow(float percentage){
        speed = startSpeed * (1f - percentage);
    }

    public void TakeDamage(float amount){
        health -= amount; 

        healthBar.fillAmount = health/startHealth; 

        if(health <= 0 && !isDead){
            Die();
        }
    }

    private void Die(){

        isDead = true;

        PlayerStats.Money += moneyGained; 
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        
        Destroy(effect, 5f);

        WaveManager.EnemiesAlive--; 

        Destroy(gameObject);
    }

    // Update is called once per frame


}
