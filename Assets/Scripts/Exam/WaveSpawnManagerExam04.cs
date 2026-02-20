using UnityEngine;

public class WaveSpawnManagerExam04 : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    public bool enableWaveCycling;

    private int currentWave = 0;
    private float waveEndTime = 0f;

    void Start()
    {
        currentWave = 0;
        waveController.StartWave(waveConfigurations[currentWave]);
        waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
    }

    void Update()
    {
        if (waveController == null || waveConfigurations.Length == 0)
            return;

        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;

            // ถ้าเกินเวฟสุดท้าย
            if (currentWave >= waveConfigurations.Length)
            {
                if (enableWaveCycling)
                {
                    // เริ่มเวฟแรกใหม่
                    currentWave = 0;
                    Debug.Log("Wave cycle restart");
                }
                else
                {
                    Debug.Log("All waves completed!");
                    return;
                }
            }

            waveController.StartWave(waveConfigurations[currentWave]);
            waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
        }
    }
}