using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWaitingRoom : gAction
{
    public override bool PrePerform()
    {
        return true;
    }
    public override bool PostPerform()
    {
        gWorld.Instance.GetWorld().ModifyState("Waiting", 1);
        gWorld.Instance.AddPatient(this.gameObject);
        beliefs.ModifyState("atHospital", 1);
        return true;
    }
}
