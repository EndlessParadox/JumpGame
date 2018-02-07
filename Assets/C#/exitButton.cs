using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class exitButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))

            Application.Quit();
           // print("游戏退出");

    }
}