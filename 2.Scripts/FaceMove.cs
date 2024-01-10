using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using UnityEngine;

public class FaceMove : MonoBehaviour
{
    public Speed[] spdScript;
    public Testblock test;
    public GameManager gameManager;
    public bool dontHit;
    public GameObject[] ZombieAnim;
    public SoundManager soundManager;
    public AudioSource audiosource;
    public BoxCollider collier;
    public ScoreData scoreData;
    // Start is called before the first frame update
    void Start()
    {
        dontHit = false;
        spdScript[0] = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<Speed>();
        spdScript[1] = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Speed>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        audiosource = GetComponent<AudioSource>();
        collier = GetComponent<BoxCollider>();
        collier.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((spdScript[0].isLefthook || spdScript[1].isLefthook) && test.isHit && dontHit == false)
            LeftHitAnimation();
        if ((spdScript[0].isRighthook || spdScript[1].isRighthook) && test.isHit && dontHit == false)
            RightHitAnimation();
        if ((spdScript[0].isJab || spdScript[1].isJab) && test.isHit && dontHit == false)
            JabHitAnimation();
        if ((spdScript[0].isUppercut || spdScript[1].isUppercut) && test.isHit && dontHit == false)
            UppercutHitAnimation();
    }

    void LeftHitAnimation()
    {
        dontHit = true;
        collier.enabled = false;
        test.point.SetActive(false);
        ZombieAnim[2].SetActive(true);
        audiosource.clip = soundManager.bgmSounds[3].clip;
        audiosource.Play();
        scoreData.ScoreCount();
        Invoke("AfterSetSwich", 1);
    }

    void RightHitAnimation()
    {
        dontHit = true;
        collier.enabled = false;
        test.point.SetActive(false);
        ZombieAnim[3].SetActive(true);
        audiosource.clip = soundManager.bgmSounds[3].clip;
        audiosource.Play();
        scoreData.ScoreCount();
        Invoke("AfterSetSwich", 1);
    }

    void JabHitAnimation()
    {
        dontHit = true;
        collier.enabled = false;
        test.point.SetActive(false);
        ZombieAnim[1].SetActive(true);
        audiosource.clip = soundManager.bgmSounds[3].clip;
        audiosource.Play();
        scoreData.ScoreCount();
        Invoke("AfterSetSwich", 1);
    }

    void UppercutHitAnimation()
    {
        dontHit = true;
        collier.enabled = false;
        test.point.SetActive(false);
        ZombieAnim[4].SetActive(true);
        audiosource.clip = soundManager.bgmSounds[3].clip;
        audiosource.Play();
        scoreData.ScoreCount();
        Invoke("AfterSetSwich", 1);
    }

    void AfterSetSwich()
    {
        gameManager.count--;
        ZombieAnim[1].SetActive(false);
        ZombieAnim[2].SetActive(false);
        ZombieAnim[3].SetActive(false);
        ZombieAnim[4].SetActive(false);
    }
}
