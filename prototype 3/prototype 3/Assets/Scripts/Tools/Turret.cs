using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject player;

    public float speedH = 2.5f;

    private float yaw = 0.0f;

    public float X = -90f;
    public float Y = 0.0f;
    public float playerX;
    public float playerY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.transform.eulerAngles.x - 90 - Input.GetAxis("Mouse X");
        playerY = player.transform.eulerAngles.y;
        //if (playerX >= 0)
        //X =+ player.transform.rotation.x * 114.7366f - 90;
        //if(playerX < 0)
        //X =- player.transform.rotation.x * 114.7366f - 90;
        //Y = player.transform.rotation.y * 114.7366f + 13.767f;


        yaw = speedH * Input.GetAxis("Mouse X");

        //transform.eulerAngles = new Vector3( , yaw);//(X, yaw, Y);
        Quaternion originalRot = transform.rotation;
        transform.rotation = originalRot * Quaternion.AngleAxis(yaw, Vector3.forward);


    }
}
