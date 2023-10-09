using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionDetector : MonoBehaviour
{
    [SerializeField] private SimpleTrigger _trigger;
    
    private List<IInteractable> _currentInteractables = new ();
    
    private void OnEnable()
    {
        _trigger.onTriggerEnter += OnInteractableEnter;
        _trigger.onTriggerExit += OnInteractableExited;
    }
    
    private void OnDisable()
    {
        _trigger.onTriggerEnter -= OnInteractableEnter;
        _trigger.onTriggerExit -= OnInteractableExited;
    }

    private void Update()
    {
        if (_currentInteractables.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _currentInteractables[^1].Interact();
                if (_currentInteractables.Count > 0)
                {
                    _currentInteractables[^1].SetFocus(true);
                }
            }
        }
    }

    private void OnInteractableEnter(Transform obj)
    {
        IInteractable interactableToAdd = obj.GetComponent<IInteractable>();
        _currentInteractables.Add(interactableToAdd);
        for (int i = 0; i < _currentInteractables.Count; i++)
        {
            _currentInteractables[i].SetFocus(false);
        }
        if (_currentInteractables.Count > 0)
        {
            _currentInteractables[^1].SetFocus(true);
        }
    }
    
    private void OnInteractableExited(Transform obj)
    {
        IInteractable interactableToRemove = obj.GetComponent<IInteractable>();
        interactableToRemove.SetFocus(false);
        _currentInteractables.Remove(interactableToRemove);
        
        if (_currentInteractables.Count > 0)
        {
            _currentInteractables[^1].SetFocus(true);
        }
    }
}
