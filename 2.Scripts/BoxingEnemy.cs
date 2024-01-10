using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoxingEnemy : MonoBehaviour
{
    public bool ready;
    public bool counter;
    public int ranAttack;
    public bool isHit;
    public AttackWarning attackWarning;
    public EnemyLeftAttackCollider enemyLeftAttackCollider;
    public EnemyRightAttackCollider enemyRightAttackCollider;
    public EnemyUppercutCollider enemyUppercutCollider;
    public BoxingGameManager gameManager;
    public Animator anim;
    public BoxingEnemyFaceMove boxingEnemyFaceMove;
    public GameObject playerHitCanvus;
    public SoundManager soundManager;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        ready = false;
        counter = false;
        anim = GetComponentInChildren<Animator>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.enemyHp > 0 && gameManager.isGameOver == false)
            ReadyAttack();
    }
    
    public void ReadyAttack()
    {
        if (!ready)
        {
            ready = true;
            boxingEnemyFaceMove.dontHit = false;
            ranAttack = Random.Range(0, 3);
            if (ranAttack == 0)
            {
                attackWarning.LeftAttackWarning();
                Invoke("EnemyLeftAttack", 0.8f);
            }
            else if (ranAttack == 1)
            {
                attackWarning.RightAttackWarning();
                Invoke("EnemyRightAttack", 0.8f);
            }
            else if (ranAttack == 2)                          
            {
                attackWarning.Guard();
                Invoke("EnemyUppercutAttack", 0.8f);
            }
        }
    }

    void EnemyLeftAttack()
    {
        attackWarning.ResetColor();
        PlayAttackAnim("isRightJap");
        if (enemyLeftAttackCollider.playerIsLeft)
        {
            audioSource.clip = soundManager.bgmSounds[0].clip;
            audioSource.Play();
            gameManager.playerHp -= 1;
            gameManager.PlayerHpFillAmount();
            playerHitCanvus.SetActive(true);
        }
        else if (!enemyLeftAttackCollider.playerIsLeft)
            counter = true;
        Invoke("ResetCounter", 1.3f);
        Invoke("StopAttackAnim", 1.3f);
    }

    void EnemyRightAttack()
    {
        attackWarning.ResetColor();
        PlayAttackAnim("isLeftHook");
        if (enemyRightAttackCollider.playerIsRight)
        {
            audioSource.clip = soundManager.bgmSounds[0].clip;
            audioSource.Play();
            gameManager.playerHp -= 1;
            gameManager.PlayerHpFillAmount();
            playerHitCanvus.SetActive(true);
        }
        else if (!enemyRightAttackCollider.playerIsRight)
            counter = true;
        Invoke("ResetCounter", 1.3f);
        Invoke("StopAttackAnim", 1.3f);
    }

    void EnemyUppercutAttack()
    {
        attackWarning.ResetColor();
        PlayAttackAnim("isUppercut");
        if (!enemyUppercutCollider.playerIsGuard)
        {
            audioSource.clip = soundManager.bgmSounds[0].clip;
            audioSource.Play();
            gameManager.playerHp -= 1;
            gameManager.PlayerHpFillAmount();
            playerHitCanvus.SetActive(true);
        }
        else if (enemyUppercutCollider.playerIsGuard)
        {
            counter = true;
            audioSource.clip = soundManager.bgmSounds[6].clip;
            audioSource.Play();
        }
        Invoke("ResetCounter", 1.3f);
        Invoke("StopAttackAnim", 1.3f);
    }

    void ResetCounter()
    {
        counter = false;
        playerHitCanvus.SetActive(false);
        Invoke("ResetReady", 0.5f);
    }

    void ResetReady()
    {
        ready = false;
    }

    void PlayAttackAnim(string str)
    {
        anim.SetBool(str, true);
    }

    void StopAttackAnim()
    {
        anim.SetBool("isLeftHook", false);
        anim.SetBool("isLeftJap", false);
        anim.SetBool("isRightJap", false);
        anim.SetBool("isUppercut", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
        {
            isHit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand"))
        {
            isHit = false;
        }
    }
}
