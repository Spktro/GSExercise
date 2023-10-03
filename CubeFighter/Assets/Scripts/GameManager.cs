using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Gun Gun;
    [SerializeField] private MachineGun MachineGun;
    public Button BtnFireGun;
    public PressButton BtnFireMachineGun;
 
    void Start()
    {
        BtnFireGun.onClick.AddListener(BtnSpawnCube_click);
        BtnFireMachineGun.OnButtonPressed += BtnSpawnRectangle_Press;
        BtnFireMachineGun.OnButtonReleased += BtnSpawnRectangle_Release;
    }

    private void BtnSpawnCube_click() => Gun.Fire();
    private void BtnSpawnRectangle_Press() => MachineGun.Fire();
    private void BtnSpawnRectangle_Release() => MachineGun.Stop();

}



