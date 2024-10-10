using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintBrush : MonoBehaviour
{
    #region Variabili

    [SerializeField] private Vector3 defaultScale = new Vector3(1, 1, 1); // Scala predefinita dell'oggetto
    public GameObject slider; // Riferimento allo slider per il ridimensionamento

    #endregion

    #region Metodi

    // Metodo collegato allo slider per ridimensionare l'oggetto
    // Param: None
    public void Resize()
    {
        // Ridimensiona l'oggetto in base al valore dello slider (con il valore minimo applicato)
        transform.localScale = defaultScale * slider.GetComponent<Slider>().value;
    }

    // Metodo di inizializzazione chiamato all'avvio del gioco
    private void Start()
    {
        // Imposta la scala iniziale dell'oggetto in base al valore dello slider
        transform.localScale = defaultScale * slider.GetComponent<Slider>().value;
    }

    #endregion
}
