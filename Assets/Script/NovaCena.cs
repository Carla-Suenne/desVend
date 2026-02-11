using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NovaCena : MonoBehaviour
{
    
    public void ChamarFirstScene()
    {
        SceneManager.LoadScene("FirstScene");
    }
    
    public void ChamarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
