using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Animator animator;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    [SerializeField] private Stat health;
    [SerializeField] private float initialHealth;

    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private void Awake() 
    {
        playerInput = new PlayerInput();
        health.Initialize(initialHealth, initialHealth);
    }

    private void OnEnable() 
    {
        playerInput.Enable();
    }

    private void OnDisable() 
    {
        playerInput.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        // If movement is not 0, try to move
        if(movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if(!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));
                if(!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }
        }
        else{
            animator.SetLayerWeight(1, 0);
        }

        if(Keyboard.current.oKey.wasPressedThisFrame)
        {
            health.MyCurrentValue += 10;
        }
        if(Keyboard.current.iKey.wasPressedThisFrame)
        {
            health.MyCurrentValue -= 10;
        }
        
    }


    private bool TryMove(Vector2 direction)
    {
        // Check collisions
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset);
        
        if(count == 0){
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            AnimateMovement(direction);
            return true;
        } 
        else
        {
            animator.SetLayerWeight(1, 0);
            return false;
        }

        
    }
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    public void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1,1);
        //Sets the animation parameter so that he faces the correct direction
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }

}

