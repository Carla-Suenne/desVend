using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoutButton : MonoBehaviour
{
    public void Sair()
    {
        Application.Quit();

        // Só para testar no Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
