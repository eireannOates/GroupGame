using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour
{
    public GameObject car;

    public float speedV = 2.5f;

    public float pitch = -90f;

    public float speedH1 = 2.5f;

    private float yaw1 = 0.0f;

    private float carR;


    //max rotaion
    private float MaxRot = 80;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        pitch = speedV * Input.GetAxis("Mouse Y");

        yaw1 = speedH1 * Input.GetAxis("Mouse X");
        
        
        //transform.eulerAngles = new Vector3(pitch, yaw1,carR);

        //roation of the gun all the time not current, current = lock, all the time = based on what should happenb with no code
        Quaternion originalRot = transform.rotation; 

        transform.rotation = originalRot * Quaternion.AngleAxis(yaw1, Vector3.forward);
        transform.rotation = originalRot * Quaternion.AngleAxis(pitch, Vector3.left);

    }
}
