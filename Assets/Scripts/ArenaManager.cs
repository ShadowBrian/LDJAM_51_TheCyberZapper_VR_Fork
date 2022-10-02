using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] Arena[] arenas;

    [Header("Storage")]
    public Arena currentArena;

    void Awake()
    {
        arenas = GetComponentsInChildren<Arena>();
    }

    public Arena GetNewArena(bool firstTime)
    {
        int maxTry = 7;
        Arena newArena = currentArena;
        int index;

        for (int i = 0; i < maxTry; i++)
        {
            index = Random.Range(0, arenas.Length);
            Debug.Log(index);

            if (arenas[index] != newArena)
            {
                if (firstTime && arenas[index].difficulty > 50) continue;

                newArena = arenas[index];
                break;
            }
        }

        currentArena = newArena;


        return currentArena;
    }

}
