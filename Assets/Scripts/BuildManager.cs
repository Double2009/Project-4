using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab; 

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild; 

    void Awake()
    {
        if(instance != null){
            Debug.Log("More than one Build Manager in scene!");
            return;
        }
        instance = this; 
    }

    public bool CanBuild{ get {return turretToBuild != null; } }
    public bool HasMoney{ get {return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node){

        if(PlayerStats.Money < turretToBuild.cost){
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret built! Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret; 
    }

}
