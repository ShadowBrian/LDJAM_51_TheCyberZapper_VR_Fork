using UnityEngine;

public class PoolableEntity : ScriptableObject
{
    public string entityName;

    [Header("Pooling")]
    public Pool pool;
    public int number;

    public Entity prefab;
    public AudioClip spawnSound;

    [Header("Var")]
    public bool randomScale;
}
