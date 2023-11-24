using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class gWorld
{
    private static readonly gWorld instance = new gWorld();
    private static WorldStates world;

    static gWorld()
    {
        world = new WorldStates();
    }

    private gWorld()
    {
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