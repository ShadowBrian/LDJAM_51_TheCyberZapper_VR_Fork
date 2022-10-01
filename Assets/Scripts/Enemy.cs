using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Weapon weapon;

    [SerializeField] Transform target;
    [SerializeField][Range(0, 10f)] float range = 5f;
    [SerializeField] LayerMask layerMask;

    [Header("Storage")]
    [SerializeField] float dist;
    [SerializeField] float lastFire;
    Ray ray;


    private void FixedUpdate()
    {
        if (!target) return;
        agent.destination = target.position;

        dist = Vector3.Distance(target.position, transform.position);
        //if (dist <= range) CheckIfViewIsOpen();
    }

    private void Update()
    {
        lastFire += Time.deltaTime;
        if (weapon && lastFire >= weapon.fireRate) CheckIfViewIsOpen();
    }

    void CheckIfViewIsOpen()
    {
        RaycastHit hit;
        Vector3 pos = transform.position + Vector3.up * 1f;
        Vector3 dir = transform.forward;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(pos, dir, out hit, range, layerMask))
        {
            Fire(pos, dir);
            Debug.DrawRay(pos, dir * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(pos, dir * range, Color.green);
        }
    }

    void Fire(Vector3 pos, Vector3 dir)
    {
        weapon.Fire(pos, dir);
        lastFire = 0f;
    }

    public void GoTo(Vector3 pos)
    {
        agent.destination = pos;
    }

    public override void SetTarget(Transform target)
    {
        this.target = target;
        agent.destination = target.position;
    }

}
