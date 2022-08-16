using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("h"))
        {
            print("h");
            rend.sharedMaterial = material[0];
        } 
        else if (Input.GetKey("j"))
        {
            print("j");
            rend.sharedMaterial = material[1];
        }
        else if (Input.GetKey("k"))
        {
            print("k");
            rend.sharedMaterial = material[2];
        }
        else if (Input.GetKey("l"))
        {
            print("l");
            rend.sharedMaterial = material[3];
        }

    }
}

