using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static float GameTimer = 600;
    public Text TimerText;

    public Transform groundCheck;
    public float groundDistance = 0.55f;
    public Text ResetText;

    private float ResetTimer;

    public float timer;

    public float timerR;

    public float TimeB;

    public Text reset;

    [SerializeField]
    private GameObject car;

    private float CarUpPos;


    // Start is called before the first frame update
    void Start()
    {
        reset.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeB >= 1f)
        {
            GameTimer -= 1f;
            TimeB = 0;
        }

        TimeB += Time.deltaTime;
        TimerText.text = "" + GameTimer;
        if (GameTimer <= 0)
        {
            SceneManager.LoadScene("Menu");
        }


        //find car up and move up by 4
        CarUpPos = car.transform.position.y + 4;

        if (Input.GetKey(KeyCode.R))
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                ResetTimer += 1;

                if (ResetTimer == 1)
                    reset.text = "5";

                if (ResetTimer == 2)
                    reset.text = "4";

                if (ResetTimer == 3)
                    reset.text = "3";

                if (ResetTimer == 4)
                    reset.text = "2";

                if (ResetTimer == 5)
                    reset.text = "1";

                if (ResetTimer == 6)
                {
                    reset.text = "";
                    car.transform.eulerAngles = new Vector3(0, 0, 0);
                    car.transform.Translate(0, 4, 0);
                }
                timer = 0;
            }

        }
        else
        {
            reset.text = "";
            ResetTimer = 0;
        }

        GroundCheck();
    }
    
    
    
    public bool IsGrounded = false;
    void GroundCheck()
    {

        if (Physics.Raycast(groundCheck.transform.position, Vector3.down, groundDistance + 0.1f))
        {
            IsGrounded = true;
            ResetText.text = "";
            timerR = 0;
        }
        else
        {
            timerR += Time.deltaTime;

            IsGrounded = false;

            if(timerR >= 6)
            {
                ResetText.text = "Hold R to flip";
            }
        }
    }
}
