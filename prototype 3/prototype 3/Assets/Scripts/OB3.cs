using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OB3 : MonoBehaviour
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
        gameObject.transform.position = new Vector3(1, -10000, -1000);
    }
}
