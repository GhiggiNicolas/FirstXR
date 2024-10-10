using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables; // Namespace per XR Interaction Toolkit

public class LockCassetto : MonoBehaviour
{
    #region Variabili

    [SerializeField] private GameObject Indicator; // Riferimento all'oggetto indicatore per mostrare lo stato di blocco
    private bool IsLocked; // Stato del cassetto (bloccato o sbloccato)
    private Vector3 _initialPos; // Posizione iniziale del cassetto

    #endregion

    #region Metodi

    // Metodo di inizializzazione chiamato all'avvio del gioco
    void Start()
    {
        _initialPos = transform.position; // Salva la posizione iniziale del cassetto
        IsLocked = true; // Imposta lo stato iniziale del cassetto come bloccato
        GetComponent<XRGrabInteractable>().enabled = false; // Disabilita l'interazione iniziale
        Indicator.GetComponent<Renderer>().material.color = Color.red; // Imposta il colore dell'indicatore a rosso
    }

    // Metodo per attivare/disattivare il blocco del cassetto
    public void LockToggle()
    {
        // Abilita/disabilita l'interazione con il cassetto in base allo stato di blocco
        GetComponent<XRGrabInteractable>().enabled = IsLocked;

        // Cambia il colore dell'indicatore in base allo stato di blocco
        Indicator.GetComponent<Renderer>().material.color = IsLocked ? Color.green : Color.red;

        IsLocked = !IsLocked; // Inverte lo stato di blocco
        transform.position = _initialPos; // Ripristina la posizione iniziale del cassetto
    }

    #endregion
}
