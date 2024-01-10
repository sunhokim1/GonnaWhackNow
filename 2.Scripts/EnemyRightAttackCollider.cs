using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRightAttackCollider : MonoBehaviour
{
    public bool leftHandisRight;
    public bool rightHandisRight;
    public bool playerIsRight;
    // Start is called before the first frame update
    void Start()
    {
        leftHandisRight = false;
        rightHandisRight = false;
        playerIsRight = false;
    }

    void Update()
    {
        if (leftHandisRight || rightHandisRight)
        {
            playerIsRight = true;
        }
        else
            playerIsRight = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand"))
        {
            leftHandisRight = true;
        }
        if (other.gameObject.CompareTag("RightHand"))
        {
            rightHandisRight = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand"))
        {
            leftHandisRight = false;
        }
        if (other.gameObject.CompareTag("RightHand"))
        {
            rightHandisRight = false;
        }
    }
}
