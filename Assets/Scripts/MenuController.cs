using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }

    public void QuitGame()
    {

    }
}
