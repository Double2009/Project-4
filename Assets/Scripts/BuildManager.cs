using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab; 

    private GameObject turretToBuild; 

    void Awake()
    {
        if(instance != null){
            Debug.Log("More than one Build Manager in scene!");
            return;
        }
        instance = this; 
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret; 
    }

}
