using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BoxManager : MonoBehaviour
{

    public int totalBallsNeeded;
    public int currentBallCount;

    public ColorSelector.ColorOption boxColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            if (other.GetComponent<Ball>().ballColor == boxColor)
            {
                currentBallCount++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            if (other.GetComponent<Ball>().ballColor == boxColor)
            {
                currentBallCount--;
            }
        }
    }
}
