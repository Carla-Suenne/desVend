using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvInteracao : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject animacao;
    private bool jogadorPerto = false;
    private bool telaAtiva = false;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Space) && !telaAtiva)
        {
            MostrarTv();
            
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
            jogadorPerto = false;
    }

    void MostrarTv()
    {
        telaAtiva = true;
        animacao.SetActive(true);
        Invoke("DesativarTela",14.0f);

    }

    void DesativarTela()
    {
        animacao.SetActive(false);
        telaAtiva = false;
    }

}
