using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Absztrakt oszt�ly, amely egy �ltal�nos �veget reprezent�l.
/// </summary>
public abstract class Bottle : MonoBehaviour
{
    public string Name { get; set; }
    public int Volume { get; set; }
    public int RefundValue { get; set; }

    /// <summary>
    /// Konstruktor, amely inicializ�lja az �veg nev�t, t�rfogat�t �s visszav�lt�si �rt�k�t.
    /// </summary>
    /// <param name="name">Az �veg neve.</param>
    /// <param name="volume">Az �veg t�rfogata cm3-ben.</param>
    /// <param name="refundValue">Az �veg visszav�lt�si �rt�ke.</param>
    public Bottle(string name, int volume, int refundValue)
    {
        Name = name;
        Volume = volume;
        RefundValue = refundValue;
    }
}
