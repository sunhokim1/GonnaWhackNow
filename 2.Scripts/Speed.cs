using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float punchSpeed = 0;
    public bool isLefthook;
    public bool isRighthook;
    public bool isIdle;
    public bool isJab;
    public bool isUppercut;

    Vector3 lastPosition = Vector3.zero;

    private void Start()
    {
        isLefthook = false;
        isRighthook = false;
        isJab = false;
        isUppercut = false;
        isIdle = true;
    }
    void Update()
    {
        punchSpeed = (((transform.position - lastPosition).magnitude) / Time.deltaTime);
        if (transform.position.x - lastPosition.x < -0.01)
        {
            isIdle = false;
            isLefthook = false;
            isJab = false;
            isUppercut = false;
            isRighthook = true;
        }
        else if (transform.position.x - lastPosition.x > 0.01)
        {
            isIdle = false;
            isRighthook = false;
            isJab = false;
            isUppercut = false;
            isLefthook = true;
        }
        else if (transform.position.z - lastPosition.z > 0.01)
        {
            isIdle = false;
            isRighthook = false;
            isLefthook = false;
            isUppercut = false;
            isJab = true;
        }
        else if (transform.position.y - lastPosition.y > 0.01)
        {
            isIdle = false;
            isRighthook = false;
            isLefthook = false;
            isJab = false;
            isUppercut = true;
        }
        else
        {
            isLefthook = false;
            isRighthook = false;
            isJab = false;
            isUppercut = false;
            isIdle = true;
        }
        lastPosition = transform.position;
    }
}
