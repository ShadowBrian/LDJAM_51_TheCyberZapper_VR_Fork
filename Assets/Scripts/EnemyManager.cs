using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] EnemyData[] prefabEnemies;

    // Storage
    Transform playerTransform;
    Vector3 playerPos;

    [SerializeField] Entity[] enemies;

    void Start()
    {
        //enemies = poolParent.GetComponentsInChildren<Enemy>();
        playerTransform = player.transform;
    }

    private void Update()
    {
        
    }

    public void InitNewArena(Arena newArena)
    {
        DescativateAll();

        int enemiesToSpawn = Random.Range(newArena.minNumber, newArena.maxNumber);
        enemies = new Entity[enemiesToSpawn];

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int typeToSpawn = 0; // TEMP
            enemies[i] = prefabEnemies[typeToSpawn].pool.GetEntity();
        }

        foreach (Enemy enemy in enemies)
        {
            //if (!enemy || !enemy.isActiveAndEnabled) continue;
            enemy.transform.position = newArena.GetEnemySpawn().position;
            enemy.gameObject.SetActive(true);
            enemy.SetTarget(playerTransform);

        }
    }

    void DescativateAll()
    {
        foreach(EnemyData d in prefabEnemies)
        {
            d.pool.DesactivateAll();
        }
    }
}
