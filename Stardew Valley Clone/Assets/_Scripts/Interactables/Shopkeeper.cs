using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
	private ShopSystem _shopSystem;
	private Inventory _inventory;
	private EquipmentManager _equipmentManager;
	[field:SerializeField] public GameObject InteractVisual { get; set; }

	private void Start()
	{
		_shopSystem = ShopSystem.instance;
		_inventory = Inventory.instance;
		_equipmentManager = EquipmentManager.Instance;
	}

	public void Interact()
	{
		_shopSystem.OpenShop(!_shopSystem.ShopUI.activeSelf);
		_inventory.InventoryUI.OpenInventory(true);
		_equipmentManager.OpenEquipment(false);
	}

	public void SetFocus(bool focus)
	{
		InteractVisual.SetActive(focus);
		if (focus == false)
		{
			_shopSystem.OpenShop(false);
			_inventory.InventoryUI.OpenInventory(false);
			_equipmentManager.OpenEquipment(false);
		}
	}
}
