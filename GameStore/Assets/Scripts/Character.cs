using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] public float speed = 1f;
     public Vector2 direction;
     private float moveSpeed = 4f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        transform.Translate(direction*moveSpeed*Time.deltaTime);
    }
}
