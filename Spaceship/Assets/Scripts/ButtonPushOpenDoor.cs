using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushOpenDoor : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;
    const string BOOL_NAME = "Open";
    private void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => SetAnimatorTrigger());
    }

    private void SetAnimatorTrigger()
    {
        bool isOpen = doorAnimator.GetBool(BOOL_NAME);        
        doorAnimator.SetBool(BOOL_NAME, !isOpen);

        AudioManager.instance.Play("Door");
    }
}
