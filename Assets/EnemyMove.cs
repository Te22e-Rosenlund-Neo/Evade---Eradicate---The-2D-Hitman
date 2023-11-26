using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

[SerializeField] string BarrierTag;
[SerializeField] float MoveSpeed;
[SerializeField] Animator Animator;

void Update(){
    if(GetComponent<Enemy>().SeesPlayer == false){
        Animator.SetFloat("Velocity", 1);
    }else{
        Animator.SetFloat("Velocity", 0);
    }
}



 void FixedUpdate() {
    Vector2 Move = new Vector2(MoveSpeed, 0) * Time.deltaTime;
    transform.Translate(Move);

}




private void OnTriggerEnter2D(Collider2D other) {
    if(GetComponent<Enemy>().SeesPlayer == false){
    if(other.tag == BarrierTag){
        transform.right *= -1;
    }
    }



}
}