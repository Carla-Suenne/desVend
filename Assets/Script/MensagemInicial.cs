using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MensagemInicial : MonoBehaviour
{
    [Header("Texto")]
    [TextArea(3, 10)]
    public string[] partesDoTexto;

    public float velocidadeDigitacao = 0.05f;

    [Header("UI")]
    public Image fadePanel;
    public string Cena;
    public TextMeshProUGUI pressSpaceText;

    private TextMeshProUGUI textoUI;
    private int indiceAtual = 0;
    private bool digitando = false;
    private bool textoCompleto = false;

    void Start()
    {
        textoUI = GetComponent<TextMeshProUGUI>();
        textoUI.text = "";
        pressSpaceText.gameObject.SetActive(false);

        StartCoroutine(FadeIn());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (digitando)
            {
                StopAllCoroutines();
                textoUI.text = partesDoTexto[indiceAtual];
                digitando = false;
                textoCompleto = true;
                pressSpaceText.gameObject.SetActive(true);
            }
            else if (textoCompleto)
            {
                AvancarTexto();
            }
        }
    }

    IEnumerator DigitarTexto()
    {
        digitando = true;
        textoCompleto = false;
        textoUI.text = "";
        pressSpaceText.gameObject.SetActive(false);

        foreach (char letra in partesDoTexto[indiceAtual])
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidadeDigitacao);
        }

        digitando = false;
        textoCompleto = true;
        pressSpaceText.gameObject.SetActive(true);
    }

    void AvancarTexto()
    {
        indiceAtual++;

        if (indiceAtual < partesDoTexto.Length)
        {
            StartCoroutine(DigitarTexto());
        }
        else
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        float alpha = 1f;
        fadePanel.color = new Color(0, 0, 0, alpha);

        while (alpha > 0f)
        {
            alpha -= Time.deltaTime;
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        StartCoroutine(DigitarTexto());
    }

    IEnumerator FadeOut()
    {
        float alpha = 0f;
        fadePanel.color = new Color(0, 0, 0, alpha);

        while (alpha < 1f)
        {
            alpha += Time.deltaTime;
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(Cena);
    }
}
