using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
[SerializeField]Transform eyes;
bool seesPlayer;
bool shoot;
Vector2 FaceDir;
[SerializeField] LayerMask playerLayer;
[SerializeField] Transform PlayerTr;
[SerializeField] LayerMask EnemyLayer;



    
 

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

        }


        
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
