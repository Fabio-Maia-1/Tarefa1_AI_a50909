using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class gAgentVisual : MonoBehaviour
{
    public gAgent thisAgent;

    // Start is called before the first frame update
    void Start()
    {
        thisAgent = this.GetComponent<gAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
