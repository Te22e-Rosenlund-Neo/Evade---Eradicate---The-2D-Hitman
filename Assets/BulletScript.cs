using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
public float ShotSpeed = 10; 
float TimeAlive = 0;
Transform PlayerTr;

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
}
