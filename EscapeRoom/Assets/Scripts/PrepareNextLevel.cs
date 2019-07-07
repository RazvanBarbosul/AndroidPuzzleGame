using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareNextLevel : MonoBehaviour {
    public GameObject BackWall;
    public Transform NewCameraPos;
    public GameObject OldWall;
    public GameObject PreviousLevel;
    private bool ShouldMoveCamera;
    
    
	// Use this for initialization
	void Start () {
        ShouldMoveCamera = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(ShouldMoveCamera && NewCameraPos.position != GameManager.Camera.transform.position)
        {
            GameManager.Camera.transform.position = Vector3.Lerp(GameManager.Camera.transform.position, NewCameraPos.position, Time.deltaTime * 2.0f);
        }

        if(NewCameraPos.position == GameManager.Camera.transform.position)
        {
            ShouldMoveCamera = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            BackWall.SetActive(true);
            BackWall.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(ShouldLerpCamera());
            OldWall.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(DestroyPreviousLevel());
        }
    }
    IEnumerator ShouldLerpCamera()
    {
        ShouldMoveCamera = true;
        yield return 0;
    }

    IEnumerator DestroyPreviousLevel()
    {
        yield return new WaitForSeconds(2.0f);
        if (PreviousLevel)
        {
           Destroy(PreviousLevel, 3.0f);
        }
    }
    
}
