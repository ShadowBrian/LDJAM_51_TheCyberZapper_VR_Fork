using UnityEngine;

public class uiManager : MonoBehaviour
{
    [SerializeField] uiTimer lifeBar;

    public void SetLife(float value, float maxLife)
    {
        lifeBar.SetTime(value / maxLife, value.ToString());
    }

}
