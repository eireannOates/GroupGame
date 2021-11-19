using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Driver_New_Control : MonoBehaviour
{
    //ground check
    public Transform groundCheck;
    public float groundDistance = 0.55f;
    public Text GroundText;


    public float Acceleration = 5000;

    public float BreakingForce = 3000;

    [SerializeField]
    private float CurrAcceleration = 0f;

    private float CurrBreakForce = 0f;

    public float LoseSpeed = -200000f;

    //steering 
    private float CurrSteeringAngle;

    //the max amount of steering angle
    [SerializeField] private float MaxSteeringAngle;

    //Ref the Wheel colliders.
    [SerializeField] private WheelCollider FrontLeftWheelCollider;
    [SerializeField] private WheelCollider FrontRightWheelCollider;
    [SerializeField] private WheelCollider BackLeftWheelCollider;
    [SerializeField] private WheelCollider BackRightWheelCollider;

    //Ref to Wheels
    [SerializeField] private Transform FrontLeftWheelTransform;
    [SerializeField] private Transform FrontRightWheelTransform;
    [SerializeField] private Transform BackLeftWheelTransform;
    [SerializeField] private Transform BackRightWheelTransform;

    private void Update()
    {
        GroundCheck();
    }

    // used for wheel collider to work
    private void FixedUpdate()
    {
        //wheels movement
        HandelMotor();

        //wheel rotaion
        HandelSteering();

        //wheel visauls 
        UpdateWheels();

    }

    private void HandelSteering()
    {
        //Turing based on max turing of wheel and the input for Horizon
        CurrSteeringAngle = MaxSteeringAngle * Input.GetAxis("Horizontal");

        //turning car wheel
        FrontLeftWheelCollider.steerAngle = CurrSteeringAngle;
        FrontRightWheelCollider.steerAngle = CurrSteeringAngle;
    }

    //for car movement
    private void HandelMotor()
    {
        //stoping power/when breaking stop car
        if (Input.GetKey(KeyCode.Space))
        {
            CurrBreakForce = BreakingForce;
        }
        else
        {
            CurrBreakForce = 0f;
        }

        // when you let go of movement speed will go down by LoseSpeed but if 0 or less then = 0 to prevent going backwards
        if ((Input.GetKey(KeyCode.O)) || (Input.GetKey(KeyCode.P)))
        {

        }
        else
        {
            CurrBreakForce = 6000;
        }

        // off ground the stop wheels
        if (IsGrounded)
        {
            //movemnet forward and backwards
            CurrAcceleration = Acceleration * Input.GetAxis("Vertical");
        }
        else
        {
            CurrBreakForce = 1000000;
        }

        //movement of the wheels
        FrontLeftWheelCollider.motorTorque = CurrAcceleration;
        FrontRightWheelCollider.motorTorque = CurrAcceleration;
        BackLeftWheelCollider.motorTorque = CurrAcceleration;
        BackRightWheelCollider.motorTorque = CurrAcceleration;

        //stoping car movement
        FrontLeftWheelCollider.brakeTorque = CurrBreakForce;
        FrontRightWheelCollider.brakeTorque = CurrBreakForce;
        BackLeftWheelCollider.brakeTorque = CurrBreakForce;
        BackRightWheelCollider.brakeTorque = CurrBreakForce;

    }

    //change in game whhels to turn with collider
    private void UpdateWheels()
    {
        //start of wheel update
        updateSingleWheel(FrontLeftWheelCollider, FrontLeftWheelTransform);
        updateSingleWheel(FrontRightWheelCollider, FrontRightWheelTransform);
        updateSingleWheel(BackLeftWheelCollider, BackLeftWheelTransform);
        updateSingleWheel(BackRightWheelCollider, BackRightWheelTransform);
    }

    private void updateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        //upadte object wheels
        Vector3 pas;
        Quaternion rat;
        wheelCollider.GetWorldPose(out pas, out rat);
        wheelTransform.rotation = rat;
        wheelTransform.position = pas;
    }

    public bool IsGrounded = false;
    void GroundCheck()
    {

        if (Physics.Raycast(groundCheck.transform.position, Vector3.down, groundDistance + 0.1f))
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
