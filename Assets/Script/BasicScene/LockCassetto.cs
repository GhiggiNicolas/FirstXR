using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class LockCassetto : MonoBehaviour
{
    [SerializeField] private GameObject Indicator;

    private bool IsLocked;

    void Start()
    {
        IsLocked = true;
        GetComponent<XRGrabInteractable>().enabled = false;
        Indicator.GetComponent<Renderer>().material.color = Color.red;
    }

    public void LockToggle()
    {
        GetComponent<XRGrabInteractable>().enabled = IsLocked;
        Indicator.GetComponent<Renderer>().material.color = IsLocked ? Color.green : Color.red;
        IsLocked = !IsLocked;
    }
}
