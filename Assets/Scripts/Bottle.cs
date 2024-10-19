using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Absztrakt osztály, amely egy általános üveget reprezentál.
/// </summary>
public abstract class Bottle : MonoBehaviour
{
    public string Name { get; set; }
    public int Volume { get; set; }
    public int RefundValue { get; set; }

    /// <summary>
    /// Konstruktor, amely inicializálja az üveg nevét, térfogatát és visszaváltási értékét.
    /// </summary>
    /// <param name="name">Az üveg neve.</param>
    /// <param name="volume">Az üveg térfogata cm3-ben.</param>
    /// <param name="refundValue">Az üveg visszaváltási értéke.</param>
    public Bottle(string name, int volume, int refundValue)
    {
        Name = name;
        Volume = volume;
        RefundValue = refundValue;
    }
}
