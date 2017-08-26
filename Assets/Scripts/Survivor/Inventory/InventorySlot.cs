using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler {
	[HideInInspector]
	public InventoryItem inventoryItem;

	public void OnDrop(PointerEventData eventData){
		if(!inventoryItem){
			inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
			inventoryItem.transform.SetParent(transform);
			inventoryItem.transform.SetAsFirstSibling();
			inventoryItem.inventorySlot = this;
			RectTransform rectTransform = inventoryItem.GetComponent<RectTransform>();
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
		} else {
			InventoryItem swapInventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();

			inventoryItem.transform.SetParent(swapInventoryItem.inventorySlot.transform);
			inventoryItem.transform.SetAsFirstSibling();
			inventoryItem.inventorySlot = swapInventoryItem.inventorySlot;
			swapInventoryItem.inventorySlot.inventoryItem = inventoryItem;
			RectTransform rectTransform = inventoryItem.GetComponent<RectTransform>();
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;

			swapInventoryItem.transform.SetParent(transform);
			swapInventoryItem.transform.SetAsFirstSibling();
			swapInventoryItem.inventorySlot = this;
			RectTransform swapRectTransform = swapInventoryItem.GetComponent<RectTransform>();
			swapRectTransform.offsetMin = Vector2.zero;
			swapRectTransform.offsetMax = Vector2.zero;
			inventoryItem = swapInventoryItem;
		}
	}

	public Item GetItem(){
		if(inventoryItem){
			return inventoryItem.item;
		} else {
			return null;
		}
	}
}
