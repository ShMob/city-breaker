using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ShowLevel(string level)
    {
        Debug.Log("level menu!");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
