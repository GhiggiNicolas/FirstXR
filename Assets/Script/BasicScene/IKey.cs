using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interfaccia per la chiave
public interface IKey
{
    #region Propriet�

    GameObject Door { get; set; } // Propriet� per accedere alla porta associata alla chiave
    GameObject Lock { get; set; } // Propriet� per accedere alla serratura associata alla chiave
    bool IsOpen { get; set; } // Propriet� per determinare se la chiave ha aperto la porta

    #endregion

    #region Metodi

    void Open(); // Metodo per aprire o chiudere la porta

    #endregion
}
