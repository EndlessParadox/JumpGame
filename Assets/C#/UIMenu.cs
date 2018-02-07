using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		
	}
}
