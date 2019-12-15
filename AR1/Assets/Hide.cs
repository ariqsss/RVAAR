using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer meshrenderer;
    void Start()
    {
        meshrenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
