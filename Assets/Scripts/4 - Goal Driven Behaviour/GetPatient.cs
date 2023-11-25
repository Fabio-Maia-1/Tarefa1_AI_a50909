using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : gAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = gWorld.Instance.RemovePatient();
        if (target == null )
        {
            return false;
        }
        resource = gWorld.Instance.RemoveCubicle();
        if (resource != null)
        {
            inventory.AddItem( resource );
        }
        else
        {
            gWorld.Instance.AddPatient(target);
            target = null;
            return false;
        }
        gWorld.Instance.GetWorld().ModifyState("FreeCubicle", -1);
        return true;
    }
    public override bool PostPerform()
    {
        gWorld.Instance.GetWorld().ModifyState("Waiting", -1);
        if (target)
        {
            target.GetComponent<gAgent>().inventory.AddItem(resource);
        }
        return true;
    }
}
