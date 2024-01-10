using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeftAttackCollider : MonoBehaviour
{
    public bool leftHandisLeft;
    public bool rightHandisLeft;
    public bool playerIsLeft;
    // Start is called before the first frame update
    void Start()
    {
        leftHandisLeft = false;
        rightHandisLeft = false;
        playerIsLeft = false;
    }

    void Update()
    {
        if (leftHandisLeft || rightHandisLeft)
        {
            playerIsLeft = true;
        }
        else
            playerIsLeft = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand"))
        {
            leftHandisLeft = true;
        }
        if (other.gameObject.CompareTag("RightHand"))
        {
            rightHandisLeft = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand"))
        {
            leftHandisLeft = false;
        }
        if (other.gameObject.CompareTag("RightHand"))
        {
            rightHandisLeft = false;
        }
    }
}
