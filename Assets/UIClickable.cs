using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIClickable : MonoBehaviour {
    public int id;

    public Image buttonImage;
    private List<Color> colors;

    private int index = 0;

    private void Start()
    {
        buttonImage = GetComponent<Image>(); //This is the component that will change colour when clicked
        colors = ColorPuzzleManager.Instance.colors;
    }

    /// <summary>
    /// Called from the buttons OnClick event. Changes color when clicked
    /// </summary>
    public void SetNextColour()
    {
        index++;
        if(index > colors.Count-1)
        {
            index = 0;
        }

        buttonImage.color = colors[index];

        ColorPuzzleManager.Instance.ValidateResults();
    }

}
