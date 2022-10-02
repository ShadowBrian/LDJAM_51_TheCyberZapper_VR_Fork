using UnityEngine;

public class Collectible : Entity
{
    [Header("Stats")]
    [SerializeField] int lifeGiven;
    [SerializeField] int armorGiven;
    [SerializeField] int ammoGiven;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player pj))
        {
            pj.Regen(lifeGiven, armorGiven, ammoGiven);
            base.Death();
        }
    }

}
