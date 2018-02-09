using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour {

    public Button btnExit;
    public Button btnRevive;

    public Slider Slider;
	void Start () {

       btnExit.onClick.AddListener(Exit);
       btnRevive.onClick.AddListener(Revive);

    }

    void Revive()
    {
  
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
       
    }
}
