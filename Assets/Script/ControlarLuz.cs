using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ControlarLuz : MonoBehaviour
{
    [Header("Tempo")]
    public float tempoMaximo = 240f;
    private float tempoAtual;

    [Header("Luz")]
    public Light2D luzGlobal;

    [Header("Intensidades")]

    public AudioSource audioSource;
    public AudioClip somGritos; 
    
    public GameObject Panel;
    public float intensidadeNormal = 1.0f;
    public float intensidadeMedia = 0.6f;
    public float intensidadeCritica = 0.3f;

    private bool jogoFinalizado = false;

    void Start()
    {
        tempoAtual = tempoMaximo;
        luzGlobal.intensity = intensidadeNormal;
    }

    void Update()
    {
        if (jogoFinalizado) return;

        tempoAtual -= Time.deltaTime;

        float porcentagem = tempoAtual / tempoMaximo;

        if (porcentagem > 0.5f)
        {
            luzGlobal.intensity = intensidadeNormal;
        }
        else if (porcentagem > 0.3f)
        {
            luzGlobal.intensity = intensidadeMedia;
        }
        else if (porcentagem > 0f)
        {
            luzGlobal.intensity = intensidadeCritica;
        }
        else
        {
            FinalizarDerrota();
        }
    }

    void FinalizarDerrota()
    {
        if (audioSource != null && somGritos != null)
        {
            audioSource.PlayOneShot(somGritos);
        }
        jogoFinalizado = true;
        luzGlobal.intensity = 0f;
        StartCoroutine(AbrirPanelDerrota());
        Debug.Log("Derrota: a luz se apagou completamente.");
    }

    IEnumerator AbrirPanelDerrota()
    {
        yield return new WaitForSeconds(0.5f);
        Panel.SetActive(true);
    }
}

