using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static Camera Camera;
    public GameObject CurrentLevel;
    private static GameManager _instance;


    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
        Camera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickReplay()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
