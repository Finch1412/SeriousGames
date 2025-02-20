using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PanicModeURP : MonoBehaviour
{
    public bool panicMode = false;
    public Transform panicTriggerObject; // Object that triggers panic
    public Transform player; // Player transform

    public Volume panicVolume; // Reference to the URP Volume
    private ChromaticAberration chromaticAberration;
    private DepthOfField depthOfField;
    private Vignette vignette;

    public AudioSource heartBeatAudio; // Heartbeat Audio Source

    public float maxEffectDistance = 10f; // Max distance for full effect
    public float maxBlur = 3f; // Max blur intensity
    public float maxAberration = 1f; // Max chromatic aberration
    public float maxVignetteIntensity = 0.5f; // Max vignette darkness
    public float maxCameraShake = 0.1f; // Max camera shake intensity

    public float minHeartbeatPitch = 0.8f; // Slowest heartbeat
    public float maxHeartbeatPitch = 1.5f; // Fastest heartbeat

    private Vector3 originalCameraPos;
    private Camera mainCamera;

    void Start()
    {
        // Get URP Post-Processing effects from the Volume
        if (panicVolume.profile.TryGet(out chromaticAberration))
            chromaticAberration.intensity.overrideState = true;

        if (panicVolume.profile.TryGet(out depthOfField))
        {
            depthOfField.gaussianStart.overrideState = true;
            depthOfField.gaussianEnd.overrideState = true;
        }

        if (panicVolume.profile.TryGet(out vignette))
            vignette.intensity.overrideState = true;

        if (heartBeatAudio != null)
        {
            heartBeatAudio.volume = 0f; // Start with no heartbeat
            heartBeatAudio.pitch = minHeartbeatPitch; // Set starting pitch
        }

        // Get camera reference
        mainCamera = Camera.main;
        if (mainCamera != null)
            originalCameraPos = mainCamera.transform.localPosition;
    }

    void Update()
    {
        if (panicMode)
        {
            float distance = Vector3.Distance(player.position, panicTriggerObject.position);
            float intensity = Mathf.Clamp01(distance / maxEffectDistance); // Normalize 0-1

            // Increase Chromatic Aberration
            if (chromaticAberration != null)
                chromaticAberration.intensity.value = Mathf.Lerp(0, maxAberration, intensity);

            // Increase Blur (Depth of Field)
            if (depthOfField != null)
            {
                depthOfField.gaussianStart.value = Mathf.Lerp(10f, 1f, intensity);
                depthOfField.gaussianEnd.value = Mathf.Lerp(50f, 5f, intensity);
            }

            // Increase Vignette (Tunnel Vision)
            if (vignette != null)
                vignette.intensity.value = Mathf.Lerp(0, maxVignetteIntensity, intensity);

            // Increase Heartbeat Volume
            if (heartBeatAudio != null)
            {
                if (!heartBeatAudio.isPlaying) // Ensure it's playing
                    heartBeatAudio.Play();

                heartBeatAudio.volume = Mathf.Lerp(0, 1f, intensity);
                heartBeatAudio.pitch = Mathf.Lerp(minHeartbeatPitch, maxHeartbeatPitch, intensity);
            }

            // Camera Shake
            if (mainCamera != null)
            {
                float shakeAmount = Mathf.Lerp(0, maxCameraShake, intensity);
                mainCamera.transform.localPosition = originalCameraPos + Random.insideUnitSphere * shakeAmount;
            }
        }
        else
        {
            // Reset effects
            if (chromaticAberration != null)
                chromaticAberration.intensity.value = 0;

            if (depthOfField != null)
            {
                depthOfField.gaussianStart.value = 10f;
                depthOfField.gaussianEnd.value = 50f;
            }

            if (vignette != null)
                vignette.intensity.value = 0;

            if (heartBeatAudio != null)
            {
                heartBeatAudio.volume = 0;
                heartBeatAudio.pitch = minHeartbeatPitch;
            }

            // Reset Camera Position
            if (mainCamera != null)
                mainCamera.transform.localPosition = originalCameraPos;
        }
    }
}
