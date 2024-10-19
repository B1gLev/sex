using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sörösüveg osztály, amely a Bottle osztályból származik.
/// </summary>
public class BeerBottle : Bottle
{
    /// <summary>
    /// Konstruktor, amely létrehoz egy sörösüveget a megadott névvel és visszaváltási értékkel.
    /// A sörösüveg térfogata 500 cm³.
    /// </summary>
    public BeerBottle() : base("Sör", 500, 30)
    {
    }

    /// <summary>
    /// Példa a BeerBottle osztály használatára:
    /// 
    /// BeerBottle myBeerBottle = new BeerBottle("Kézműves Csiki Sör", 30);
    /// Console.WriteLine($"Név: {myBeerBottle.Name}");
    /// Console.WriteLine($"Térfogat: {myBeerBottle.Volume} cm³");
    /// Console.WriteLine($"Visszaváltási érték: {myBeerBottle.RefundValue} Ft");
    /// </summary>
}
