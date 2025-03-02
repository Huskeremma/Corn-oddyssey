using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public Rigidbody2D body;
    [Header("Movement")]
    public float speed = 5f;
    float horizontalMovement;
    [Header("Jumping")]
    float jump = 10f;

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
}
