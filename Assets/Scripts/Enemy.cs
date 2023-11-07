using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
[SerializeField]Transform eyes;
bool seesPlayer;
bool shoot;
[SerializeField] LayerMask player;





 

    void Update()
    {
        



        
    }


   public void SeePlayer(Vector3 eyePos, Vector3 playerPos){
        
        RaycastHit2D hitInfo = Physics2D.Raycast(eyePos, playerPos);
        
        if(hitInfo.collider != null){
            if(hitInfo.transform.gameObject.layer == player){
                seesPlayer = true;
            }else{
                seesPlayer = false;
            }


        }

    }





}
