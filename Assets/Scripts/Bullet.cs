using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f; 
    public float explosionRadius = 0f; 
    public int damage = 50; 
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            Destroy(target);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;   

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget(); 
            return; 
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }


    void HitTarget()
    {
        Instantiate(impactEffect, transform.position, transform.rotation);

        if(explosionRadius > 0f){
            Explode();
        }
        else{
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in colliders){
            if(collider.tag == "Enemy"){
                Damage(collider.transform);
            }
        }

    }

    void Damage(Transform enemy){

        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null){
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
