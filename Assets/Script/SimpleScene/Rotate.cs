using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool CanRotate = false;

    void Update()
    {
        if(CanRotate)
            transform.Rotate(0, 0, 1);
    }

    public void SetCanRotate()
    {
        CanRotate = true;
    }
}
