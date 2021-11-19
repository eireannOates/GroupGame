using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybox : MonoBehaviour
{
    [SerializeField]
    private GameObject car;

    public float carlocx;
    private float carlocz;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carlocx = car.transform.position.x;
        carlocz = car.transform.position.z;

        transform.position = new Vector3(carlocx,-20f,carlocz);
    }
}
