using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novoComodaInteracao : MonoBehaviour
{
    // Start is called before the first frame update
    
    public MensagemEspelho   dialogo;
    public Inventario inventario;
    public Animator animator;
    private bool jogadorPerto = false;
    private bool dialogoAtivo = false;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Space) && !dialogoAtivo)
        {
            AbrirComoda();
            
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

    void AbrirComoda()
    {
        dialogoAtivo = true;
        animator.SetBool("abrir", true);

        Invoke(nameof(MostrarTexto), 0.6f); // tempo da animação
    }

    void MostrarTexto()
    {
        dialogo.IniciarDialogo();
        inventario.AdicionarChave();
    }
}
