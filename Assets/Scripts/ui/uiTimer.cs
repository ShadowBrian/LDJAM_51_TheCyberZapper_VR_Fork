using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class uiTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;
    [SerializeField] Image timerIMG;

    public void SetTime(float value, string valueString)
    {
        if (m_TextMeshProUGUI) m_TextMeshProUGUI.text = valueString;
        if (timerIMG) timerIMG.fillAmount = value;
    }

}
