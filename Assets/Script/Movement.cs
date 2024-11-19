using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 7f;

    private Rigidbody2D body;
    public Animator anim;
    public Spawner SP;

    [SerializeField] private bool isGrounded;
    private bool isMoving;
    
    void Start(){
        
    }

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }

    private void Update(){
        body.velocity  =  new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        if (body.velocity.x > 0.01f){
            transform.localScale = Vector3.one;
            if (!isMoving){ 
                isMoving = true;
            }
        }else if (body.velocity.x < -0.01f){
            transform.localScale = new Vector3(-1, 1, 1);
            if (!isMoving){
                isMoving = true;
            }
        }else{
            isMoving = false;
        }    

        anim.SetBool("Run", body.velocity.x != 0);
        anim.SetBool("Grounded", isGrounded);

        if(Input.GetKey(KeyCode.Space) && isGrounded){
            Jump();
            anim.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Ground")){
            isGrounded = true;
            SP.Spawn();
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.collider.CompareTag("Ground")){
            isGrounded = false;
        }
    }
}
