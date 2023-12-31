using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreated : gAction
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
        gWorld.Instance.GetWorld().ModifyState("Treated", 1);
        beliefs.ModifyState("isCured", 1);
        inventory.RemoveItem(target);
        return true;
    }
}
