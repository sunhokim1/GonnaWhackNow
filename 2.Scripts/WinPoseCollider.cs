using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoseCollider : MonoBehaviour
{
    public BoxingGameManager gameManager;
    public bool leftHand;
    public bool rightHand;
    public bool isWinPose;

    private void Start()
    {
        isWinPose = false;
    }
    private void Update()
    {
        if (gameManager.isWin)
            WinPose();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            leftHand = true;
        }
        if (other.CompareTag("RightHand"))
        {
            rightHand = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            leftHand = false;
        }
        if (other.CompareTag("RightHand"))
        {
            rightHand = false;
        }
    }
    void WinPose()
    {
        if (leftHand && rightHand)
            isWinPose = true;
        else
            isWinPose = false;
    }
}
