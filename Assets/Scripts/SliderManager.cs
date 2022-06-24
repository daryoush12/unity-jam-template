using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.UI;
using System;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private FloatVariable _slideValue;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.value = _slideValue.Value;
        _slider.onValueChanged.AddListener(SetVariable);
    }

    private void SetVariable(float v)
    {
        _slideValue.Value = v;
    }
}
