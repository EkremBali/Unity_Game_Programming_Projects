using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direksiyonDondurme : MonoBehaviour
{
    public float maxAci;
    public float minAci;
    private float aci;

    void Update()
    {
        if (Input.GetKey(KeyCode.D)) 
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 35);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 35);
        }
        

    }
}
