using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CameraMovement camMovement;

    public KeyCode upB = KeyCode.W;
    public KeyCode downB = KeyCode.S;
    public KeyCode leftB = KeyCode.A;
    public KeyCode rightB = KeyCode.D;
    public KeyCode run = KeyCode.LeftShift;

    Vector2 up = new Vector2(0, 1);
    Vector2 down = new Vector2(0, -1);
    Vector2 left = new Vector2(-1, 0);
    Vector2 right = new Vector2(1, 0);
    

    public float speed = 3f;

    private Animator anim;

    float borderUp = 17.5f;
    float borderDown = -17.5f;
    float borderLeft = -30;
    float borderRight = 30;

    bool canUp = true;
    bool canDown = true;
    bool canLeft = true;
    bool canRight = true;

    bool isSwitcht = false;
    void Start()
    {
        anim = GetComponent<Animator>();  
        camMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Confines the player to the current field
        Vector2 player = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
       if (player.x >= borderRight)
        {
            canRight = false;
        }
       else
        {
            canRight = true;
        }
       if(player.x <= borderLeft)
        {
            canLeft = false;
        }
        else
        {
            canLeft = true;
        }
       if(player.y >= borderUp)
        {
            canUp = false;
        }
        else
        {
            canUp = true;
        }
       if(player.y <= borderDown)
        {
            canDown = false;
        }
        else
        {
            canDown = true;
        }
        //When player press runKey than improve speed and set the Run animation when the run key pressed or when not set the walk animation
        if (Input.GetKey(run))
        {
            speed = 10;
            anim.SetBool("Run", true);
            anim.SetBool("Walk", false);
            anim.SetBool("Stand", false);
        }
        else
        {
            speed = 5;
            anim.SetBool("Run", false);
            anim.SetBool("Walk", true);
        }

        
        //Movement of the player
        if (Input.GetKey(upB) && canUp)
        {
            this.gameObject.transform.Translate(up * speed * Time.deltaTime);
            anim.SetBool("Stand", false);
        }

        if (Input.GetKey(downB) && canDown)
        {
            this.gameObject.transform.Translate(down * speed * Time.deltaTime);
            anim.SetBool("Stand", false);
        }

        if (Input.GetKey(leftB) && canLeft)
        {
            this.gameObject.transform.Translate(left * speed * Time.deltaTime);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("Stand", false);

        }

        if (Input.GetKey(rightB) && canRight)
        {
            this.gameObject.transform.Translate(right * speed * Time.deltaTime);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("Stand", false);
        }

        //When the player stand set animator to stand animation
        if (Input.GetKey(upB) == false && Input.GetKey(downB) == false && Input.GetKey(leftB) == false && Input.GetKey(rightB) == false)
        {
            anim.SetTrigger("Stand");
            anim.SetBool("Walk", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        //Moved the cam by switch the room And Moved the scale of the room for the player that he can walk
        if(other.gameObject.name == "DoorLeft" && !isSwitcht)
        {
            isSwitcht = true;
            //Player
            this.gameObject.transform.Translate(-7, 0, 0);
            borderLeft -= 64;
            borderRight -= 64;
            

            //Cam
            camMovement.leftBorder -= 64;
            camMovement.rightBorder -= 64;
            
            
        }
         if(other.gameObject.name == "DoorRight" && !isSwitcht)
        {
            isSwitcht=true;
            //Player
            this.gameObject.transform.Translate(7, 0, 0);
            borderRight += 64;
            borderLeft += 64;
            

            //Cam
            camMovement.leftBorder += 64;
            camMovement.rightBorder += 64;
            
            
        }
         if(other.gameObject.name == "DoorUp" && !isSwitcht)
        {
            isSwitcht=true;
            //Player
            this.gameObject.transform.Translate(0, 7, 0);
            borderUp += 36;
            borderDown += 36;
            

            //Cam
            camMovement.topBorder += 36;
            camMovement.bottomBorder += 36;
            
            
        }
         if(other.gameObject.name == "DoorDown" && !isSwitcht)
        {
            isSwitcht = true;
            //Player
            this.gameObject.transform.Translate(0, -7, 0);
            borderDown -= 36;
            borderUp -= 36;
            

            //Cam
            camMovement.topBorder -= 36;
            camMovement.bottomBorder -= 36;

            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "DoorLeft" && isSwitcht)
        {
            isSwitcht = false;
            


        }
        if (other.gameObject.name == "DoorRight" && isSwitcht)
        {
            isSwitcht = false;
            


        }
        if (other.gameObject.name == "DoorUp" && isSwitcht)
        {
            isSwitcht = false;
            


        }
        if (other.gameObject.name == "DoorDown" && isSwitcht)
        {
            isSwitcht = false;
           


        }
    }
    void Inventar()
    {

    }
    void PickUp()
    {

    }

}
