using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public bool NotFloor = false;
    public Vector2 movementDirection = new Vector2(-1f, 0f);
    public float movementSpeed = 0.1f;
    public Transform player;
    
    private Vector3 initialPosition;

    void start(){
        initialPosition = transform.position;
    }
    
    void Update()
    {
        if(NotFloor  ==  true){
            transform.position += (Vector3)movementDirection.normalized * movementSpeed * Time.deltaTime;
        }else{
            Vector3 offset = player.position * movementSpeed;
            transform.position = initialPosition + new Vector3(offset.x, -2f, 0);
        }
        transform.position += (Vector3)movementDirection.normalized * movementSpeed * Time.deltaTime;
    }
}
