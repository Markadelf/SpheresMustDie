using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LaunchUIManger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LaunchScene");
        }
	}


    public void StartGame()
    {
        SceneManager.LoadScene("Hub");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits-Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
