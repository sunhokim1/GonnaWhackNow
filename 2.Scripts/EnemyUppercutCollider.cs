using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUppercutCollider : MonoBehaviour
{
    public bool leftHandisGuard;
    public bool rightHandisGuard;
    public bool playerIsGuard;
    // Start is called before the first frame update
    void Start()
    {
        leftHandisGuard = false;
        rightHandisGuard = false;
        playerIsGuard = false;
    }

    void Update()
    {
        if (leftHandisGuard && rightHandisGuard)
        {
            playerIsGuard = true;
        }
        else
            playerIsGuard = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand"))
        {
            leftHandisGuard = true;
        }
        if (other.gameObject.CompareTag("RightHand"))
        {
            rightHandisGuard = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand"))
        {
            leftHandisGuard = false;
        }
        if (other.gameObject.CompareTag("RightHand"))
        {
            rightHandisGuard = false;
        }
    }
}
