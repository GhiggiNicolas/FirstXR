using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioManager : MonoBehaviour
{
    #region Variabili

    [SerializeField] private GameObject RadioSound; // Riferimento all'oggetto AudioSource per il suono della radio
    public bool IsPlaying { get; set; } // Proprietà per determinare se la radio è in riproduzione

    #endregion

    #region Metodi

    // Metodo di inizializzazione chiamato all'avvio del gioco
    private void Start()
    {
        IsPlaying = false; // Imposta lo stato di riproduzione iniziale a false
        GetComponent<Renderer>().material.color = Color.red; // Imposta il colore iniziale della radio a rosso
    }

    // Metodo per attivare/disattivare la riproduzione della radio
    public void TogglePlay()
    {
        IsPlaying = !IsPlaying; // Cambia lo stato di riproduzione

        if (IsPlaying)
        {
            RadioSound.GetComponent<AudioSource>().Play(); // Avvia la riproduzione del suono
            GetComponent<Renderer>().material.color = Color.green; // Cambia il colore della radio a verde
        }
        else
        {
            RadioSound.GetComponent<AudioSource>().Stop(); // Ferma la riproduzione del suono
            GetComponent<Renderer>().material.color = Color.red; // Cambia il colore della radio a rosso
        }
    }

    #endregion
}
