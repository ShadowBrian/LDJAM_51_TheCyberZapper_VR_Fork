using UnityEngine;

public class Pool : MonoBehaviour
{
    public PoolableEntity entity;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Entity[] entityArray;
    [SerializeField] int index = 0;
    [SerializeField] int length = 0;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        entity.pool = this;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            if (t) Destroy(t.gameObject);
        }

        length = entity.number;
        entityArray = new Entity[entity.number];
        for (int i = 0; i < entity.number; i++)
        {
            entityArray[i] = Instantiate(entity.prefab, transform);
            if (entity.randomScale) 
                entityArray[i].transform.localScale = Vector3.one * (0.5f+Mathf.PerlinNoise(i*0.25f, 0f));
                //Random.Range(0.5f, 1.5f);
            entityArray[i].gameObject.SetActive(false);
        }
    }

    public Entity GetEntity()
    {
        Entity g = entityArray[index];

        if (entity.spawnSound) audioSource.PlayOneShot(entity.spawnSound);

        index++;
        if(index >= length) index = 0;

        return g;
    }

    public void DesactivateAll()
    {
        for (int i = 0; i < entityArray.Length; i++)
        {
            entityArray[i].gameObject.SetActive(false);
        }
    }

}
