using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    [SerializeField] Animator Animator;
    [SerializeField] Rigidbody2D Rb;
    [SerializeField] string LadderTag;
    float LadderSpeed = 5f;
    public bool IsClimbing = false;

    
    void Update()
    {
        float VerticalMove = Input.GetAxisRaw("Vertical");
        
        if(IsClimbing == true){
            Rb.gravityScale = 0f;
            Animator.SetBool("OnLadder", true);
            Rb.velocity = new Vector2( 0 , LadderSpeed * VerticalMove);
        }else{
            Animator.SetBool("OnLadder", false);
            Rb.gravityScale = 6f;
        }


    }



    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == LadderTag){
            IsClimbing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == LadderTag){
            IsClimbing = false;
        }
}
}
