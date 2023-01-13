using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : Character
{
    private Animator myAnimator;
   
    
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    [SerializeField] private Stat health;
    [SerializeField] private float initialHealth;

    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private void Awake() 
    { 
        health.Initialize(initialHealth, initialHealth);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
        }
        Move();
        GetInput();
    }
    

    public void AnimateMovement(Vector2 direction)
    {
        myAnimator.SetLayerWeight(1,1);
        //Sets the animation parameter so that he faces the correct direction
        myAnimator.SetFloat("x", direction.x);
        myAnimator.SetFloat("y", direction.y);
    }

    

    private void GetInput()
    {
        direction = Vector2.zero;
        if(Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if(Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if(Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if(Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }
}

