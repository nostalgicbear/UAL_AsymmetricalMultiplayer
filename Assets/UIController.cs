using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class UIController : MonoBehaviour {
    private static UIController _instance;
    public static UIController Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [FormerlySerializedAs("slidwableWall")]
    public Transform slideableWall;
    Vector3 startValue;
    public GameObject slider;
    private void Start()
    {
        startValue = slideableWall.position;
    }

    /// <summary>
    /// Called when the slider is changed (Called from the slider OnValueChanged function)
    /// </summary>
    /// <param name="newValue"></param>
    public void Slider_Changed(float newValue)
    {
        Vector3 wallPos = startValue;
        wallPos.z = startValue.z + newValue;
        slideableWall.position = wallPos;
    }

    /// <summary>
    /// Turns on the slider
    /// </summary>
    public void EnableSlider()
    {
        slider.SetActive(true);
    }

   


}
