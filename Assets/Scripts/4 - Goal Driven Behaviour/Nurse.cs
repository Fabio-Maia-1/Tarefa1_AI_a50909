using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : gAgent
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("treatPatient", 1, false);
        goals.Add(s1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
