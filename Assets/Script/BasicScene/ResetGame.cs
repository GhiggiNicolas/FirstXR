using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    #region Variabili

    [SerializeField] private GameObject GameManager; // Riferimento al GameManager per aggiornare i punteggi

    #endregion

    #region Metodi

    // Metodo per ripristinare la scena corrente
    // Param: None
    public void ResetScene()
    {
        // Aggiorna i punteggi più alti tramite il GameManager
        GameManager.GetComponent<GameManager>().UpdateHighScores();

        // Ricarica la scena attiva
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Metodo chiamato quando un oggetto entra nel trigger
    // Param: Collider other - il collider dell'oggetto che entra nel trigger
    private void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto che ha attivato il trigger ha il tag "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            // Ripristina la scena se il giocatore entra nel trigger
            ResetScene();
        }
    }

    #endregion
}
