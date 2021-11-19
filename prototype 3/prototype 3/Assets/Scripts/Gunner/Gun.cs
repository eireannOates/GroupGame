using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private AudioSource Bang;

    //the amounts of numbers
    public Text BText;
    public static float bullets = 85;

    //cooldown for gun
    public float coolDown = 0.5f;
    float initCoolDown;

    //spawn bullets
    public GameObject BulletEmitter;
    //The bullets
    public GameObject Bullet;
    //foward force of bullet
    public float Bullet_Forward_Force;
    
    // Start is called before the first frame update
    void Start()
    {
        initCoolDown = coolDown;
        Bang = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        BText.text = "" + bullets;
        
        if (bullets >= 500)
        {
            bullets = 500;
        }

        if (coolDown >0)
        {
            coolDown -= Time.deltaTime;
        }

        if (Input.GetMouseButton(1)&& coolDown <=0)
        {
            if (bullets <= 0)
            {
                
            }
            else
            {
                coolDown = initCoolDown;
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;


                Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                Rigidbody Temporary_Rigidbody;
                Temporary_Rigidbody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();


                Temporary_Rigidbody.AddForce(BulletEmitter.transform.forward * Bullet_Forward_Force);

                Destroy(Temporary_Bullet_Handler, 5.0f);
                bullets -= 1;
                Bang.Play();
            }

            

        }









    }
    //collision car is name of collisosn that needs to be rafnced by others
    void OnCollisionEnter(Collision Car)
    {

    }
}
