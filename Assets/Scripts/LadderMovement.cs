using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D RB;
    [SerializeField] string LadderTag;
    float LadderSpeed = 5f;
    public bool IsClimbing = false;

    
    void Update()
    {
        float VerticalMove = Input.GetAxisRaw("Vertical");
        
        if(IsClimbing == true){
            RB.gravityScale = 0f;
            animator.SetBool("OnLadder", true);
            RB.velocity = new Vector2( 0 , LadderSpeed * VerticalMove);
        }else{
            animator.SetBool("OnLadder", false);
            RB.gravityScale = 6f;
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
