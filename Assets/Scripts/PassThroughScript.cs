using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PassThroughScript : MonoBehaviour
{
  
    public int StarCount;
    public bool Win;
    [SerializeField] TextMeshProUGUI tmp;
    private int AmountOfStars;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        AmountOfStars = GameObject.FindGameObjectsWithTag("Star").Length;
    }
    void Update(){
        Scene CurrentScene = SceneManager.GetActiveScene();
        if(CurrentScene.buildIndex == 2){
            
        tmp = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

        if(StarCount >= AmountOfStars){
            Win = true;
        }
        
        if(Win == true){
            tmp.text = "You Won!";
        }else if(Win == false){
            tmp.text = "You Lost!";
        }
    }
    }
    // Update is called once per fram
}
