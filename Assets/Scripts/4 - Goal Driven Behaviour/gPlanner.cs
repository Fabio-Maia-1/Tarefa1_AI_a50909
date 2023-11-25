using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using UnityEditor.Search;

public class Nodes
{
    public Nodes parent;
    public float cost;
    public Dictionary<string, int> state;
    public gAction action;

    public Nodes(Nodes parent, float cost, Dictionary<string, int> allstates, gAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = new Dictionary<string, int>(allstates);
        this.action = action;
    }

    public Nodes(Nodes parent, float cost, Dictionary<string, int> allstates, Dictionary<string, int> beliefstates, gAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = new Dictionary<string, int>(allstates);
        foreach(KeyValuePair<string, int> b in beliefstates)
            if (!this.state.ContainsKey(b.Key))
                this.state.Add(b.Key, b.Value);

        this.action = action;
    }
}

public class gPlanner
{
    public Queue<gAction> plan(List<gAction> actions, Dictionary<string, int> goal, WorldStates beliefstates)
    {
        List<gAction> usableActions = new List<gAction>();
        foreach (gAction a in actions)
        {
            if (a.IsAchievable())
            {
                usableActions.Add(a);
            }
        }

        List<Nodes> leaves = new List<Nodes>();
        Nodes start = new Nodes(null, 0, gWorld.Instance.GetWorld().GetStates(), beliefstates.GetStates(), null);

        bool success = BuildGraph(start, leaves, usableActions, goal);

        if (!success)
        {
            Debug.Log("NO PLAN");
            return null;
        }

        Nodes cheapest = null;
        foreach (Nodes leaf in leaves)
        {
            if (cheapest == null)
            {
                cheapest = leaf;
            }
            else
            {
                if (leaf.cost < cheapest.cost)
                    cheapest = leaf;
            }
        }

        List<gAction> result = new List<gAction>();
        Nodes n = cheapest;
        while (n != null)
        {
            if (n.action != null)
            {
                result.Insert(0, n.action);
            }
            n = n.parent;
        }

        Queue<gAction> queue = new Queue<gAction>();
        foreach (gAction a in result)
        {
            queue.Enqueue(a);
        }

        Debug.Log("The Plan Is: ");
        foreach (gAction a in queue)
        {
            Debug.Log("Q: " + a.actionName);
        }

        return queue;
    }

    private bool BuildGraph(Nodes parent, List<Nodes> leaves, List<gAction> usableActions, Dictionary<string, int> goal)
    {
        bool foundPath = false;
        foreach(gAction action in usableActions)
        {
            if (action.IsAchievableGiven(parent.state))
            {
                Dictionary<string, int> currentState = new Dictionary<string, int>(parent.state);
                foreach (KeyValuePair<string, int> eff in action.effects)
                {
                    if (!currentState.ContainsKey(eff.Key))
                        currentState.Add(eff.Key, eff.Value);
                }

                Nodes nodes = new Nodes(parent, parent.cost + action.cost, currentState, action);

                if (GoalAchieved(goal, currentState))
                {
                    leaves.Add(nodes);
                    foundPath = true;
                }
                else
                {
                    List<gAction> subset = ActionSubset(usableActions, action);
                    bool found = BuildGraph(nodes, leaves, subset, goal);
                    if (found)
                    {
                        foundPath = true;
                    }
                }
            }
        }
        return foundPath;
    }

    private bool GoalAchieved(Dictionary<string, int> goal, Dictionary<string, int> state)
    {
        foreach (KeyValuePair<string, int> g in goal)
        {
            if (!state.ContainsKey(g.Key))
                return false;
        }
        return true;
    }

    private List<gAction> ActionSubset(List<gAction> actions, gAction removeMe)
    {
        List<gAction> subset = new List<gAction>();
        foreach (gAction a in actions)
        {
            if (!a.Equals(removeMe))
                subset.Add(a);
        }
        return subset;
    }
}
