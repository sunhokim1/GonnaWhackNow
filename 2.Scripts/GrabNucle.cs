using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabNucle : MonoBehaviour
{
    public GameObject leftNucle;
    public GameObject rightNucle;
    public bool isRight;
    public bool isSelect;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RightHand"))
        {
            isRight = true;
            isSelect = true;
        }

        if (collision.gameObject.CompareTag("LeftHand"))
        {
            isRight = false;
            isSelect = true;
        }
    }

    //public void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("RightHand"))
    //    {
    //        leftNucle.gameObject.SetActive(false);
    //    }

    //    if (collision.gameObject.CompareTag("LeftHand"))
    //    {
    //        rightNucle.gameObject.SetActive(false);
    //    }
    //}
    public void CollisionEnter()
    {
        if (isRight)
        {
            leftNucle.gameObject.SetActive(true);
        }

        if (!isRight)
        {
            rightNucle.gameObject.SetActive(true);
        }
    }

    public void CollisionExit()
    {
        if (isRight)
        {
            leftNucle.gameObject.SetActive(false);
        }

        if (!isRight)
        {
            rightNucle.gameObject.SetActive(false);
        }
    }
}
