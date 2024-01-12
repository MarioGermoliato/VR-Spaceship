using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnergyCheck : MonoBehaviour
{
    [SerializeField] XRSimpleInteractable buttonInteractable;

    XRSocketInteractor energySocket;

    private void Start()
    {
        energySocket = GetComponent<XRSocketInteractor>();
        energySocket.selectEntered.AddListener(x => EnergyOn());
        energySocket.selectExited.AddListener(x => EnergyOff());
    }

    private void EnergyOn()
    {
        buttonInteractable.enabled = true;
    }

    private void EnergyOff()
    {
        buttonInteractable.enabled = false;
    }
}
