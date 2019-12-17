using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puzzle2Enabler : MonoBehaviour
{
    public Transform player;
    public GameObject letMeBeYourEyes;
    public GameObject enter;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        if (distance < 2.0f)
        {
            letMeBeYourEyes.SetActive(true);
            enter.SetActive(true);
            gameObject.SetActive(false);

        }
    }
}
