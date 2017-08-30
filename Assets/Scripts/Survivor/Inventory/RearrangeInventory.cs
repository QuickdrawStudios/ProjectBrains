using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearrangeInventory : MonoBehaviour {

	[HideInInspector]
	public Survivor survivor;

	public InventorySlot leftHandSlot, rightHandSlot, backPack1Slot, backPack2Slot, backPack3Slot;

	public GameObject inventoryScreen;
	public GameObject inventoryItemUIPrefab;

	public void ShowInventoryScreen(){
		MouseControl.instance.controllable = false;
		PopulateItems();
		inventoryScreen.SetActive(true);
	}

	void HideInventoryScreen(){
		MouseControl.instance.controllable = true;
		RemoveItems();
		inventoryScreen.SetActive(false);
	}

	void PopulateItems(){
		for(int i = 0; i < 5; i++){
			InventorySlot slotToPopulate = null;
			Item itemToPopulate = null;
			switch(i){
				case 0:
					slotToPopulate = leftHandSlot;
					itemToPopulate = survivor.inventory.leftHand;
					break;
				case 1:
					slotToPopulate = rightHandSlot;
					itemToPopulate = survivor.inventory.rightHand;
					break;
				case 2:
					slotToPopulate = backPack1Slot;
					itemToPopulate = survivor.inventory.backPack1;
					break;
				case 3:
					slotToPopulate = backPack2Slot;
					itemToPopulate = survivor.inventory.backPack2;
					break;
				case 4:
					slotToPopulate = backPack3Slot;
					itemToPopulate = survivor.inventory.backPack3;
					break;
			}
			if(itemToPopulate){
				GameObject _item = (GameObject)Instantiate(inventoryItemUIPrefab, slotToPopulate.transform, false);
				_item.transform.SetAsFirstSibling();
				InventoryItem inventoryItem = _item.GetComponent<InventoryItem>();
				slotToPopulate.inventoryItem = inventoryItem;
				inventoryItem.inventorySlot = slotToPopulate;
				inventoryItem.item = itemToPopulate;
				inventoryItem.itemImage.sprite = itemToPopulate.inventoryImage;
				inventoryItem.survivor = survivor;
			}
		}
	}

	void RemoveItems(){
		if(leftHandSlot.transform.childCount > 0){
			if(leftHandSlot.transform.GetChild(0).tag == "ItemUI"){
				Destroy(leftHandSlot.transform.GetChild(0).gameObject);
				leftHandSlot.inventoryItem = null;
			}
		}
		if(rightHandSlot.transform.childCount > 0){
			if(rightHandSlot.transform.GetChild(0).tag == "ItemUI"){
				Destroy(rightHandSlot.transform.GetChild(0).gameObject);
				rightHandSlot.inventoryItem = null;
			}
		}
		if(backPack1Slot.transform.childCount > 0){
			if(backPack1Slot.transform.GetChild(0).tag == "ItemUI"){
				Destroy(backPack1Slot.transform.GetChild(0).gameObject);
				backPack1Slot.inventoryItem = null;
			}
		}
		if(backPack2Slot.transform.childCount > 0){
			if(backPack2Slot.transform.GetChild(0).tag == "ItemUI"){
				Destroy(backPack2Slot.transform.GetChild(0).gameObject);
				backPack2Slot.inventoryItem = null;
			}
		}
		if(backPack3Slot.transform.childCount > 0){
			if(backPack3Slot.transform.GetChild(0).tag == "ItemUI"){
				Destroy(backPack3Slot.transform.GetChild(0).gameObject);
				backPack3Slot.inventoryItem = null;
			}
		}
	}

	void RearrangeItems(){
		if(leftHandSlot.GetItem()){
			survivor.inventory.PickUpLeftHand(leftHandSlot.GetItem());
		} else {
			survivor.inventory.DropLeftHand();
		}
		if(rightHandSlot.GetItem()){
			survivor.inventory.PickUpRightHand(rightHandSlot.GetItem());
		} else {
			survivor.inventory.DropRightHand();
		}
		if(backPack1Slot.GetItem()){
			survivor.inventory.PickUpBackPack1(backPack1Slot.GetItem());
		} else {
			survivor.inventory.DropBackPack1();
		}
		if(backPack2Slot.GetItem()){
			survivor.inventory.PickUpBackPack2(backPack2Slot.GetItem());
		} else {
			survivor.inventory.DropBackPack2();
		}
		if(backPack3Slot.GetItem()){
			survivor.inventory.PickUpBackPack3(backPack3Slot.GetItem());
		} else {
			survivor.inventory.DropBackPack3();
		}
	}

	void DropItems(){
		for(int i = DropItem.droppedItems.Count - 1; i >= 0; i--){
			survivor.currentSpot.loot.Add(DropItem.droppedItems[i]);
			GameObject item = (GameObject)Instantiate(DropItem.droppedItems[i].objectPrefab, survivor.currentSpot.FindStandingSpot(), Quaternion.identity);
			DropItem.droppedItems[i]._object = item;
			DropItem.droppedItems.RemoveAt(i);
		}
	}

	public void ConfirmButtonClick(){
		UseAction();
		DropItems();
		RearrangeItems();
		HideInventoryScreen();
	}

	void UseAction(){
		List<Item> inventoryItems = new List<Item>();
		List<Item> rearrangedItems = new List<Item>();
		inventoryItems.Add(survivor.inventory.leftHand);
		inventoryItems.Add(survivor.inventory.rightHand);
		inventoryItems.Add(survivor.inventory.backPack1);
		inventoryItems.Add(survivor.inventory.backPack2);
		inventoryItems.Add(survivor.inventory.backPack3);
		rearrangedItems.Add(leftHandSlot.GetItem());
		rearrangedItems.Add(rightHandSlot.GetItem());
		rearrangedItems.Add(backPack1Slot.GetItem());
		rearrangedItems.Add(backPack2Slot.GetItem());
		rearrangedItems.Add(backPack3Slot.GetItem());
		bool rearranged = false;
		for(int i = 0; i < inventoryItems.Count; i++){
			if(rearrangedItems[i] != null){
				if(inventoryItems[i] != rearrangedItems[i]){
					rearranged = true;
					break;
				}
			}
		}
		if(rearranged){
			survivor.action.UseAction();
		}
	}

	public void CancelButtonClick(){
		HideInventoryScreen();
	}
}
