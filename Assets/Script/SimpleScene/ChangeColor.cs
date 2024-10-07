using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public void ColorChange()
    {
        transform.GetComponent<Renderer>().material.color = Color.red;
    }
}
