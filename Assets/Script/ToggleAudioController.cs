using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToggleAudioController : MonoBehaviour
{
    [Header("References")]
    public AudioMixer audioMixer;
    public Toggle toggleAudio;

    [Header("Mixer Parameters")]
    public string volumeParams = string.Empty;

    private void OnEnable()
    {
        toggleAudio.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        toggleAudio.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(bool enabled)
    {
        audioMixer.SetFloat(volumeParams, enabled ? 0f : -80f);
    }
}
