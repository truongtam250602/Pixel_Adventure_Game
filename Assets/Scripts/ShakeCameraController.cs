using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCameraController : MonoBehaviour
{
    public static ShakeCameraController Instance;
    private CinemachineVirtualCamera virtualCamera;
    private float timer;

    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeTime;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        StopShake();
    }

    public IEnumerator ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime;
        yield return new WaitForSeconds(shakeTime);
    }
    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
        timer = 0f;
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                StopShake();
            }
        }
    }
}
