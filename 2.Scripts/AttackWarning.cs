using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackWarning : MonoBehaviour
{
    public Image leftAttackWarning;
    public Image rightAttackWarning;
    public Image guard;
    public Color warningColor;
    public Color guardColor;
    public Color resetColor;
    // Start is called before the first frame update
    void Start()
    {
        leftAttackWarning = leftAttackWarning.GetComponent<Image>();
        rightAttackWarning = rightAttackWarning.GetComponent<Image>();
        guard = guard.GetComponent<Image>();
        warningColor = new Color(1, 0, 0, 0.3f);
        guardColor = new Color(0, 1, 0, 0.3f);
        resetColor = new Color(0, 0, 0, 0);
    }

    public void LeftAttackWarning()
    {
        leftAttackWarning.color = warningColor;
    }
    public void RightAttackWarning()
    {
        rightAttackWarning.color = warningColor;
    }
    public void Guard()
    {
        guard.color = guardColor;
    }
    public void ResetColor()
    {
        leftAttackWarning.color = resetColor;
        rightAttackWarning.color = resetColor;
        guard.color = resetColor;
    }
}
