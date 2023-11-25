using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCubicle : gAction
{
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        if (target == null)
            return false;
        return true;
    }
    public override bool PostPerform()
    {
        gWorld.Instance.GetWorld().ModifyState("TreatingPatient", 1);
        gWorld.Instance.AddCubicle(target);
        inventory.RemoveItem(target);
        gWorld.Instance.GetWorld().ModifyState("FreeCubicle", 1);
        return true;
    }
}
