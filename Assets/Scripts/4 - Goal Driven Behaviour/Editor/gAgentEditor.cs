using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(gAgentVisual))]
[CanEditMultipleObjects]
public class gAgentVisualEditor : Editor 
{


    void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();
        gAgentVisual agent = (gAgentVisual) target;
        GUILayout.Label("Name: " + agent.name);
        GUILayout.Label("Current Action: " + agent.gameObject.GetComponent<gAgent>().currentAction);
        GUILayout.Label("Actions: ");
        foreach (gAction a in agent.gameObject.GetComponent<gAgent>().actions)
        {
            string pre = "";
            string eff = "";

            foreach (KeyValuePair<string, int> p in a.preconditions)
                pre += p.Key + ", ";
            foreach (KeyValuePair<string, int> e in a.effects)
                eff += e.Key + ", ";

            GUILayout.Label("====  " + a.actionName + "(" + pre + ")(" + eff + ")");
        }
        GUILayout.Label("Goals: ");
        foreach (KeyValuePair<SubGoal, int> g in agent.gameObject.GetComponent<gAgent>().goals)
        {
            GUILayout.Label("---: ");
            foreach (KeyValuePair<string, int> sg in g.Key.sgoals)
                GUILayout.Label("=====  " + sg.Key);
        }
        serializedObject.ApplyModifiedProperties();
    }
}