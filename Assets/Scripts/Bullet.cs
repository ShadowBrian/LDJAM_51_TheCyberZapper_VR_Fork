using UnityEngine;

public class Bullet : Entity
{
    [SerializeField] Rigidbody rb;

    [Header("Stats")]
    [SerializeField] float damage = 5;
    [SerializeField] float speed = 5;

    public override void Launch(Vector3 pos, Vector3 dir)
    {
        transform.position = pos;
        gameObject.SetActive(true);
        rb.velocity = dir * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Entity e))
        {
            //Debug.Log("Collided with " + collision.transform.name);
            DoDamage(e);
        }
        else // Hitted enviro
        {
            Death();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Entity e))
        {
            //Debug.Log("Collided with " + collision.transform.name);
            DoDamage(e);
        }

    }

    void DoDamage(Entity entity)
    {
        entity.Damage(damage);
        Damage(1);
    }

}
