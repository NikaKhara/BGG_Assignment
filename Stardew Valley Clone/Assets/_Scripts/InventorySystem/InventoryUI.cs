using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	[SerializeField] private GameObject inventoryUI;
	[SerializeField] private Transform itemsParent;
	[SerializeField] private InventorySlot[] slots;

	private Inventory inventory;

	void Start ()
	{
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			OpenInventory(!inventoryUI.activeSelf);
		}
	}
	
	public void OpenInventory(bool open)
	{
		inventoryUI.SetActive(open);
		UpdateUI();
	}

	public void UpdateUI ()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			} else
			{
				slots[i].ClearSlot();
			}
		}
	}
}
