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
       btnRevive.onClick.AddListener(Revive);

    }

    void Revive()
    {
        Button btn = btnRevive.GetComponent<Button>();
        SceneManager.LoadScene("jump");

    }

    void Exit()
    {
        //Debug.LogWarning("Close!!!");

        Button btn = btnExit.GetComponent<Button>();
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButton(0))
        //    SceneManager.LoadScene("jump");
        //if (Input.GetMouseButton(1))
        //    Application.Quit();
    }
}
