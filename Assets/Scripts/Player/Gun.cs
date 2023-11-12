using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.MPE;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject gun;
    
    Vector3 Direction;
    [SerializeField] string EnemyTag;
    [SerializeField] LayerMask Player;
    
    void Update()
    {
       //makes our gun point towards the mouse position
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = gun.transform.position - MousePosition;
        gun.transform.up = Direction;


        if(Input.GetButtonDown("Fire1")){
           GetComponentInChildren<PlayerBullet>().ShowBullet = true;
           fire(gun.transform.position, Direction);           
        }else{
             GetComponentInChildren<PlayerBullet>().ShowBullet = false;
        }

        


    }

    public void fire(Vector3 OriginPos, Vector3 ShootDir){
        
        RaycastHit2D HitInfo = Physics2D.Raycast(OriginPos, ShootDir, ~Player);
       
        
        if(HitInfo.collider != null){
            if(HitInfo){
                    Debug.Log(HitInfo.transform.name);
                        if(HitInfo.collider.gameObject.tag == EnemyTag){
                            HitInfo.collider.GetComponent<Enemy>().Health -= 3;
                    }
            }
        }

    }
   

  
    


}
