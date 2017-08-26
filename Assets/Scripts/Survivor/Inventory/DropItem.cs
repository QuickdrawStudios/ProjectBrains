using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler {

	public static List<Item> droppedItems = new List<Item>();

	public void OnDrop(PointerEventData eventData){
		InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
		inventoryItem.inventorySlot.inventoryItem = null;
		droppedItems.Add(inventoryItem.item);
		Destroy(inventoryItem.gameObject);
	}
}
