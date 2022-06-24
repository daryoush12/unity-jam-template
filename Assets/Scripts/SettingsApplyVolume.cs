using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using ScriptableObjectArchitecture;

public class SettingsApplyVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioListener;
    [SerializeField] private FloatVariable _master;
    [SerializeField] private FloatVariable _background;
    [SerializeField] private FloatVariable _sfx;

    private float currentMaster;
    private float currentBackground;
    private float currentSFX;

    private void OnEnable()
    {
        GetCurrentValues();

        _master.Value = currentMaster;
        _background.Value = currentBackground;
        _sfx.Value = currentSFX;
    }

    private void FixedUpdate()
    {

        GetCurrentValues();

        if (currentMaster != _master.Value)
            audioListener.SetFloat("Master", _master.Value);
        if (currentBackground != _background.Value)
            audioListener.SetFloat("Background", _background.Value);
        if (currentSFX != _sfx.Value)
            audioListener.SetFloat("SFX", _sfx.Value);

    }

    private void GetCurrentValues()
    {
        audioListener.GetFloat("Background", out currentBackground);
        audioListener.GetFloat("SFX", out currentSFX);
        audioListener.GetFloat("Master", out currentMaster);
    }
}
