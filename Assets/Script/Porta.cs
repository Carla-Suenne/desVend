using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip somPorta; 
    
    public bool corredor;
    public Animator animator;
    public Transform destino;
    private bool jogadorPerto;

    FadeController fade;

    void Start()
    {
        fade = FindObjectOfType<FadeController>();
    }

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Transicao());
            
            if (audioSource != null && somPorta != null)
            {
                audioSource.PlayOneShot(somPorta);
            }

            if (corredor)
            {
                animator.SetBool("abrir", true);
                Invoke("ParaTransicao", 0.6f);
            }
            
        }
    }
    void ParaTransicao()
    {
        animator.SetBool("abrir", false);
    }

    IEnumerator Transicao()
    {
        yield return fade.FadeOut();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = destino.position;

        yield return fade.FadeIn();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jogadorPerto = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jogadorPerto = false;
    }
}
