using UnityEngine;
using Cinemachine;

public class Bumps : MonoBehaviour 
{
    public NoiseSettings m_NoiseProfile;
    public float m_AmplitudeGain = 1f;
    public float m_FrequencyGain = 1f;

    private bool mInitialized = false;
    private float mNoiseTime = 0;
    private Vector3 mNoiseOffsets = Vector3.zero;

    private void LateUpdate()
    {
        if (m_NoiseProfile == null)
            return;

        if (!mInitialized)
            Initialize();

        mNoiseTime += Time.deltaTime;
        float time = mNoiseTime * m_FrequencyGain;

        transform.position += GetCombinedFilterResults(
                m_NoiseProfile.PositionNoise, time, mNoiseOffsets) * m_AmplitudeGain;
        Quaternion rotNoise = Quaternion.Euler(GetCombinedFilterResults(
                    m_NoiseProfile.OrientationNoise, time, mNoiseOffsets) * m_AmplitudeGain);
        transform.rotation = transform.rotation  * rotNoise;
    }

    void Initialize()
    {
        mInitialized = true;
        mNoiseTime = 0;
        mNoiseOffsets = new Vector3(
                UnityEngine.Random.Range(-Time.time, 10000f),
                UnityEngine.Random.Range(-Time.time, 10000f),
                UnityEngine.Random.Range(-Time.time, 10000f));
    }

    static Vector3 GetCombinedFilterResults(
        NoiseSettings.TransformNoiseParams[] noiseParams, float time, Vector3 noiseOffsets)
    {
        float xPos = 0f;
        float yPos = 0f;
        float zPos = 0f;
        if (noiseParams != null)
        {
            for (int i = 0; i < noiseParams.Length; ++i)
            {
                NoiseSettings.TransformNoiseParams param = noiseParams[i];
                Vector3 timeVal = new Vector3(
                        param.X.Frequency, param.Y.Frequency, param.Z.Frequency);
                timeVal.Scale(time * Vector3.one + noiseOffsets);

                Vector3 noise = new Vector3(
                        Mathf.PerlinNoise(timeVal.x, 0f),
                        Mathf.PerlinNoise(timeVal.y, 0f),
                        Mathf.PerlinNoise(timeVal.z, 0f));

                noise -= Vector3.one * 0.5f;

                xPos += noise.x * param.X.Amplitude;
                yPos += noise.y * param.Y.Amplitude;
                zPos += noise.z * param.Z.Amplitude;
            }
        }
        return new Vector3(xPos, yPos, zPos);
    }
}
