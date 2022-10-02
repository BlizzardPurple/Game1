using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public TurretBluprint standardTurret;
    public TurretBluprint missilelauncher;
    public TurretBluprint laserbeamer;
    public TurretBluprint godturret;
    public TurretBluprint godlauncher;
    public TurretBluprint godbeamer;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        //Debug.Log("std turret purchased");
        buildManager.SelectedTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {
        //Debug.Log("std turret purchased");
        buildManager.SelectedTurretToBuild(missilelauncher);
    }
    public void SelectLaserbeamer()
    {
        //Debug.Log("std turret purchased");
        buildManager.SelectedTurretToBuild(laserbeamer);
    }
    public void SelectGodTurret()
    {
        //Debug.Log("std turret purchased");
        buildManager.SelectedTurretToBuild(godturret);
    }
    public void SelectGodLauncher()
    {
        //Debug.Log("std turret purchased");
        buildManager.SelectedTurretToBuild(godlauncher);
    }
    public void SelectGodBeamer()
    {
        //Debug.Log("std turret purchased");
        buildManager.SelectedTurretToBuild(godbeamer);
    }

}
