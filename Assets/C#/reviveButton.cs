using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class reviveButton : MonoBehaviour
{
    public void OnClick()
    {
        if (Input.GetMouseButton(0))
            SceneManager.LoadScene("jump");
    }
   
}