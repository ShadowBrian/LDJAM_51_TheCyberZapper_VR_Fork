using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] CamManager camManager;

    [Header("Weapon")]
    [SerializeField] Transform gunPos;
    [SerializeField] Weapon weapon;

    [Header("Storage")]
    [SerializeField] float restingTime;

    void Update()
    {
        if (!player.gameManager.inGame) return;

        restingTime += Time.deltaTime;
        if (Input.GetButton("Fire1")) Fire();
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

}
