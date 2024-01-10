using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabGlove : MonoBehaviour
{
    public GameObject leftGlove;
    public GameObject rightGlove;
    public bool isRight;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RightHand"))
        {
            isRight = true;
        }

        if (collision.gameObject.CompareTag("LeftHand"))
        {
            isRight = false;
        }
    }

    public void CollisionEnter()
    {
        if (isRight)
        {
            leftGlove.gameObject.SetActive(true);
        }

        if (!isRight)
        {
            rightGlove.gameObject.SetActive(true);
        }
    }

    public void CollisionExit()
    {
        if (isRight)
        {
            leftGlove.gameObject.SetActive(false);
        }

        if (!isRight)
        {
            rightGlove.gameObject.SetActive(false);
        }
    }
}
