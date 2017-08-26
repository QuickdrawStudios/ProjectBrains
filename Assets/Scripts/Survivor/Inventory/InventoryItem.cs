using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
	Vector3 startPosition;
	Transform startParent;

	public Item item;
	public Image itemImage;
	public CanvasGroup canvasGroup;

	public InventorySlot inventorySlot;

	public Survivor survivor;

	public void OnBeginDrag(PointerEventData eventData){
		transform.parent.SetAsLastSibling();
		startPosition = transform.position;
		startParent = transform.parent;
		inventorySlot.inventoryItem = null;
		canvasGroup.blocksRaycasts = false;
		itemImage.raycastTarget = false;
	}

	public void OnDrag(PointerEventData eventData){
		transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData){
		canvasGroup.blocksRaycasts = true;
		itemImage.raycastTarget = true;
		if(transform.parent == startParent){
			transform.position = startPosition;
			inventorySlot.inventoryItem = this;
		}
	}
}
