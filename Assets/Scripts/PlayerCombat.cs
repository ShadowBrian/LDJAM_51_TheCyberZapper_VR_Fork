using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] CamManager camManager;

    [Header("Weapon")]
    [SerializeField] Transform gunPos;
    [SerializeField] Weapon[] weaponArray;
    [SerializeField] Weapon weapon;

    [Header("Storage")]
    [SerializeField] float restingTime;

    void Update()
    {
        if (!player.gameManager.inGame) return;

        restingTime += Time.deltaTime;
        if (UnityXRInputBridge.instance.GetButton(XRButtonMasks.triggerButton,XRHandSide.RightHand)) Fire();
    }

    void Fire()
    {
        if(weapon && restingTime >= weapon.fireRate)
        {
            weapon.Fire(gunPos.position, gunPos.forward);
            camManager.ShakeCam(weapon.shakePower);
            restingTime = 0f;
        }
    }

    public Weapon GetNewWeapon()
    {
        weapon = weaponArray[Random.Range(0, weaponArray.Length)];
        return weapon;
    }
}
