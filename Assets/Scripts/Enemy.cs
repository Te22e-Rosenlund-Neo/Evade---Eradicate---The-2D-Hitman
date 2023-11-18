using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
[SerializeField]Transform Eyes;
[SerializeField] LayerMask PlayerLayer;
[SerializeField] Transform PlayerTr;
[SerializeField] LayerMask EnemyLayer;
[SerializeField] GameObject Bullet;
[SerializeField] Transform Gun1;
[SerializeField] Transform Gun2;

bool SeesPlayer;
float ShootTimer = 0.6f;
public int Health = 3;
Vector2 FaceDir;
public Animator Animator;



    
 

    void Update()
    {
        //removes enemy
        if(Health <= 0){
            Destroy(gameObject);
        }
            
        
        FaceDir = PlayerTr.transform.position - transform.position;
        SeePlayer(Eyes.position, PlayerTr.position);

        //när motståndaren ser spelaren, ska den vända sig mot den, och börja skjuta mot den. 
        if(SeesPlayer == true){
            
            if(PlayerTr.position.x > transform.position.x){
                transform.right = new Vector3(1,0,0);
            }else if(PlayerTr.position.x < transform.position.x){
                transform.right = new Vector3(-1,0,0);
            }

            if(ShootTimer < 0){
                Animator.SetBool("Shoot", true);
                Shoot();
                ShootTimer = 1f;
            }else{
                Animator.SetBool("Shoot", false);
            }


    ShootTimer -= Time.deltaTime;
        }


    //skapar bulletsen som går mot spelarens position vid avfyrning
    }
    private void Shoot(){
        Instantiate(Bullet, Gun1.position, Quaternion.identity);
        Instantiate(Bullet, Gun2.position, Quaternion.identity);

    }

   public void SeePlayer(Vector3 eyePos, Vector3 playerPos){
        
//Om spelaren är tillräckligt nära motståndaren ska motståndaren börja kolla om den kan se den (för performance, och så den bara ser oss ifall dne är på skärmen)
    if(Vector2.Distance(PlayerTr.position, transform.position) < 9){

//skickar en raycast mot spelaren. om ingenting är i vägen ser motståndaren den. EnemyLayer är alla lager som skall skippas
        RaycastHit2D hitInfo = Physics2D.Raycast(eyePos, FaceDir,Vector2.Distance(eyePos,playerPos), ~EnemyLayer);
        
        if(hitInfo.collider != null){

            if(hitInfo.transform.gameObject.name == "Player"){
                SeesPlayer = true;
            }else{
                SeesPlayer = false;
            }


        }
    }
    }

         private void OnDrawGizmos() {

                Gizmos.color = Color.red;
            Gizmos.DrawLine(Eyes.position, PlayerTr.position);
        }




}
