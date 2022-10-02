using UnityEngine;
using System.Collections;
using TMPro;

public class ui_Dialog : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    float typeSpeed = 0.005f;
    public bool typing;
    public bool disableAfterDone;

    public void SetText(string text)
    {
        textMeshProUGUI.text = text;
    }

    public void TypeText()
    {
        StartCoroutine(TypeTextLoop());
    }

    private IEnumerator TypeTextLoop()
    {
        typing = true;
        textMeshProUGUI.maxVisibleCharacters = 0;
        gameObject.SetActive(true);

        for (int i = 0; i < textMeshProUGUI.text.Length; i++)
        {
            textMeshProUGUI.maxVisibleCharacters = i + 1;
            yield return new WaitForSecondsRealtime(typeSpeed);
        }

        typing = false;

        if (disableAfterDone)
        {
            yield return new WaitForSecondsRealtime(2f);
            gameObject.SetActive(false);
        }
    }

}
