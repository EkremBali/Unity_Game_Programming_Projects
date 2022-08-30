using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yanBandCanta : MonoBehaviour
{
    bool go;
    
    void Start()
    {
        go = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 6f);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("tezgah"))
        {
            go = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            
            for(int i = 0; i<transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

   
}
