using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testblock : MonoBehaviour
{ 
    public bool isHit;
    public Animator anim;
    public GameObject point;
    public GameObject playerHitCanvus;
    public GameManager gameManager;
    public SoundManager soundManager;
    public AudioSource audioSource;
    public bool isAttack;
    public bool isEnemy;

    // Start is called before the first frame update

    [System.Obsolete]
    void Start()
    {
        anim = point.GetComponent<Animator>();
        isHit = false;
        isAttack = false;
        playerHitCanvus.SetActive(false);
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent <SoundManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isEnemy = point.activeSelf;
        if (!isAttack && point.activeSelf && !gameManager.isover)
        {
            ZombieAttack();
        }
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

    void ZombieAttack()
    {
        isAttack = true;
        if (isEnemy)
            Invoke("AttackAnim", 1.5f);
    }

    void AttackAnim()
    {
        anim.SetBool("isAttack", true);
        if (isEnemy)
            Invoke("AttackCalcul", 0.3f);
        if (gameManager.playerHP > 1)
            Invoke("HitCanvusFalse", 0.6f);
        Invoke("AttackReady", 1f);
    }
    
    void AttackCalcul()
    {
        gameManager.playerHP -= 1;
        audioSource.clip = soundManager.bgmSounds[5].clip;
        audioSource.Play();
        playerHitCanvus.SetActive(true);
    }

    void HitCanvusFalse()
    {
        playerHitCanvus.SetActive(false);
    }

    void AttackReady()
    {
        isAttack = false;
        anim.SetBool("isAttack", false);
    }
}
