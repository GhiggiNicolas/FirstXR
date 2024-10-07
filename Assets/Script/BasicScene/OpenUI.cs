using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    [SerializeField] private GameObject UI;

    private bool IsOpen;

    private void Start()
    {
        IsOpen = false;
        UI.SetActive(false);
    }

    public void ActiveToggle()
    {
        IsOpen = !IsOpen;
        UI.SetActive(!IsOpen);
    }
}
