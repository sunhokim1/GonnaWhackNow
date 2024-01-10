using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBoxing : MonoBehaviour
{
    public void RestartB()
    {
        SceneManager.LoadScene(3);
    }  
}
