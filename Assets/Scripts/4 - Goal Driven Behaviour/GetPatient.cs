using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : gAction
{
    public override bool PrePerform()
    {
        target = gWorld.Instance.RemovePatient();
        if (target == null )
        {
            return false;
        }
        return true;
    }
    public override bool PostPerform()
    {
        return true;
    }
}
