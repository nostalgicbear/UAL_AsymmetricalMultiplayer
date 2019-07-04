using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPuzzleManager : MonoBehaviour {

    public List<Color> colors;
    public List<ColorCube> colorCubes;
    public List<UIClickable> clickableButtons;
    // Use this for initialization
    private static ColorPuzzleManager _instance;

    [SerializeField]
     int totalCorrect = 0;

    public static ColorPuzzleManager Instance { get { return _instance; } }


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

    private void Start()
    {
        AssignColoursToCubes();
    }

    /// <summary>
    /// Assigns a random colour from the colors list to the cubes 
    /// </summary>
    private void AssignColoursToCubes()
    {
        foreach(ColorCube cube in colorCubes)
        {
            cube.cubeColour = SelectRandomColour();
            cube.GetComponent<MeshRenderer>().material.color = cube.cubeColour;
        }
    }

    /// <summary>
    /// Returns a random colour 
    /// </summary>
    /// <returns></returns>
    public Color SelectRandomColour()
    {
        return colors[UnityEngine.Random.Range(0, colors.Count - 1)];
    }

    /// <summary>
    /// Checks to see if the puzzle is complete
    /// </summary>
    public void ValidateResults()
    {
        int total = 0;
        for(int i = 0; i < colorCubes.Count; i++)
        {
            for(int j = 0; j < clickableButtons.Count; j++)
            {
                if(colorCubes[i].id == clickableButtons[j].id)
                {
                    bool doesColorMatch = CheckColourIsTheSame(clickableButtons[j], colorCubes[i]);
                    if(doesColorMatch)
                    {
                       
                        total++;
                    }
                }
            }
        }
        totalCorrect = total;
        
        if(totalCorrect >= 4)
        {
            //Unlock slider
            UIController.Instance.EnableSlider();
        }
    }

    private bool CheckColourIsTheSame(UIClickable button, ColorCube colCube)
    {
        if (button.buttonImage.color.Equals(colCube.cubeColour))
        {
            Debug.LogError("Color matches!");
            return true;
        }
        else {

            return false;
        }
    }
}
