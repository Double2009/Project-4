using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;

    [Header("Unity Setup Fields")]
    public Transform rotator;
    public string enemyTag = "Enemy";

    [Header("Turret Settings")]
    public float range = 15f; 
    public float turnSpeed = 10f; 
    public float fireRate = 1f; 

    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float fireCountdown = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        }
        else{
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            return;
        }

        Vector3 direction = target.position - transform.position; 
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotator.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0){
            Shoot();
            fireCountdown = 1f/fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null){
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
