using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Riferimenti agli oggetti UI per visualizzare i punteggi
    [SerializeField] private GameObject FirstScoreText, SecondScoreText, ThirdScoreText;

    // Metodo di inizializzazione chiamato all'avvio del gioco
    void Start()
    {
        // Imposta i punteggi all'avvio
        SetFirstScore();
        SetSecondScore();
        SetThirdScore();
    }

    #region Metodi del Gioco

    // Metodo per avviare il gioco caricando una nuova scena
    public void StartGame()
    {
        SceneManager.LoadScene("BasicScene");
    }

    // Metodo per chiudere il gioco
    public void QuitGame()
    {
        // Chiude l'applicazione o ferma l'editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Ferma il gioco nell'editor
        #else
            Application.Quit(); // Chiude l'applicazione
        #endif
    }

    #endregion

    #region Impostazione Punteggi

    // Metodo per impostare il primo punteggio
    private void SetFirstScore()
    {
        FirstScoreText.GetComponent<TextMeshProUGUI>().text = "First Score: " + PlayerPrefs.GetInt("FirstScore", 0);
    }

    // Metodo per impostare il secondo punteggio
    private void SetSecondScore()
    {
        SecondScoreText.GetComponent<TextMeshProUGUI>().text = "Second Score: " + PlayerPrefs.GetInt("SecondScore", 0);
    }

    // Metodo per impostare il terzo punteggio
    private void SetThirdScore()
    {
        ThirdScoreText.GetComponent<TextMeshProUGUI>().text = "Third Score: " + PlayerPrefs.GetInt("ThirdScore", 0);
    }

    #endregion
}
