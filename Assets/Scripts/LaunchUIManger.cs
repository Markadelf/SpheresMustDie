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
		
	}


    public void StartGame()
    {
        SceneManager.LoadScene("Boss 1");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits-Sceme");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
