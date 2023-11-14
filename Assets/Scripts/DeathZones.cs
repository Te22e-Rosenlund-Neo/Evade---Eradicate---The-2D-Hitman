using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZones : MonoBehaviour
{
    [SerializeField] string PlayerTag;
    [SerializeField] GameObject Player;
    Vector2 SpawnPosition = new Vector2(-3.6f, -1.21f);

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == PlayerTag){
            Player.transform.position = SpawnPosition;
        }



    }


}
