using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class textScript : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI Tmp;
    
    // Update is called once per frame
    void Update()
    {
        
        Tmp.text = Convert.ToString(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Health);

    }
}
