using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBluprint turrettobuild;
    private Node selectednode;
    public NodeUIScript nodeui;


    public GameObject standardturretprefab;
    public GameObject godtiermissileprefab;
    public GameObject godtierturretprefab;
    public GameObject missilelauncherprefab;
    public GameObject laserbeamerprefab;
    public GameObject godtierlaserprefab;

    public GameObject buildeffect;
    public GameObject selleffect;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multi Buildmanager found");
            return;
        }
        instance = this;
    }
    public bool CanBuild { get { return turrettobuild != null; } }
    //public bool GetHasMoney()
    //{ return PlayerStatus.Money >= 0; }

    public void SelectNode (Node node)
    {
        if(selectednode == node)
        {
            deselectnode();
            return;
        }

        selectednode = node;
        turrettobuild = null;
        nodeui.SetTarget(node);
    }

    public void deselectnode()
    {
        selectednode = null;
        nodeui.Hideui();
    }
    public void SelectedTurretToBuild(TurretBluprint turret)
    {
        turrettobuild = turret;
        //selectednode = null;
        //nodeui.hideui();
        deselectnode();
    }


    /*public void BuildTurretOn(Node node)
    {
        if(PlayerStatus.Money < turrettobuild.cost)
        {
            //Debug.Log("u broke mofo");
            return;
        }
        PlayerStatus.Money -= turrettobuild.cost;
        GameObject turret = (GameObject)Instantiate(turrettobuild.prefabofdefense, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject turretbuildeffect = (GameObject)Instantiate(buildeffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(turretbuildeffect, 5f);
        //Debug.Log("Turret Build, Money left:" + PlayerStatus.Money);
    }*/

    public TurretBluprint GetTurretToBuild()
    {
        return turrettobuild;
    }
}
