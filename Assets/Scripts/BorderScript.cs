using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    [SerializeField] string PlayerTag;
    [SerializeField] string EnemyTag;
    [SerializeField] float Speed;

    void Update()
    {

        
        transform.localScale += new Vector3(Speed, 0, 0) * Time.deltaTime;




    }

private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag == PlayerTag || other.tag == EnemyTag){
        Destroy(other.gameObject);
    }
}
}
