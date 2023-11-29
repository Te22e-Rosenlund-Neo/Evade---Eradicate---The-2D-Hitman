using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartQuit : MonoBehaviour
{
  
    public void StartGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void Menu(){
        SceneManager.LoadSceneAsync(0);
    }

    public void Controlls(){
        SceneManager.LoadSceneAsync(3);
    }



}
