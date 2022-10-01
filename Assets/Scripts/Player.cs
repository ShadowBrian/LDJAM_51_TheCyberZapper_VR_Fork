using UnityEngine;

public class Player : Entity
{
    public GameManager gameManager;
    public Rigidbody rb;
    public PlayerTarget target;
    public PlayerCombat combat;

    void Start()
    {
        
    }

    public override void Damage(float value)
    {
        base.Damage(value);

        gameManager.camManager.ShakeCam(value);

        gameManager.uiManager.SetLife(life, maxLife);
    }

}
