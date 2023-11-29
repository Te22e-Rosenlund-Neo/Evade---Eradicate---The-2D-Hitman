using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class textScript : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI First;
    [SerializeField] TextMeshProUGUI Second;
    
    // Update is called once per frame
    void Update()
    {
        
        First.text = Convert.ToString(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Health);
        Second.text = Convert.ToString($"{GameObject.Find("PassThrough").GetComponent<PassThroughScript>().StarCount}/14");
    }
}
