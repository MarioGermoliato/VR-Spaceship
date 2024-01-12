using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabbingHandModel : MonoBehaviour
{
    const string LEFT_HAND_TAG = "Left Hand";
    const string RIGHT_HAND_TAG = "Right Hand";

    [SerializeField] GameObject leftHandModel;
    [SerializeField] GameObject rightHandModel;

    private void Start()
    {
        XRGrabInteractable grabinteractable = GetComponent<XRGrabInteractable>();
        grabinteractable.selectEntered.AddListener(HideGrabbingHand);
        grabinteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    private void HideGrabbingHand(SelectEnterEventArgs args)
    {
       if (args.interactorObject.transform.CompareTag(LEFT_HAND_TAG))
        {
            leftHandModel.SetActive(false);
        }
       else if (args.interactorObject.transform.CompareTag(RIGHT_HAND_TAG))
        {
            rightHandModel.SetActive(false);
        }
    }

    private void ShowGrabbingHand(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag(LEFT_HAND_TAG))
        {
            leftHandModel.SetActive(true);
        }
        else if (args.interactorObject.transform.CompareTag(RIGHT_HAND_TAG))
        {
            rightHandModel.SetActive(true);
        }
    }
}
