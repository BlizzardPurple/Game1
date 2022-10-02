using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hovercolor;
    public Color alarmcolor;
    public Vector3 hoverposition;
    //public Vector3 hoverrotation;

    private Renderer rend;
    private Color startcolor;

    [Header("Optional")]
    public GameObject turret;
    BuildManager buildmanager;
    public TurretBluprint turretBlueprint;
    public int turretLevel = 1;
    public Vector3 GetBuildPosition() { return transform.position + hoverposition; }

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startcolor = rend.material.color;
        buildmanager = BuildManager.instance;
        //turrettobuild = buildmanager.GetTurretToBuild();
    }

    private void OnMouseDown()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            //Debug.Log("Cant build here");
            buildmanager.SelectNode(this);
            return;
        }

        if (!buildmanager.CanBuild)
            return;

        //buildmanager.BuildTurretOn(this);
        Buildturret(buildmanager.GetTurretToBuild());
    }

    public void Buildturret(TurretBluprint blueprint)
    {
        if (PlayerStatus.Money < blueprint.cost)
        {
            //Debug.Log("u broke mofo");
            return;
        }
        PlayerStatus.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefabofdefense,GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject turretbuildeffect = (GameObject)Instantiate(buildmanager.buildeffect, GetBuildPosition(), Quaternion.identity);
        Destroy(turretbuildeffect, 5f);
        //Debug.Log("Turret Build, Money left:" + PlayerStatus.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStatus.Money < turretBlueprint.upgradeCost)
        {
            //Debug.Log("u broke mofo");
            return;
        }
        PlayerStatus.Money -= turretBlueprint.upgradeCost;

        
        Destroy(turret);
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.godtierprefabofdefense, GetBuildPosition(), Quaternion.identity);//#god tier prefab
        turret = _turret;
        //turrettobuild = turret;

        GameObject turretbuildeffect = (GameObject)Instantiate(buildmanager.buildeffect, GetBuildPosition(), Quaternion.identity);
        Destroy(turretbuildeffect, 5f);
        turretLevel++;
        turretBlueprint.upgradeCost += 5;
    }

    public void SellTurret()
    {
        PlayerStatus.Money += turretBlueprint.GetSellAmount();
        GameObject turretbuildeffect = (GameObject)Instantiate(buildmanager.selleffect, GetBuildPosition(), Quaternion.identity);
        Destroy(turretbuildeffect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    private void OnMouseEnter()
    {
        if (!buildmanager.CanBuild)
            return;
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        // the 2 if statement below are just working and are fucked up
        if (PlayerStatus.Money >= buildmanager.GetTurretToBuild().cost)  
        { 
            rend.material.color = hovercolor; 
        }
        if (PlayerStatus.Money < buildmanager.GetTurretToBuild().cost)
        { 
            rend.material.color = alarmcolor; 
        }
    }


    private void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
