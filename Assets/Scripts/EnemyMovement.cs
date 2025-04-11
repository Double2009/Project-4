using UnityEngine;
using UnityEngine.AI;
using System.Collections; 

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    // private Transform target;
    // private int wavepointIndex = 0;

    private NavMeshAgent agent; 
    private Enemy enemy; 

    [SerializeField] private float arrivalTolerance = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        enemy = GetComponent<Enemy>(); 
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; 
        //target = Waypoints.points[0];
    }

    void Start(){
         if(Waypoints.points != null && Waypoints.points.Length > 0)
        {
            Vector3 destination = Waypoints.points[Waypoints.points.Length - 1].position;
            agent.SetDestination(destination);
        }
        agent.speed = enemy.startSpeed;
    }

    void Update()
    {
        // Vector3 direction  = target.position - transform.position;
        // transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        // if(Vector3.Distance(transform.position, target.position) <= 0.2f){
        //     GetNextWaypoint();
        // }

        agent.speed = enemy.speed; 

        if(!agent.pathPending && agent.remainingDistance <= (agent.stoppingDistance + arrivalTolerance)){
            EndPath();
        }
    }

    // void GetNextWaypoint(){

    //     if(wavepointIndex >= Waypoints.points.Length - 1){
    //         EndPath();
    //         return;
    //     }
    //     wavepointIndex++;
    //     target = Waypoints.points[wavepointIndex];
    // }

    void EndPath(){
        PlayerStats.Lives--;
        WaveManager.EnemiesAlive--; 
        Destroy(gameObject);
    }
}
