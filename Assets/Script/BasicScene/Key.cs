using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Key : MonoBehaviour, IKey
{
    #region Variabili

    [SerializeField] private GameObject _door; // Riferimento all'oggetto porta
    [SerializeField] private GameObject _lock; // Riferimento all'oggetto serratura

    private Vector3 _initialDoorPosition; // Posizione iniziale della porta
    private Quaternion _initialDoorRotation; // Rotazione iniziale della porta

    public GameObject Door { get; set; } // Proprietà per accedere alla porta
    public GameObject Lock { get; set; } // Proprietà per accedere alla serratura
    public bool IsOpen { get; set; } // Proprietà per determinare se la porta è aperta

    #endregion

    #region Metodi

    // Metodo di inizializzazione chiamato all'avvio del gioco
    private void Start()
    {
        // Salva la posizione e rotazione iniziale della porta
        _initialDoorPosition = _door.transform.position;
        _initialDoorRotation = _door.transform.rotation;

        Door = _door; // Assegna la porta alla proprietà
        Lock = _lock; // Assegna la serratura alla proprietà
        IsOpen = false; // Imposta lo stato iniziale della porta come chiuso

        // Disabilita l'interazione con la porta all'inizio
        Door.GetComponent<XRGrabInteractable>().enabled = false;
        Lock.GetComponent<Renderer>().material.color = Color.red; // Imposta il colore della serratura a rosso
    }

    // Metodo chiamato quando la chiave collide con un oggetto
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(Lock)) // Controlla se collida con la serratura
        {
            Open(); // Chiama il metodo Open
        }
    }

    // Metodo per aprire o chiudere la porta
    public void Open()
    {
        if (!IsOpen) // Se la porta è chiusa
        {
            // Abilita l'interazione con la porta
            Door.GetComponent<XRGrabInteractable>().enabled = true;
            Lock.GetComponent<Renderer>().material.color = Color.green; // Cambia il colore della serratura a verde
        }
        else // Se la porta è aperta
        {
            // Disabilita l'interazione con la porta
            Door.GetComponent<XRGrabInteractable>().enabled = false;

            // Ripristina la posizione e la rotazione iniziale della porta
            Door.transform.position = _initialDoorPosition;
            Door.transform.rotation = _initialDoorRotation;

            Lock.GetComponent<Renderer>().material.color = Color.red; // Cambia il colore della serratura a rosso
        }
        IsOpen = !IsOpen; // Inverte lo stato di apertura della porta
    }

    #endregion
}
