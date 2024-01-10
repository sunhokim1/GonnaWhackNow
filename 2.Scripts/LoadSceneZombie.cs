using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class LoadSceneZombie : MonoBehaviour
{
    public void NextScene()
    {
            SceneManager.LoadScene(2);
    }
}
