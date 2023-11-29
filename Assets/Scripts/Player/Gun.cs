using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.MPE;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject GunObj;
    [SerializeField] string EnemyTag;
    [SerializeField] LayerMask Player;
    Vector3 Direction;  
   
    void Update()
    {
       //makes our gun point towards the mouse position
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = GunObj.transform.position - MousePosition;
        GunObj.transform.up = Direction;

        //Shows a bullet trail 
        if(Input.GetButtonDown("Fire1")){
            GetComponentInChildren<PlayerBullet>().ShowBullet = true;
            }
        //Shoots and disables bullet trail
        if(Input.GetButtonUp("Fire1")){
           Fire(GunObj.transform.position, Direction);  
            GetComponentInChildren<PlayerBullet>().ShowBullet = false;         
        }        
    }
  


    public void Fire(Vector3 OriginPos, Vector3 ShootDir){
        
        //shoots raycast from gun in direction to mouse
        RaycastHit2D Hit = Physics2D.Raycast(OriginPos, -ShootDir, 20, ~Player);
       
        //checks if we hit player, and then removes health.
        if(Hit.collider != null){
            if(Hit){
                    if(Hit.collider.gameObject.tag == EnemyTag){
                        Hit.collider.GetComponent<Enemy>().Health -= 3;
                    }
            }
        }

    }
   

  
    


}
