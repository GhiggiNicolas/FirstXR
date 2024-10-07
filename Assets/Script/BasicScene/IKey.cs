using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKey
{
    public GameObject Door { get; set; }
    public GameObject Lock { get; set; }
    public bool IsOpen { get; set; }

    public void Open();
}
