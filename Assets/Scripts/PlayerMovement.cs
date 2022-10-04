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

    public Transform PlayerHead;

    void Start()
    {
        target = player.target;
    }

    private void Update()
    {
        if (!player.gameManager.inGame) return;

        playerMovement.x = UnityXRInputBridge.instance.GetVec2(XR2DAxisMasks.primary2DAxis,XRHandSide.LeftHand).x;
        playerMovement.z = UnityXRInputBridge.instance.GetVec2(XR2DAxisMasks.primary2DAxis, XRHandSide.LeftHand).y;

        /*dir = target.playerTargetPos - transform.position;
        dir.y = 0;
        rb.rotation = Quaternion.LookRotation(dir, Vector3.up);*/

        if (UnityXRInputBridge.instance.GetButtonDown(XRButtonMasks.primary2DAxisLeft, XRHandSide.RightHand))
        {
            rb.transform.RotateAround(PlayerHead.position, Vector3.up, -30f);
        }

        if (UnityXRInputBridge.instance.GetButtonDown(XRButtonMasks.primary2DAxisRight, XRHandSide.RightHand))
        {
            rb.transform.RotateAround(PlayerHead.position, Vector3.up, 30f);
        }


        //player.gameManager.uiManager.TiltUI(-rb.velocity.z, -rb.velocity.x);
    }

    private void FixedUpdate()
    {
        var flatforward = PlayerHead.forward;
        flatforward.y = 0;
        rb.velocity = Quaternion.LookRotation(flatforward) * playerMovement * playerSpeed + (rb.velocity.y * Vector3.up);
    }

}
