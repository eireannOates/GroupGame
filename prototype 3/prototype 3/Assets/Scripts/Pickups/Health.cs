using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float RLR = -173.259f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RLR += 40f * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, RLR, 0);
    }
}
