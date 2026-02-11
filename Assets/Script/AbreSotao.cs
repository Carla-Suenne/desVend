using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbreSotao : MonoBehaviour
{
    public GameObject Panel;
    public MensagemEspelho dialogo;
    [TextArea(3, 10)]
    public string[] textoSotaoTrancado;
    public Inventario inventario;
    public Animator animator;
    private bool jogadorPerto = false;
    private bool abrirSotao = false;
    private bool iniciarDialogo = true;
    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Space))
        {
            abrirSotao = inventario.temChave;
            VerificaSotao(abrirSotao);
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

    void VerificaSotao(bool deveAbrir)
    {
        if (deveAbrir)
        {
            animator.SetBool("abrir", true);
            StartCoroutine(AbrirPanelFinal());
            //Debug.log("Você finalizou o jogo");
        }

        if (!deveAbrir)
        {
            if (iniciarDialogo)
            {
                dialogo.IniciarDialogo();
                iniciarDialogo = false;
            }
            else
            {
                iniciarDialogo =true;
            }
            
        }
    }

    IEnumerator AbrirPanelFinal()
    {
        yield return new WaitForSeconds(1.0f);

        // 3. Só agora o painel aparece
        Panel.SetActive(true);
    }
    
}
