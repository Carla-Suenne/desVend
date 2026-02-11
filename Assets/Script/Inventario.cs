using UnityEngine;
using System.Collections;

public class Inventario : MonoBehaviour
{
    public static Inventario instancia;
    public bool temChave = false;
    public GameObject iconeChaveUI;

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);

        iconeChaveUI.SetActive(false);
    }

    public void AdicionarChave()
    {
        temChave = true;
        iconeChaveUI.SetActive(true);
    }

    public bool TemChave()
    {
        return temChave;
    }

    
}
