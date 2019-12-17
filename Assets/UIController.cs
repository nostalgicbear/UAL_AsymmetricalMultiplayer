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


    public GameObject panel1,panel2;

    #region second puzzle
    public GameObject textField;

    public GameObject nonVRPlayerPuzzle1, nonVRPlayerPuzzle2;
    public GameObject letMeBeYourEyes;

    public Text inputtedCode;

    private string code = "85966";

    public GameObject victoryText;

    #endregion
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

    public void EnableSecondPuzzle()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        
        
        textField.SetActive(true);
        letMeBeYourEyes.SetActive(false);
        slider.SetActive(false);


        nonVRPlayerPuzzle1.SetActive(false);
        nonVRPlayerPuzzle2.SetActive(true);

    }

    public void ValidateCode()
    {
        if(inputtedCode.text == code)
        {
            victoryText.SetActive(true);
        }
    }

   


}
