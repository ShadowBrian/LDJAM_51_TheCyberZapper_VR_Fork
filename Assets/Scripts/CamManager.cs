using UnityEngine;
using Cinemachine;

public class CamManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera gameCam;
    CinemachineTransposer transposer;
    CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    {
        noise = gameCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = 0f;
    }

    private void Update()
    {
        noise.m_AmplitudeGain *= 0.9f;
    }

    public void TeleportCamToPlayer()
    {
        if(!transposer) transposer = gameCam.GetCinemachineComponent<CinemachineTransposer>();

        transposer.m_XDamping = transposer.m_YDamping = transposer.m_ZDamping = 0f;
        Invoke("ResetParm", 0.1f);
    }

    void ResetParm()
    {

        transposer.m_XDamping = transposer.m_YDamping = transposer.m_ZDamping = 1f;
    }

    public void ShakeCam(float amplitude)
    {
        if (!noise) noise = gameCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        noise.m_AmplitudeGain = amplitude;

    }

}
