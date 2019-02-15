using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public KeyCode Key;
    public string SceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(Key))
        {
            SceneManager.LoadScene(SceneName);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            SceneManager.LoadScene(SceneName);   
    }
}
