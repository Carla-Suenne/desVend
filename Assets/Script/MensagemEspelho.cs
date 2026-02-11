using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MensagemEspelho : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] frases;

    public float velocidade = 0.05f;

    private TextMeshProUGUI textoUI;
    private int indice = 0;
    private bool digitando = false;
    private bool textoCompleto = false;

    private Canvas canvasPai;

    void Awake()
    {
        textoUI = GetComponent<TextMeshProUGUI>();
        canvasPai = GetComponentInParent<Canvas>();
        canvasPai.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!canvasPai.gameObject.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (digitando)
            {
                StopAllCoroutines();
                textoUI.text = frases[indice];
                digitando = false;
                textoCompleto = true;
            }
            else if (textoCompleto)
            {
                AvancarFrase();
            }
        }
    }

    public void IniciarDialogo()
    {
        indice = 0;
        canvasPai.gameObject.SetActive(true);
        StartCoroutine(Digitar());
    }

    IEnumerator Digitar()
    {
        digitando = true;
        textoCompleto = false;
        textoUI.text = "";

        foreach (char letra in frases[indice])
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidade);
        }

        digitando = false;
        textoCompleto = true;
    }

    void AvancarFrase()
    {
        indice++;

        if (indice < frases.Length)
        {
            StartCoroutine(Digitar());
        }
        else
        {
            FecharDialogo();
        }
    }

    void FecharDialogo()
    {
        textoUI.text = "";
        canvasPai.gameObject.SetActive(false);
    }
}
