using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBedroom1 : MonoBehaviour
{
    public GameObject popup;

    void Start()
    {
        popup.SetActive(false);
    }

    public void Abrir()
    {
        popup.SetActive(true);
    }

    public void Fechar()
    {
        popup.SetActive(false);
    }
}
