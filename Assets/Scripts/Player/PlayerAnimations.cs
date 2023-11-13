using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    
    public Animator Animator;


    void Update()
    {
        //Transitions to Running animation
        Animator.SetFloat("MoveSpeed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
       




        //Transistions to jumping phase, if player is no longer on the ground
        if(GetComponent<PlayerMovement>().IsGrounded == false && GetComponent<LadderMovement>().IsClimbing == false){

            Animator.SetBool("Jumping", true);
        }else{
            Animator.SetBool("Jumping", false);
        }

        
        if(GetComponent<PlayerMovement>().sliding == true){
            Animator.SetBool("Sliding", true);
        }else{
            Animator.SetBool("Sliding", false);
        }




    }
}
