using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    private float inputH;
    private float inputV;
    private bool run;
    protected Joystick joystick;
    protected Joybutton joybutton;
    protected bool jump;
    // Start is called before the first frame update
    void Start()
    {
      //  anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
        run = true;
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
    } 

    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
       // anim.SetFloat("inputH", joystick.Horizontal);
      //  anim.SetFloat("inputV", joystick.Vertical);
      //  anim.SetBool("run", run);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 150f * Time.deltaTime;
        
        if (moveZ <= 0f)
        {
            moveX = 0f;
        }
        if (!jump && joybutton.Pressed)
        {
            jump = true;
          //  anim.SetBool("jump", true);
           
        }
        if (jump && !joybutton.Pressed)
        {
            jump = false;
          //  anim.SetBool("jump", false);
        }
        
        rb.velocity = new Vector3(joystick.Horizontal *2f, 
                                    rb.velocity.y,
                                    joystick.Vertical *2f); 
    }
}
