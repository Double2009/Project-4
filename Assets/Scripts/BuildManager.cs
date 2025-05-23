using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    public GameObject buildEffect;
    public GameObject sellEffect; 

    private TurretBlueprint turretToBuild; 
    private Node selectedNode; 

    public NodeUI nodeUI; 

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

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret; 
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild(){
        return turretToBuild;
    }

    public void SelectNode(Node node){

        if(selectedNode == node){
            DeselectNode();
            return;
        }


        selectedNode = node;
        turretToBuild = null; 

        nodeUI.SetTarget(node);
    }

    public void DeselectNode(){
        selectedNode = null; 
        nodeUI.Hide();
    }

}
