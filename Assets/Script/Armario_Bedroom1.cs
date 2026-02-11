using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armario_Bedroom1 : MonoBehaviour
{
    private bool jogadorPerto = false;
    public PopUpBedroom1 popupUI;
    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Space))
        {
            popupUI.Abrir();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}
