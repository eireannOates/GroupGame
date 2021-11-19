using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriverController : MonoBehaviour
{
    // car speed that can be changed in game
    public float speed = 5;

    // turing float right
    private float yaw = 0f;


    private float zero = 0f;

    private float zero1 = 0f;

    // used for ground check
    public Transform groundCheck;
    public float groundDistance = 0.55f;
    public Text GroundText;
    bool isGrounded;

    //current speed
    private float currspeed;
    private float drag = -1f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    { //to move vehicle forward in world
      //Alex Code start, modified by Eireann
      //needs work, not functionable yet, isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // needs work, not functionable yet, if (isGrounded)//Alex Code End

        //always finding most recent player location
        zero = transform.localEulerAngles.x;
        zero1 = transform.localEulerAngles.z;


        //vector3 effects the 3 directions of the car, this also means that if the car face left it will move left becuse it's based on the foward direction of the car not the world.
        if (Input.GetKey(KeyCode.P)) //hold p to move forward, w is to move basde on cam location, a is left, d is right, s is oppiste to w and o is backwards.
            if(IsGrounded)
            {
                //if (Mathf.DeltaAngle )
                transform.Translate(Vector3.forward * Time.deltaTime * speed); // this moves car forward. acceliration at the start is neede plus speed boost for late
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * 10);
            }
        if (Input.GetKey(KeyCode.O))
        {
           transform.Translate(Vector3.back * Time.deltaTime * 10);
        }
        //transform.Translate(WaitUntil * Time.deltaTime * 3)
        //transform.Translate(Vector3.back * Time.deltaTime * 55);

        //rotate player

        if (Input.GetKey(KeyCode.D))
        {
            yaw += 1; // add 1 to the last yaw

            transform.eulerAngles = new Vector3(zero, yaw, zero1);

            if (Input.GetKey(KeyCode.P) == false)
                transform.Translate(Vector3.forward * Time.deltaTime * 8);

            if (Input.GetKey(KeyCode.P))
                transform.Translate(Vector3.forward * Time.deltaTime * -12);
        }
        //rotate player
        if (Input.GetKey(KeyCode.A))
        {
            yaw -= 1; // takeaway 1 to the last yaw

            //is always set to the amount but yaw is always change so y is changing all the time after D or A is pressed.
            //this could casue problems as my rotaion is allways ste to staye the same so if car fall the car will stay in it's up right postion and could be a problme later.

            if (Input.GetKey(KeyCode.P) == false)
               transform.Translate(Vector3.forward * Time.deltaTime * 8);

            if (Input.GetKey(KeyCode.P))
               transform.Translate(Vector3.forward * Time.deltaTime * -12);

            if (Input.GetKey(KeyCode.O))
                transform.Translate(Vector3.forward * Time.deltaTime * -5);

        }

       

        transform.eulerAngles = new Vector3(zero, yaw, zero1);

        GroundCheck();

    }

    public bool IsGrounded = false;

    void GroundCheck ()
    {

        if (Physics.Raycast(transform.position, Vector3.down, groundDistance + 0.1f))
        {
            GroundText.text = "IsGrounded";
            IsGrounded = true;
        }
        else
        {
            GroundText.text = "notGrounded";
            IsGrounded = false;
        }
    }
}
