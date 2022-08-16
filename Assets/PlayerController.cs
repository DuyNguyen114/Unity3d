using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip footstep;


    public Animator animator;
    private Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded;
    public bool dance;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Grounded();
        Jump();
        Move();
        Dance();
        //footsound();
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.grounded)
        {
            this.rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
    private void Grounded()
    {
        if(Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask))
        {
            this.grounded = true;
        }
        else
        {
            this.grounded = false;
        }
        this.animator.SetBool("jump", !this.grounded);
    }
    private void Move()
    {
        //luu gia tri hai bien vertical va horizotal, khoang gia tri tu -1 den 1
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();
        Vector3 oldPosition = this.transform.position;

        this.transform.position += movement * 0.05f;

        this.animator.SetFloat("vertical", verticalAxis);
        this.animator.SetFloat("horizontal", horizontalAxis);
        if (oldPosition != this.transform.position) footsound();
    }
    private void Dance()
    {
        dance = false;
        if (Input.GetKey("e"))
        {
            dance = true;
        }
        if (Input.GetKey("r"))
        {
            dance = false;
        }
        this.animator.SetBool("dance", dance);
    }

    void footsound()
    {
        source.clip = footstep;
        source.Play();
        Debug.Log("footsound");
    }
}
