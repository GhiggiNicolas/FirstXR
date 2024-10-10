using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject CurrentScoreText, FirstScoreText, SecondScoreText, ThirdScoreText;

    public int Score { get; set; }

    #region Unity Methods
    private void Start()
    {
        Score = 0;
        DisplayBestScores();  // Mostra i migliori punteggi quando la scena viene avviata
    }
    #endregion

    #region Score Management

    public void IncreaseScore(GameObject coin)
    {
        Score++;
        SetCurrentScore();
        Destroy(coin);
    }

    public void UpdateHighScores()
    {
        // Recupera i punteggi salvati
        int firstScore = PlayerPrefs.GetInt("FirstScore", 0);
        int secondScore = PlayerPrefs.GetInt("SecondScore", 0);
        int thirdScore = PlayerPrefs.GetInt("ThirdScore", 0);

        // Aggiorna la classifica in base al punteggio attuale
        if (Score > firstScore)
        {
            UpdateScores(secondScore, firstScore, Score);
        }
        else if (Score > secondScore)
        {
            UpdateScores(secondScore, Score);
        }
        else if (Score > thirdScore)
        {
            PlayerPrefs.SetInt("ThirdScore", Score);  // Il nuovo punteggio diventa terzo
        }

        PlayerPrefs.Save(); // Salva i punteggi aggiornati
    }

    // Metodo che aggiorna più punteggi usando params per maggiore flessibilità
    private void UpdateScores(params int[] scores)
    {
        switch (scores.Length)
        {
            case 3:
                PlayerPrefs.SetInt("ThirdScore", scores[0]);
                PlayerPrefs.SetInt("SecondScore", scores[1]);
                PlayerPrefs.SetInt("FirstScore", scores[2]);
                break;
            case 2:
                PlayerPrefs.SetInt("ThirdScore", scores[0]);
                PlayerPrefs.SetInt("SecondScore", scores[1]);
                break;
        }
    }

    #endregion

    #region UI Updates

    // Metodo per visualizzare i punteggi migliori all'avvio
    private void DisplayBestScores()
    {
        SetFirstScore();
        SetSecondScore();
        SetThirdScore();
    }

    private void SetCurrentScore() => CurrentScoreText.GetComponent<TextMeshProUGUI>().text = "Current Score: " + Score;

    private void SetFirstScore() => FirstScoreText.GetComponent<TextMeshProUGUI>().text = "First Score: " + PlayerPrefs.GetInt("FirstScore", 0);

    private void SetSecondScore() => SecondScoreText.GetComponent<TextMeshProUGUI>().text = "Second Score: " + PlayerPrefs.GetInt("SecondScore", 0);

    private void SetThirdScore() => ThirdScoreText.GetComponent<TextMeshProUGUI>().text = "Third Score: " + PlayerPrefs.GetInt("ThirdScore", 0);

    #endregion

    #region Game Management

    public void QuitGame()
    {
        // Aggiorna la classifica prima di chiudere l'applicazione
        UpdateHighScores();
        DisplayBestScores();  // Mostra i punteggi aggiornati

        // Chiude l'applicazione o ferma l'editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    #endregion
}
