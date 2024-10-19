using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Ez az osztály is a Bottle osztályból származik.
/// </summary>
public class PlasticBottle : Bottle
{
    /// <summary>
    /// Konstruktor, amely létrehoz egy műanyag üveget a megadott névvel, térfogattal és visszaváltási értékkel.
    /// </summary>
    public PlasticBottle() : base("Víz", 2000, 30)
    {
    }
}
