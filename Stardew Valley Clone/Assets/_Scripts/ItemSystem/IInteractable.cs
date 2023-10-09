using UnityEngine;


public interface IInteractable
{
	public GameObject  InteractVisual { get; set; }
	void Interact();
	void SetFocus(bool focus);
}