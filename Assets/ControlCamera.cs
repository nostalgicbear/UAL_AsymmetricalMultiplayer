using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlCamera : MonoBehaviour {
    float yRotation;
    public float yMax, yMin = 10.0f;
    public bool attaching = false;
    Vector3 startAngle;
    public float currentY;
    // Use this for initialization
    void Start () {
		
	}


    public void SetCameraAttached(Vector3 sAngle)
    {
        attaching = true;
        startAngle = sAngle;
        yMax = startAngle.y + 10.0f;
        yMin = startAngle.y - 10.0f;
        StartCoroutine(SetAttaching());
    }

    IEnumerator SetAttaching()
    {
        yield return new WaitForSeconds(1.0f);
        attaching = false;
    }
}
