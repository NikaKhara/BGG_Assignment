using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
	[SerializeField] private GameObject _shopUI;
	[SerializeField] private List<InventorySlot> _inventorySlots;
	[SerializeField] private List<Item> _itemsToSell;
	
	private CoinSystem _coinSystem;
	private Inventory _inventory;
	public GameObject ShopUI => _shopUI;
	#region Singleton


	public static ShopSystem instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<ShopSystem> ();
			}
			return _instance;
		}
	}
	static ShopSystem _instance;

	void Awake ()
	{
		_instance = this;
	}

	#endregion

	private void Start()
	{
		_coinSystem = CoinSystem.instance;
		_inventory = Inventory.instance;
		InitializeSellItems();
	}

	public void OpenShop(bool open)
	{
		_shopUI.SetActive(open);
		InitializeSellItems();
	}
	
	public void InitializeSellItems ()
	{
		for (int i = 0; i < _inventorySlots.Count; i++)
		{
			_inventorySlots[i].AddItem(_itemsToSell[i]);
		}
	}
	
	public void BuyItem(Item item)
	{
		if (_coinSystem.CanAfford(item.BuyPrice))
		{
			
			_coinSystem.RemoveCoins(item.BuyPrice);
			_inventory.Add(item);
			InitializeSellItems();
		}
		else
		{
			Debug.Log("Not enough coins");
		}
	}
	
	public void SellItem(Item item)
	{
		_coinSystem.AddCoins(item.SellPrice);
	}
}
