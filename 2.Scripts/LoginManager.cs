using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public GameObject LoginPanel;

    private void Awake()
    {
        LoginPanel.SetActive(true);
    } 

    public void Button_Start()
    {
        SceneManager.LoadScene(1);
    }
}