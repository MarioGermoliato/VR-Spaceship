using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform shootSource;
    [SerializeField] float distance = 10;

    private bool rayActivate = false;

    private void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
    }

    private void Update()
    {
        if (rayActivate)
        {
            RaycastCheck();
        }
    }

    private void StartShoot()
    {
        AudioManager.instance.Play("Pistol");
        particles.Play();
        rayActivate = true;
    }

    private void StopShoot()
    {
        AudioManager.instance.Stop("Pistol");
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    private void RaycastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance, layerMask);

        if (hasHit)
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
