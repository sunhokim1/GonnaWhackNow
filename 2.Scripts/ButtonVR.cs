using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool ispressed;
    public Vector3 offset;
    public AudioSource ButtonSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (!ispressed)
        {
            button.transform.localPosition = offset + new Vector3(0, 0, 7);
            presser = other.gameObject;
            //onPress.Invoke();
            ButtonSFX.Play();
            ispressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = offset; // + new Vector3(0, 0.08f, 0);
            //onRelease.Invoke();
            onPress.Invoke();
            ispressed = false;
        }
    }

    private void Start()
    {
        offset = button.transform.localPosition;
    }
}
