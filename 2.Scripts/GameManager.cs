using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int count;
    int ranNum;
    public Testblock[] testBlocks;
    public GameObject playerStart;
    public FaceMove[] facemove;
    public float time;
    public Image timerImage;
    public float fillAmount;
    public float playerHP;
    public bool isGameOver;
    public bool isover;
    public GameObject zombieLeftHand;
    public GameObject zombieRightHand;
    public GameObject playerHitCanvus;
    public Image playerHitImage;
    public SoundManager soundManager;
    public AudioSource audioSource;
    public GameObject gameOverUI;

    private void Awake()
    {
        playerStart.transform.position = new Vector3(0, 1.4f, -0.1f);
    }
    void Start()
    {
        isGameOver = false;
        count = 0;
        time = 30;
        playerHP = 3;
        timerImage = timerImage.GetComponent<Image>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        playerHitImage = playerHitCanvus.GetComponentInChildren<Image>();
    }

    void Update()
    {
        if (isGameOver == false && (fillAmount <= 0 || playerHP <= 0))
            GameOver();
        if (isover == false && count == 0)
            Regenerate();
        if (fillAmount > 0 && playerHP > 0)
        {
            fillAmount = fillAmount - (Time.deltaTime / (time - 1));
            timerImage.fillAmount = fillAmount;
        }
    }

    void Regenerate()
    {
        count++;
        Invoke("ActivePoint", 1);
    }

    void ActivePoint()
    {
        ranNum = Random.Range(0, 8);
        testBlocks[ranNum].isHit = false;
        testBlocks[ranNum].point.SetActive(true);
        facemove[ranNum].collier.enabled = true;
        facemove[ranNum].dontHit = false;
        audioSource = facemove[ranNum].GetComponent<AudioSource>();
        audioSource.clip = soundManager.bgmSounds[2].clip;
        audioSource.Play();
    }

    void GameOver()
    {
        isover = true;
        isGameOver = true;
        if (fillAmount <= 0)
        {
            TimeOver();
        }
        else if (playerHP <= 0)
        {
            ImZombie();
        }
    }

    void TimeOver()
    {
        gameOverUI.SetActive(true);
        //타임오버UI
    }

    void ImZombie()
    {
        gameOverUI.SetActive(true);
        zombieLeftHand.SetActive(true);
        zombieRightHand.SetActive(true);
        //게임오버UI
    }
}
