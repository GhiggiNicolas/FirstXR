using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    #region Variabili

    [SerializeField] private GameObject UI; // Riferimento all'oggetto UI da attivare/disattivare
    private bool IsOpen; // Stato dell'UI (aperta o chiusa)

    #endregion

    #region Metodi

    // Metodo di inizializzazione chiamato all'avvio del gioco
    private void Start()
    {
        IsOpen = false; // Imposta lo stato iniziale dell'UI a chiuso
        UI.SetActive(false); // Disattiva l'UI all'avvio
    }

    // Metodo per attivare/disattivare l'UI
    public void ActiveToggle()
    {
        IsOpen = !IsOpen; // Cambia lo stato dell'UI
        UI.SetActive(IsOpen); // Attiva o disattiva l'UI in base allo stato
    }

    #endregion
}
