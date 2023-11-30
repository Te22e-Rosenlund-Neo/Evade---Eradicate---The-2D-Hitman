using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    [SerializeField] string PlayerTag;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == PlayerTag){
            SceneManager.LoadSceneAsync(2);
        }
   }
}
