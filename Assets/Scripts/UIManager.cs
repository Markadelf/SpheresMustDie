using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager manager;

    public GameObject Death;
    public GameObject Victory;

	// Use this for initialization
	void Start () {
        Victory.SetActive(false);
        Death.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!FirstPerson.PLAYER)
        {
            Death.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.L))
        //if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LaunchScene");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }


    public void DeclareVictory()
    {
        Victory.SetActive(true);
    }

}
