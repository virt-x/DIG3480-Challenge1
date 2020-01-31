using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Pickup"))
        {
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -160) * Time.deltaTime);
        }
    }
}
