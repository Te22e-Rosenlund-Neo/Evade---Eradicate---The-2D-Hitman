using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PassThroughScript : MonoBehaviour
{
  
    public int StarCount;
    public bool Win;
    [SerializeField] TextMeshProUGUI tmp;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update(){
        Scene CurrentScene = SceneManager.GetActiveScene();
        if(CurrentScene.buildIndex == 2){
            
        tmp = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        
        if(Win == true){
            tmp.text = "You Won!";
        }else if(Win == false){
            tmp.text = "You Lost!";
        }
    }
    }
    // Update is called once per fram
}
