using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspelhoInteracao : MonoBehaviour
{
    public MensagemEspelho   dialogo;
    private bool jogadorPerto = false;
    private bool dialogoAtivo = false;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Space) && !dialogoAtivo)
        {
            dialogo.IniciarDialogo();
            dialogoAtivo = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jogadorPerto = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            dialogoAtivo = false;
        }
    }
}
