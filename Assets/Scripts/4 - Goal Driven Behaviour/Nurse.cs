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

        base.Start();
        SubGoal s2 = new SubGoal("rested", 1, false);
        goals.Add(s2, 1);

        Invoke("GetTired", Random.Range(15, 30));
    }

    // Update is called once per frame
    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(15, 30));
    }
}