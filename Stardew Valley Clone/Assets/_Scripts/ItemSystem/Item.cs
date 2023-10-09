using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	public new string name = "New Item";	
	public Sprite Icon = null;
	public bool ShowInInventory = true;
	public int SellPrice = 30;
	public int BuyPrice = 50;

	public virtual void Use ()
	{
	}

	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}

}
