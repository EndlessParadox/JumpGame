using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour {

    public Button btnExit;

    public Button btnRevive;
	// Use this for initialization
	void Start () {
        btnExit.onClick.AddListener(Exit);
  

    }

    void Exit()
    {
        Debug.LogWarning("Close!!!");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
            SceneManager.LoadScene("jump");
        if (Input.GetMouseButton(1))
            Application.Quit();
    }
}
