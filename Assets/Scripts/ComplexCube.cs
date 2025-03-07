﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class ComplexCube : MonoBehaviour
{
    XRGrabInteractable m_GrabInteractable;
    MeshRenderer m_MeshRenderer;
    
    static Color m_UnityMagenta = new Color(0.929f, 0.094f, 0.278f);
    static Color m_UnityCyan = new Color(0.019f, 0.733f, 0.827f);

    bool m_Held = false;

    void OnEnable()
    {
        m_GrabInteractable = GetComponent<XRGrabInteractable>();
        m_MeshRenderer = GetComponent<MeshRenderer>();
        
        m_GrabInteractable.onFirstHoverEntered.AddListener(OnHoverEnter);
        m_GrabInteractable.onLastHoverExited.AddListener(OnHoverExit);
        m_GrabInteractable.onSelectEntered.AddListener(OnGrabbed);
        m_GrabInteractable.onSelectExited.AddListener(OnReleased);
    }

    
    private void OnDisable()
    {
        m_GrabInteractable.onFirstHoverEntered.RemoveListener(OnHoverEnter);
        m_GrabInteractable.onLastHoverExited.RemoveListener(OnHoverExit);
        m_GrabInteractable.onSelectEntered.RemoveListener(OnGrabbed);
        m_GrabInteractable.onSelectExited.RemoveListener(OnReleased);
    }

    private void OnGrabbed(XRBaseInteractor obj)
    {
        m_MeshRenderer.material.color = m_UnityCyan;
        m_Held = true;
    }
    
    void OnReleased(XRBaseInteractor obj)
    {
        m_MeshRenderer.material.color = Color.white;
        m_Held = false;
    }

    void OnHoverExit(XRBaseInteractor obj)
    {
        if (!m_Held)
        {
            m_MeshRenderer.material.color = Color.white;
        }
    }

    void OnHoverEnter(XRBaseInteractor obj)
    {
        if (!m_Held)
        {
            m_MeshRenderer.material.color = m_UnityMagenta;
        }
    }
}
