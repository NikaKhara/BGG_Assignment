using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour {

	public Image icon;
	public Button removeButton;
	public Button UseButton;
	[SerializeField] bool _isEquipmentSlot;

	Item item;

	private void Start()
	{
		if (_isEquipmentSlot)
		{
			UseButton.onClick.AddListener(UnequipItem);
		}
	}

	public void AddItem (Item newItem)
	{
		item = newItem;

		icon.sprite = item.Icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}

	public void BuyItem()
	{
		if (CoinSystem.instance.CanAfford(item.BuyPrice))
		{
			CoinSystem.instance.RemoveCoins(item.BuyPrice);
			Inventory.instance.Add(item);
			ClearSlot();
			Inventory.instance.InventoryUI.UpdateUI();
		}
	}
	
	public void SellItem()
	{
		CoinSystem.instance.AddCoins(item.SellPrice);
		Inventory.instance.Remove(item);
		ClearSlot();
		Inventory.instance.InventoryUI.UpdateUI();
	}
	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	public void UnequipItem()
	{
		if (_isEquipmentSlot && item != null)
		{
			EquipmentManager.Instance.Unequip(EquipmentManager.Instance.ReturnSlotIndex(this));
			Inventory.instance.InventoryUI.UpdateUI();
		}
	}
	public void RemoveItemFromInventory ()
	{
		Inventory.instance.Remove(item);
	}

	public void UseItem ()
	{
		if (item != null && !ShopSystem.instance.ShopUI.activeSelf)
		{
			item.Use();
		}
		else if (item != null && ShopSystem.instance.ShopUI.activeSelf)
		{
			SellItem();
		}
	}

}
