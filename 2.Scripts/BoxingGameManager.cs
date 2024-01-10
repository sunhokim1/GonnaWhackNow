using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxingGameManager : MonoBehaviour
{
    public GameObject playerStart;
    public BoxingEnemy boxingEnemy;
    public BoxingEnemyFaceMove boxingEnemyFaceMove;
    public WinPoseCollider winPoseCollider;
    public float playerHp;
    public float enemyHp;
    public bool isWin;
    public bool isGameOver;
    public GameObject loseUI, winUI, playUI;
    public Image playerHpImage;
    public Image enemyHpImage;
    public GameObject championBelt;

    private void Awake()
    {
        playerStart.transform.position = new Vector3(0, 1.4f, -0.05f);
    }
    void Start()
    {
        playerHp = 3;
        enemyHp = 10;
        isWin = false;
        isGameOver = false;
        playerHpImage = playerHpImage.GetComponent<Image>();
        enemyHpImage = enemyHpImage.GetComponent<Image>();
    }

    void Update()
    {
        if (playerHp <= 0 && isGameOver == false)
        {
            Lose();
        }
        if (enemyHp <= 0 && isGameOver == false)
        {
            Win();
        }
    }

    public void PlayerHpFillAmount()
    {
        playerHpImage.fillAmount = playerHp / 3;
    }

    public void EnemyHpFillAmount()
    {
        enemyHpImage.fillAmount = enemyHp / 10;
    }

    void Lose()
    {
        isGameOver = true;
        loseUI.SetActive(true);
    }

    void Win()
    {
        isGameOver = true;
        isWin = true;
        boxingEnemyFaceMove.EnemyDown();
        championBelt.SetActive(true);
        winUI.SetActive(true);
    }

    void WinPoseSound()
    {
        if (winPoseCollider.isWinPose)
        {
            //사운드 실행
        }
    }
}
