using UnityEngine;

public class ComodaInteracao : MonoBehaviour
{
    public Animator animator;
    public MensagemEspelho   dialogo;

    public Inventario inventario;

    private bool jogadorPerto = false;
    private bool jaAberta = false;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Space) && !jaAberta)
        {
            AbrirComoda();
        }
    }

    void AbrirComoda()
    {
        jaAberta = true;
        animator.SetBool("abrir", true);

        Invoke(nameof(MostrarTexto), 0.6f); // tempo da animação
    }

    void MostrarTexto()
    {
        dialogo.IniciarDialogo();
        inventario.AdicionarChave();
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
}
