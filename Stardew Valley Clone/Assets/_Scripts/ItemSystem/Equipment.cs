using UnityEngine;

/* An Item that can be equipped to increase armor/damage. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item {

	public EquipmentSlot equipSlot;		// What slot to equip it in
	public int armorModifier;
	public int damageModifier;
	public Sprite[] EquipmentVisualSprites;

	// Called when pressed in the inventory
	public override void Use ()
	{
		EquipmentManager.Instance.Equip(this);	// Equip
		RemoveFromInventory();	// Remove from inventory
	}
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon}
