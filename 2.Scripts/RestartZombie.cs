using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartZombie : MonoBehaviour
{
    public void RestartZ()
    {
        SceneManager.LoadScene(2);
    }
}
