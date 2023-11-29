using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{




[SerializeField] String PlayerTag;

private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == PlayerTag){
        GameObject.Find("PassThrough").GetComponent<PassThroughScript>().StarCount ++;
        Destroy(gameObject);
    }
}



}
