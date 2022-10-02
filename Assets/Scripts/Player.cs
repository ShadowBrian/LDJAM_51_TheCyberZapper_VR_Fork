using UnityEngine;

public class Player : Entity
{
    public GameManager gameManager;
    public Rigidbody rb;
    public PlayerTarget target;
    public PlayerCombat combat;

    private void Start()
    {
        Respawn();
    }

    public void Respawn()
    {
        base.Init();
        Damage(0);
    }

    public float GetLife()
    {
        return base.life;
    }

    public override void Damage(float value)
    {
        base.Damage(value);

        if(life > 0) gameManager.camManager.ShakeCam(value);

        gameManager.uiManager.SetLife(life, maxLife);
        gameManager.uiManager.SetArmor(armor, maxArmor);
    }

    public void Regen(int life, int armor, int ammo)
    {
        base.life += life;
        base.armor += armor;
        // TEMP DO AMMO

        base.life = Mathf.Min(base.life, maxLife);
        base.armor = Mathf.Min(base.armor, maxArmor);
        Damage(0);
    }

    public override void Death()
    {
        base.Death();

        gameManager.Restart();
    }

}
