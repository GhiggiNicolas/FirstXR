using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interfaccia per la chiave
public interface IKey
{
    #region ProprietÓ

    GameObject Door { get; set; } // ProprietÓ per accedere alla porta associata alla chiave
    GameObject Lock { get; set; } // ProprietÓ per accedere alla serratura associata alla chiave
    bool IsOpen { get; set; } // ProprietÓ per determinare se la chiave ha aperto la porta

    #endregion

    #region Metodi

    void Open(); // Metodo per aprire o chiudere la porta

    #endregion
}
