using UnityEngine;
using DG.Tweening;
using TMPro;

public class uiManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [Header("UI")]
    [SerializeField] CanvasGroup menuUI;
    [SerializeField] CanvasGroup gameUI;
    [SerializeField] uiTimer lifeBar, armorBar, zapBar;
    [SerializeField] GameObject zapButtonPress;
    [SerializeField] TextMeshProUGUI roomNumber;

    [Header("Var")]
    [SerializeField] float uiTiltStrength;
    [SerializeField][Range(0,1)] float tiltSpeed;

    [Header("Dialogs")]
    [SerializeField] ui_Dialog intro;
    [SerializeField] ui_Dialog dialogHack;

    private void Start()
    {
        intro.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (UnityXRInputBridge.instance.GetButtonDown(XRButtonMasks.secondaryButton,XRHandSide.LeftHand) || UnityXRInputBridge.instance.GetButtonDown(XRButtonMasks.secondaryButton, XRHandSide.RightHand))
        {
            Debug.Log("PAUSE GAME");

            if (intro.gameObject.activeInHierarchy) IntroFinished();
            DisplayGame(gameManager.inMenu);
        }

        SetUIRot(Quaternion.identity, 0.1f);
    }

    public void TiltUI(float x, float y)
    {
        SetUIRot(Quaternion.Euler(x * uiTiltStrength, y * uiTiltStrength, 0), tiltSpeed);
    }

    void SetUIRot(Quaternion rot, float speed)
    {
        //gameUI.transform.rotation = Quaternion.Lerp(gameUI.transform.rotation, rot, speed);
    }

    public void SetLife(float value, float max)
    {
        lifeBar.SetTime(value / max, value.ToString("F0"));
    }

    public void SetZap(float value, float max)
    {
        string text = value.ToString("F0");
        if (value < 0) text = string.Empty;
        zapButtonPress.SetActive(value < 0);

        zapBar.SetTime(value / max, text);
    }

    public void SetArmor(float value, float max)
    {
        armorBar.SetTime(value / max, value.ToString("F0"));
    }

    public void PlayIntro()
    {
        Debug.Log("SHOW INTRO");

        SetCanvasVisibility(gameUI, false);

        gameManager.inMenu = true;
        intro.gameObject.SetActive(true);
        intro.TypeText();
    }

    public void PlayHackDialog()
    {
        dialogHack.gameObject.SetActive(true);
        dialogHack.TypeText();
    }

    public void IntroFinished()
    {
        intro.gameObject.SetActive(false);
        gameManager.introductionPlayed = true;
        DisplayGame(true);
    }

    public void SetRoomNumber(int value)
    {
        roomNumber.text = " <size=75%>room</size>\n_" + value.ToString();
    }

    public void DisplayGame(bool state)
    {
        Debug.Log("Display game ==" + state);
        gameManager.inMenu = !state;
        

        Time.timeScale = state ? 1f : 0.0001f; 
        SetCanvasVisibility(menuUI, !state);
        SetCanvasVisibility(gameUI, state);
    }

    private void SetCanvasVisibility(CanvasGroup group, bool state)
    {
        group.DOFade(state ? 1f : 0f, 0.5f).SetUpdate(true);
        group.blocksRaycasts = state;
        group.interactable = state;
    }

}
