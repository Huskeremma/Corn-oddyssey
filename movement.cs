using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public Rigidbody2D body;
    [Header("Movement")]
    public float speed = 5f;
    float horizontalMovement;
    [Header("Jumping")]
    public float jump = 10f;

    [Header("Crouching")]
    public Sprite astronaut_crawl;
    public Sprite astronaut_idle;


    void Update() {
        body.linearVelocity = new Vector2(horizontalMovement * speed, body.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context){
        horizontalMovement = context.ReadValue<Vector2>().x;
        
    }
    public void Jump(InputAction.CallbackContext context){
        if(context.performed){
            body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
        }
        if(context.canceled){
            body.linearVelocity = new Vector2(body.linearVelocity.x, .5f*body.linearVelocity.y);
        }
    }

    public void Crouch(InputAction.CallbackContext context){
        if(context.performed){
            gameObject.GetComponent<SpriteRenderer>().sprite = astronaut_crawl;
        }
        if(context.canceled){
            gameObject.GetComponent<SpriteRenderer>().sprite = astronaut_idle;
        }
    }
}
