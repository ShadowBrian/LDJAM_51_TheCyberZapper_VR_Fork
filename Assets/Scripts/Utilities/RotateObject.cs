using UnityEngine;


public class RotateObject : MonoBehaviour
{
    Transform tr;
    [SerializeField] Vector3 dir = Vector3.up;
    [SerializeField] float speed = 15.0f;

    private void Start()
    {
        tr = transform;
    }

    void Update()
    {
        tr.Rotate(dir * Time.deltaTime * speed, Space.World);
    }
}
