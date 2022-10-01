using UnityEngine;

[CreateAssetMenu]
public class Weapon : PoolableEntity
{
    public float fireRate;
    public float shakePower;

    public void Fire(Vector3 pos, Vector3 dir)
    {
        Entity g = pool.GetEntity();
        g.Launch(pos, dir);
    }
}
