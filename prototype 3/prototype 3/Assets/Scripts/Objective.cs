using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    //all objectives
    [SerializeField] private GameObject OB1;
    [SerializeField] private GameObject OB2;
    [SerializeField] private GameObject OB3;
    [SerializeField] private GameObject OB4;

    private float OBNum1;
    private float OBNum2;
    private float OBNum3;
    private float OBNum4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OBNum1 = OB1.transform.position.x;
        OBNum2 = OB2.transform.position.x;
        OBNum3 = OB3.transform.position.x;
        OBNum4 = OB4.transform.position.x;

        //Barreer destroy when all objective are done
        if (OBNum1 == 1 && OBNum2 == 1 && OBNum3 == 1 && OBNum4 == 1)
        {
            Destroy(gameObject);
        }
    }
}
