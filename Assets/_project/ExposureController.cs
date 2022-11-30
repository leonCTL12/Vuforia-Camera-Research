using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class ExposureController : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _postProcessVolume;
    private ColorGrading _colorGrading;

    private Slider m_Silder;
    private void Awake()
    {
        m_Silder = GetComponent<Slider>();
    }

    void Start()
    {
        _postProcessVolume.profile.TryGetSettings(out _colorGrading);
        m_Silder.onValueChanged.AddListener(delegate(float value) { AdjustExposure(value); });
    }

    private void AdjustExposure(float percentage)
    {
        float v = percentage * 10 - 5;
        Debug.Log(v);
        FloatParameter floatParameter = new FloatParameter()
        {
            value = v
        };
        _colorGrading.postExposure.value = floatParameter;
    }
}
