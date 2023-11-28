using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

[SerializeField] string PlayerTag;
[SerializeField] string StarTag;
[SerializeField] string LadderTag;
public float ShotSpeed = 10; 
float TimeAlive = 0;
Transform PlayerTr;




    void Start(){
        //turns the bullet to face where the player was when the object was instantiated, does it once
        PlayerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector2 Direction = PlayerTr.position - transform.position;
        transform.up = Direction;

    }

    void Update()
    {
        //moves the projectile forward
        Vector2 ShotMove = new Vector2(0, ShotSpeed) * Time.deltaTime;
        transform.Translate(ShotMove);

        //Destroys the bullet after 2 seconds if it hasnt hit anything
        if(TimeAlive > 2f){
            Destroy(gameObject);
        }
    
    TimeAlive += Time.deltaTime;
    }



  private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == PlayerTag){
            other.GetComponent<PlayerMovement>().Health --;
            Destroy(gameObject);
        }else if(other.tag != StarTag && other.tag != LadderTag){
            Destroy(gameObject);
        }
  }
}
