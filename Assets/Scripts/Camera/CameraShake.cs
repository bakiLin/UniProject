using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cam;
    public float shakeIntensity = 1f;
    private float shakeTime = 1f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin m_channelsPerlin;

    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeIntensity;

        timer = shakeTime;
    }

    private void StopShake()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

        timer = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ShakeCamera();

        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0) StopShake();
        }
    }
}
