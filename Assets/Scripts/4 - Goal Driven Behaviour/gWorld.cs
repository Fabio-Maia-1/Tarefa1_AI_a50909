using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class gWorld
{
    private static readonly gWorld instance = new gWorld();
    private static WorldStates world;
    public static Queue<GameObject> patients;
    public static Queue<GameObject> cubicles;

    static gWorld()
    {
        world = new WorldStates();
        patients = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
        foreach (GameObject c in cubes)
            cubicles.Enqueue(c);

        if (cubes.Length > 0)
            world.ModifyState("FreeCubicle", cubes.Length);
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

    public void AddCubicle(GameObject p)
    {
        cubicles.Enqueue(p);
    }

    public GameObject RemoveCubicle()
    {
        if (cubicles.Count == 0)
        {
            return null;
        }
        return cubicles.Dequeue();
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