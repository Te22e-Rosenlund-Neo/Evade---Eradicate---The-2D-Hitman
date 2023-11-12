using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
public float ShotSpeed = 10; 
float TimeAlive = 0;
Transform PlayerTr;
[SerializeField] string PlayerTag;

    void Start(){
        PlayerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector2 Direction = PlayerTr.position - transform.position;
        transform.up = Direction;

    }

    void Update()
    {
        Vector2 ShotMove = new Vector2(0, ShotSpeed) * Time.deltaTime;
        transform.Translate(ShotMove);

        if(TimeAlive > 2f){
            Destroy(gameObject);
        }
    
    TimeAlive += Time.deltaTime;
    }

  private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == PlayerTag){
        other.GetComponent<PlayerMovement>().Health --;
        Destroy(gameObject);
    }
  }




}
