using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class gWorld
{
    private static readonly gWorld instance = new gWorld();
    private static WorldStates world;
    public static Queue<GameObject> patients;

    static gWorld()
    {
        world = new WorldStates();
        patients = new Queue<GameObject>();
    }

    private gWorld()
    {
    }

    public void AddPatient(GameObject p)
    {
        patients.Enqueue(p);
    }

    public GameObject RemovePatient()
    {
        if (patients.Count == 0)
        {
            return null;
        }
        return patients.Dequeue();
    }

    public static gWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}