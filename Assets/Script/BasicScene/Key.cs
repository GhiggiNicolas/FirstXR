using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Key : MonoBehaviour, IKey
{
    [SerializeField] private GameObject _door;
    [SerializeField] private GameObject _lock;

    private Vector3 _initialDoorPosition;
    private Quaternion _initialDoorRotation;

    public GameObject Door { get; set; }
    public GameObject Lock { get; set; }
    public bool IsOpen { get; set; }

    private void Start()
    {
        // Salva la posizione e rotazione iniziale della porta
        _initialDoorPosition = _door.transform.position;
        _initialDoorRotation = _door.transform.rotation;

        Door = _door;
        Lock = _lock;
        IsOpen = false;

        Door.GetComponent<XRGrabInteractable>().enabled = false;
        Lock.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(Lock))
        {
            Open();
        }
    }

    public void Open()
    {
        if (!IsOpen)
        {
            // Quando la porta si apre, abilita l'interazione
            Door.GetComponent<XRGrabInteractable>().enabled = true;
            Lock.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            // Quando la porta si chiude, disabilita l'interazione
            Door.GetComponent<XRGrabInteractable>().enabled = false;

            // Ripristina la posizione e la rotazione iniziale della porta
            Door.transform.position = _initialDoorPosition;
            Door.transform.rotation = _initialDoorRotation;

            Lock.GetComponent<Renderer>().material.color = Color.red;
        }
        IsOpen = !IsOpen;
    }
}