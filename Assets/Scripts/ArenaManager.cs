using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] Arena[] arenas;

    [Header("Storage")]
    public Arena currentArena;

    void Start()
    {
        
    }

    public Arena GetNewArena()
    {
        int maxTry = 5;
        Arena newArena = currentArena;
        int index;

        for (int i = 0; i < maxTry; i++)
        {
            index = Random.Range(0, arenas.Length);
            Debug.Log(index);
            if (arenas[index] != newArena)
            {
                newArena = arenas[index];
                break;
            }
        }

        currentArena = newArena;
        return currentArena;
    }

}
