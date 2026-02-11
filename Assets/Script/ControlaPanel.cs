using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaPanel : MonoBehaviour
{
    
    public GameObject Panel;

    public void AbrirInstrucoes()
    {
        Panel.SetActive(true);
    }

    public void FecharInstrucoes()
    {
        Panel.SetActive(false);
    }
}

 
