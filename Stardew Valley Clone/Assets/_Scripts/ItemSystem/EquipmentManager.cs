using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EquipmentManager : MonoBehaviour {

	#region Singleton
	public static EquipmentManager Instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<EquipmentManager> ();
			}
			return _instance;
		}
	}
	static EquipmentManager _instance;

	void Awake ()
	{
		_instance = this;
	}
	#endregion

	public Equipment[] DefaultWear;
	[SerializeField] private List<InventorySlot> _equipmentSlots;

	[SerializeField] private Equipment[] _currentEquipment;
	[SerializeField]private PlayerEquipmentVisualSlots[] _currentVisualSlotsArray;
	[SerializeField]private GameObject _equipmentUI;
	
	public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
	public event OnEquipmentChanged onEquipmentChanged;

	private Inventory _inventory;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.U))
		{
			_equipmentUI.SetActive(!_equipmentUI.activeSelf);
		}
	}

	void Start ()
	{
		_inventory = Inventory.instance;

		int numSlots = System.Enum.GetNames (typeof(EquipmentSlot)).Length;
		_currentEquipment = new Equipment[numSlots];
		
		EquipAllDefault ();
	}

	public void OpenEquipment(bool open)
	{
		_equipmentUI.SetActive(open);
	}
	public int ReturnSlotIndex(InventorySlot slot) 
	{
		return _equipmentSlots.IndexOf(slot);
	}
	public Equipment GetEquipment(EquipmentSlot slot) {
		return _currentEquipment [(int)slot];
	}

	public void Equip (Equipment newItem)
	{
		Equipment oldItem = null;

		int slotIndex = (int)newItem.equipSlot;

		if (_currentEquipment[slotIndex] != null)
		{
			oldItem = _currentEquipment [slotIndex];

			_inventory.Add (oldItem);
	
		}

		if (onEquipmentChanged != null)
			onEquipmentChanged.Invoke(newItem, oldItem);

		_currentEquipment[slotIndex] = newItem;
		_equipmentSlots[slotIndex].AddItem(newItem);

		if (newItem.Icon != null) 
		{
			AttachToMesh(newItem.EquipmentVisualSprites, slotIndex);
		}
	}

	public void Unequip(int slotIndex) {
		if (_currentEquipment[slotIndex] != null)
		{
			Equipment oldItem = _currentEquipment[slotIndex];
			_inventory.Add(oldItem);
			_equipmentSlots[slotIndex].ClearSlot();
			_currentEquipment[slotIndex] = DefaultWear[slotIndex];
			if (onEquipmentChanged != null)
				onEquipmentChanged.Invoke(null, oldItem);
			
			Equip(DefaultWear[slotIndex]);
		}
	}

	void UnequipAll() {
		for (int i = 0; i < _currentEquipment.Length; i++) {
			Unequip (i);
		}
		EquipAllDefault ();
	}

	void EquipAllDefault() {
		foreach (Equipment e in DefaultWear) {
			Equip (e);
		}
	}

	void AttachToMesh(Sprite[] sprite, int slotIndex) 
	{
		for (int i = 0; i < _currentVisualSlotsArray[slotIndex].EquipmentVisualSlots.Length; i++)
		{
			_currentVisualSlotsArray[slotIndex].EquipmentVisualSlots[i].sprite = sprite[i];
		}
	}

}
