using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLR : MonoBehaviour
{
    public GameObject car;

    public float speedH1 = 2.5f;

    private float yaw1 = 0.0f;

    private float carX;
    private float carZ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //playerX = player.transform.rotation.x;
        //if (playerX >= 0)
        //X =+ player.transform.rotation.x * 114.7366f - 90;
        //if(playerX < 0)
        //X =- player.transform.rotation.x * 114.7366f - 90;
        //Y = player.transform.rotation.y * 114.7366f + 13.767f;

        carX = car.transform.eulerAngles.x;

        carZ = car.transform.eulerAngles.z;

        yaw1 += speedH1 * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(carX, yaw1, carZ);//(X, yaw, Z);
        


    }
}
