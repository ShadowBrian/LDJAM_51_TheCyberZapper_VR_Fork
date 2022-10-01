using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float maxLife = 25;
    [SerializeField] protected float life;

    private void Start()
    {
        life = maxLife;
    }

    public virtual void Damage(float value)
    {
        life -= value;
        life = Mathf.Max(0, life);

        if (life <= 0) Death();
    }

    public virtual void Death()
    {
        gameObject.SetActive(false);
    }

    public virtual void Launch(Vector3 pos, Vector3 dir)
    {

    }

    public virtual void SetTarget(Transform target)
    {

    }
}
