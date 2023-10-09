using System;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable 
{

	[SerializeField] private Item _item;
	[SerializeField] private SpriteRenderer _spriteRenderer;
	[field:SerializeField] public GameObject InteractVisual { get; set; }

	private void Start()
	{
		_spriteRenderer.sprite = _item.Icon;
	}

	void PickUp ()
	{
		Inventory.instance.Add(_item);

		Destroy(gameObject);
	}

	public void Interact()
	{
		PickUp();
	}

	public void SetFocus(bool focus)
	{
		InteractVisual.SetActive(focus);
	}
}
