using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
  public void OnRestart()
    {
        SceneManager.LoadScene("GamePlay_Level 1");
    }

   
}
