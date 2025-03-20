using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f; 
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
    }


    void HitTarget()
    {
        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }


}
