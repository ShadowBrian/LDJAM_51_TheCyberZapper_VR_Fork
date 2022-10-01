using UnityEngine;
using TMPro;

public class uiTimerManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] uiTimer[] timers;
    [SerializeField] TextMeshProUGUI bigTimer;

    [Header("Storage")]
    [SerializeField] float timeValue;
    [SerializeField] string timeValueString;

    void Update()
    {
        if (!gameManager) gameManager = GameManager.instance;

        timeValue = gameManager.timerValue;
        timeValueString = Mathf.Ceil(timeValue).ToString();

        if (timeValue <= 3f)
        {
            bigTimer.text = timeValue.ToString("F2") + "<space=10><size=50><voffset=20>sec</size>";
        }
        else bigTimer.text = string.Empty;

        foreach (var timer in timers)
        {
            timer.SetTime(timeValue*0.1f, timeValueString);
        }
    }

}
