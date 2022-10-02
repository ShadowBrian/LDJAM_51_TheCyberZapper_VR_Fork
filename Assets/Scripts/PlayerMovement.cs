using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Comp")]
    [SerializeField] Player player;
    PlayerTarget target;
    [SerializeField] Rigidbody rb;

    [Header("Var")]
    [SerializeField] float playerSpeed = 10f;

    [Header("Debug")]
    [SerializeField]Vector3 playerMovement;
    [SerializeField]Vector3 dir;

    void Start()
    {
        target = player.target;
    }

    private void Update()
    {
        if (!player.gameManager.inGame) return;

        playerMovement.x = Input.GetAxis("Horizontal");
        playerMovement.z = Input.GetAxis("Vertical");


        dir = target.playerTargetPos - transform.position;
        dir.y = 0;
        rb.rotation = Quaternion.LookRotation(dir, Vector3.up);

        
        player.gameManager.uiManager.TiltUI(-rb.velocity.z, -rb.velocity.x);
    }

    private void FixedUpdate()
    {
        rb.velocity = playerMovement * playerSpeed + (rb.velocity.y * Vector3.up);
    }

}
