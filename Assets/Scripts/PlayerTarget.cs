using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Player player;
    [SerializeField][Range(0f,1f)] float followSpeed = 0.25f;
    [SerializeField] float maxDelta = 10f;

    [Header("Storage")]
    public Vector3 playerTargetPos = Vector3.zero;
    [SerializeField] Vector3 mousePos;
    Ray ray;
    float distance;
    Plane plane;

    private void Start()
    {
        plane = new Plane(Vector3.up, 0);
    }

    private void LateUpdate()
    {
        mousePos = Input.mousePosition;
        ray = cam.ScreenPointToRay(mousePos);

        if (plane.Raycast(ray, out distance))
        {
            playerTargetPos = ray.GetPoint(distance);
        }
        //Vector3 playerLook = player.transform.position + (player.rb.velocity * followSpeed);
        //transform.position = Vector3.Lerp(transform.position, playerLook, 0.3f);
        Vector3 playerPos = player.transform.position;
        Vector3 viewCenter = Vector3.Lerp(player.transform.position, playerTargetPos, followSpeed);
        transform.position = Vector3.MoveTowards(playerPos, viewCenter, maxDelta);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(playerTargetPos, 0.45f);
    }

}
