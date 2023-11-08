using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
[SerializeField]Transform eyes;
bool seesPlayer;
float ShootTimer = 0.6f;
Vector2 FaceDir;
[SerializeField] LayerMask playerLayer;
[SerializeField] Transform PlayerTr;
[SerializeField] LayerMask EnemyLayer;
[SerializeField] GameObject Bullet;
[SerializeField] Transform Gun1;
[SerializeField] Transform Gun2;
public Animator Animator;



    
 

    void Update()
    {
        FaceDir = transform.position - PlayerTr.transform.position;
        SeePlayer(eyes.position, PlayerTr.position);

        if(seesPlayer == true){
            
            if(PlayerTr.position.x > transform.position.x){
                transform.right = new Vector3(1,0,0);
            }else if(PlayerTr.position.x < transform.position.x){
                transform.right = new Vector3(-1,0,0);
            }

            if(ShootTimer < 0){
                Animator.SetBool("Shoot", true);
                Shoot();
                ShootTimer = 0.6f;
            }else{
                
            }


    ShootTimer -= Time.deltaTime;
        }


        
    }
    private void Shoot(){
        Instantiate(Bullet, Gun1.position, Quaternion.identity);
        Instantiate(Bullet, Gun2.position, Quaternion.identity);

    }

   public void SeePlayer(Vector3 eyePos, Vector3 playerPos){
        



        RaycastHit2D hitInfo = Physics2D.Raycast(eyePos, FaceDir, ~EnemyLayer);
        if(hitInfo.collider != null){
            Debug.Log(hitInfo.transform.name);

            if(hitInfo.transform.gameObject.name == "Player"){
                seesPlayer = true;
            }else{
                seesPlayer = false;
            }


        }

    }

         private void OnDrawGizmos() {

                Gizmos.color = Color.red;
            Gizmos.DrawLine(eyes.position, PlayerTr.position);
        }




}
