using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip pressureMusic;

    [SerializeField] float musicVolume = 0.5f;
    [SerializeField] AnimationCurve gameCurve;
    [SerializeField] AnimationCurve pitchCurve;

    private void Update()
    {
        source.volume = gameCurve.Evaluate(gameManager.timerValue * musicVolume);
        source.pitch = pitchCurve.Evaluate(gameManager.timerValue);
    }

    public void SetMenuMusic()
    {
        source.clip = menuMusic;
        source.loop = true;
    }


    public void SetPressureMusic()
    {
        if (!gameManager.playerZapped) return; // WAIT FOR THE HACK
        source.clip = pressureMusic;
        source.loop = false;
        source.Play();
    }

    void Stop()
    {

    }

}
