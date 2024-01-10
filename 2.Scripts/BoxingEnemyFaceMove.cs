using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingEnemyFaceMove : MonoBehaviour
{
    public Speed[] spdScript;
    public BoxingGameManager gameManager;
    public bool dontHit;
    public SoundManager soundManager;
    public AudioSource audiosource;
    public BoxingEnemy boxingEnemy;
    public Animator anim;
    public GameObject hitParticle;

    // Start is called before the first frame update
    void Start()
    {
        dontHit = false;
        spdScript[0] = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<Speed>();
        spdScript[1] = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Speed>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BoxingGameManager>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        audiosource = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((spdScript[0].isLefthook || spdScript[1].isLefthook) && boxingEnemy.counter && dontHit == false && boxingEnemy.isHit)
            LeftHitAnimation();
        if ((spdScript[0].isRighthook || spdScript[1].isRighthook) && boxingEnemy.counter && dontHit == false && boxingEnemy.isHit)
            RightHitAnimation();
        if ((spdScript[0].isJab || spdScript[1].isJab) && boxingEnemy.counter && dontHit == false && boxingEnemy.isHit)
            JabHitAnimation();
        if ((spdScript[0].isUppercut || spdScript[1].isUppercut) && boxingEnemy.counter && dontHit == false && boxingEnemy.isHit)
            UppercutHitAnimation();
    }


    public void EnemyDown()
    {
        dontHit = true;
        boxingEnemy.isHit = false;
        boxingEnemy.counter = false;
        anim.SetBool("isEnemyDown", true);
        audiosource.clip = soundManager.bgmSounds[7].clip;
        audiosource.Play();
    }
    void LeftHitAnimation()
    {
        dontHit = true;
        boxingEnemy.isHit = false;
        boxingEnemy.counter = false;
        hitParticle.SetActive(true);
        gameManager.enemyHp -= 1;
        gameManager.EnemyHpFillAmount();
        anim.SetBool("isLeftHit", true);
        audiosource.clip = soundManager.bgmSounds[5].clip;
        audiosource.Play();
        Invoke("StopHitAnim", 1.3f);
    }

    void RightHitAnimation()
    {
        dontHit = true;
        boxingEnemy.isHit = false;
        boxingEnemy.counter = false;
        hitParticle.SetActive(true);
        gameManager.enemyHp -= 1;
        gameManager.EnemyHpFillAmount();
        anim.SetBool("isRightHit", true);
        audiosource.clip = soundManager.bgmSounds[5].clip;
        audiosource.Play();
        Invoke("StopHitAnim", 1.3f);
    }

    void JabHitAnimation()
    {
        dontHit = true;
        boxingEnemy.isHit = false;
        boxingEnemy.counter = false;
        hitParticle.SetActive(true);
        gameManager.enemyHp -= 1;
        gameManager.EnemyHpFillAmount();
        anim.SetBool("isJapHit", true);
        audiosource.clip = soundManager.bgmSounds[1].clip;
        audiosource.Play();
        Invoke("StopHitAnim", 1.3f);
    }

    void UppercutHitAnimation()
    {
        dontHit = true;
        boxingEnemy.isHit = false;
        boxingEnemy.counter = false;
        hitParticle.SetActive(true);
        gameManager.enemyHp -= 1;
        gameManager.EnemyHpFillAmount();
        anim.SetBool("isUppercutHit", true);
        audiosource.clip = soundManager.bgmSounds[5].clip;
        audiosource.Play();
        Invoke("StopHitAnim", 1.3f);
    }

    void StopHitAnim()
    {
        anim.SetBool("isLeftHit", false);
        anim.SetBool("isJapHit", false);
        anim.SetBool("isRightHit", false);
        anim.SetBool("isUppercutHit", false);
        hitParticle.SetActive(false);
    }
}
