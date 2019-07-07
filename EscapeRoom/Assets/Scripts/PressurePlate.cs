using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {
    public GameObject Wall;
    public GameObject EndScreen;
    public GameObject Joystick;
    public float WeightRequired;
    public bool IsEnd;
    float TotalWeight;
    // Use this for initialization
    void Start () {
        TotalWeight = 0.0f;
        if (SystemInfo.graphicsShaderLevel >= 45)
        {
            Debug.Log("Woohoo, decent shaders supported!");

        }
        else
        {
            Debug.Log("Woohoo, decent shaders supported!SHITSHITSHIT");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            TotalWeight += other.GetComponent<Rigidbody>().mass;
            Debug.Log("TotalWeight: " + TotalWeight + "Weight Required: " + WeightRequired);
            if(TotalWeight >= WeightRequired)
            {
                if (IsEnd)
                {
                    EndScreen.SetActive(true);
                    Joystick.SetActive(false);
                }
                else
                {
                    Wall.SetActive(false);
                }
            }
            // other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        {
            if (other.tag == "Ball")
            {
                TotalWeight -= other.GetComponent<Rigidbody>().mass;
                if(TotalWeight < WeightRequired)
                {
                    Wall.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("NAME:" + other.name);
    }
}
