using UnityEngine;
using DG.Tweening;

public class Entity : MonoBehaviour
{
    Transform tr;
    [SerializeField] protected float maxLife = 25;
    [SerializeField] protected float life;
    [SerializeField] protected float maxArmor = 50;
    [SerializeField] protected float armor;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        gameObject.SetActive(true);
        life = maxLife;
        armor = 0;

        tr = transform;
    }

    public virtual void Damage(float value)
    {
        if(armor > 0) armor -= value;
        else life -= value;

        armor = Mathf.Max(0, armor);
        life = Mathf.Max(0, life);

        //tr.DOShakeScale(0.1f, 0.5f, 5, 45);

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
