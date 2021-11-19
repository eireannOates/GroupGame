using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OB2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        gameObject.transform.position = new Vector3(1, -1000, -10000);
    }
}
