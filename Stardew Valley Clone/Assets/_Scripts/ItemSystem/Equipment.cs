using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item {

	public EquipmentSlot equipSlot;
	public Sprite[] EquipmentVisualSprites;

	public override void Use ()
	{
		EquipmentManager.Instance.Equip(this);
		RemoveFromInventory();
	}
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon}
