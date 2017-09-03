//CAN YOU REARRANGE ON THE TRADE SCREEN?

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreInventory : MonoBehaviour {

	[HideInInspector]
	public Survivor survivor;
	Storage storage;

	public InventorySlot[] inventorySlots = new InventorySlot[5];// leftHandSlot, rightHandSlot, backPack1Slot, backPack2Slot, backPack3Slot;
	public InventorySlot[] storageSlots = new InventorySlot[5];// storage1Slot, storage2Slot, storage3Slot, storage4Slot, storage5Slot;

	public Image storageImage;

	public GameObject storeScreen;
	public GameObject inventoryItemUIPrefab;

	public void ShowStoreScreen(Storage storage){
		MouseControl.instance.controllable = false;
		this.storage = storage;
		SetCharacterImages();
		PopulateItems();
		storeScreen.SetActive(true);
	}

	void HideStoreScreen(){
		MouseControl.instance.controllable = true;
		RemoveItems();
		storage = null;
		storeScreen.SetActive(false);
	}

	void SetCharacterImages(){
		storageImage.sprite = storage.storageImage;
	}

	void PopulateItems(){
		for(int i = 0; i < inventorySlots.Length; i++){
			if(survivor.inventory.items[i]){
				GameObject _item = (GameObject)Instantiate(inventoryItemUIPrefab, inventorySlots[i].transform, false);
				_item.transform.SetAsFirstSibling();
				InventoryItem inventoryItem = _item.GetComponent<InventoryItem>();
				inventorySlots[i].inventoryItem = inventoryItem;
				inventoryItem.inventorySlot = inventorySlots[i];
				inventoryItem.item = survivor.inventory.items[i];
				inventoryItem.itemImage.sprite = survivor.inventory.items[i].inventoryImage;
			}
		}

		for(int i = 0; i < storageSlots.Length; i++){
			if(storage.storedItems[i]){
				GameObject _item = (GameObject)Instantiate(inventoryItemUIPrefab, storageSlots[i].transform, false);
				_item.transform.SetAsFirstSibling();
				InventoryItem inventoryItem = _item.GetComponent<InventoryItem>();
				storageSlots[i].inventoryItem = inventoryItem;
				inventoryItem.inventorySlot = storageSlots[i];
				inventoryItem.item = storage.storedItems[i];
				inventoryItem.itemImage.sprite = storage.storedItems[i].inventoryImage;
			}
		}

//		for(int i = 0; i < 5; i++){
//			InventorySlot slotToPopulate = null;
//			Item itemToPopulate = null;
//			switch(i){
//				case 0:
//					slotToPopulate = leftHandSlot;
//					itemToPopulate = survivor.inventory.leftHand;
//					break;
//				case 1:
//					slotToPopulate = rightHandSlot;
//					itemToPopulate = survivor.inventory.rightHand;
//					break;
//				case 2:
//					slotToPopulate = backPack1Slot;
//				itemToPopulate = survivor.inventory.backPack1;
//						break;
//				case 3:
//					slotToPopulate = backPack2Slot;
//					itemToPopulate = survivor.inventory.backPack2;
//					break;
//				case 4:
//					slotToPopulate = backPack3Slot;
//					itemToPopulate = survivor.inventory.backPack3;
//					break;
//			}
//			if(itemToPopulate){
//				GameObject _item = (GameObject)Instantiate(inventoryItemUIPrefab, slotToPopulate.transform, false);
//				_item.transform.SetAsFirstSibling();
//				InventoryItem inventoryItem = _item.GetComponent<InventoryItem>();
//				slotToPopulate.inventoryItem = inventoryItem;
//				inventoryItem.inventorySlot = slotToPopulate;
//				inventoryItem.item = itemToPopulate;
//				inventoryItem.itemImage.sprite = itemToPopulate.inventoryImage;
//				//inventoryItem.survivor = survivor;
//			}
//		}
	}

	void RemoveItems(){
		for(int i = 0; i < inventorySlots.Length; i++){
			if(inventorySlots[i].transform.childCount > 0){
				if(inventorySlots[i].transform.GetChild(0).tag == "ItemUI"){
					Destroy(inventorySlots[i].transform.GetChild(0).gameObject);
					inventorySlots[i].inventoryItem = null;
				}
			}
		}
		for(int i = 0; i < storageSlots.Length; i++){
			if(storageSlots[i].transform.childCount > 0){
				if(storageSlots[i].transform.GetChild(0).tag == "ItemUI"){
					Destroy(storageSlots[i].transform.GetChild(0).gameObject);
					storageSlots[i].inventoryItem = null;
				}
			}
		}
//		if(leftHandSlot.transform.childCount > 0){
//			if(leftHandSlot.transform.GetChild(0).tag == "ItemUI"){
//				Destroy(leftHandSlot.transform.GetChild(0).gameObject);
//				leftHandSlot.inventoryItem = null;
//			}
//		}
//		if(rightHandSlot.transform.childCount > 0){
//			if(rightHandSlot.transform.GetChild(0).tag == "ItemUI"){
//				Destroy(rightHandSlot.transform.GetChild(0).gameObject);
//				rightHandSlot.inventoryItem = null;
//			}
//		}
//		if(backPack1Slot.transform.childCount > 0){
//			if(backPack1Slot.transform.GetChild(0).tag == "ItemUI"){
//				Destroy(backPack1Slot.transform.GetChild(0).gameObject);
//				backPack1Slot.inventoryItem = null;
//			}
//		}
//		if(backPack2Slot.transform.childCount > 0){
//			if(backPack2Slot.transform.GetChild(0).tag == "ItemUI"){
//				Destroy(backPack2Slot.transform.GetChild(0).gameObject);
//				backPack2Slot.inventoryItem = null;
//			}
//		}
//		if(backPack3Slot.transform.childCount > 0){
//			if(backPack3Slot.transform.GetChild(0).tag == "ItemUI"){
//				Destroy(backPack3Slot.transform.GetChild(0).gameObject);
//				backPack3Slot.inventoryItem = null;
//			}
//		}
	}

	void StoreItems(){
		for(int i = 0; i < storageSlots.Length; i++){
			if(storageSlots[i].GetItem()){
				storage.StoreItem(i, storageSlots[i].GetItem());
			} else {
				storage.UnStoreItem(i);
			}
		}

		for(int i = 0; i < inventorySlots.Length; i++){
			if(inventorySlots[i].GetItem()){
				survivor.inventory.PickUpItem(inventorySlots[i].GetItem(),(ItemSlot)i);
			} else {
				survivor.inventory.DropItem((ItemSlot)i);
			}
		}

//		if(leftHandSlot.GetItem()){
//			survivor.inventory.PickUpLeftHand(leftHandSlot.GetItem());
//		} else {
//			survivor.inventory.DropLeftHand();
//		}
//		if(rightHandSlot.GetItem()){
//			survivor.inventory.PickUpRightHand(rightHandSlot.GetItem());
//		} else {
//			survivor.inventory.DropRightHand();
//		}
//		if(backPack1Slot.GetItem()){
//			survivor.inventory.PickUpBackPack1(backPack1Slot.GetItem());
//		} else {
//			survivor.inventory.DropBackPack1();
//		}
//		if(backPack2Slot.GetItem()){
//			survivor.inventory.PickUpBackPack2(backPack2Slot.GetItem());
//		} else {
//			survivor.inventory.DropBackPack2();
//		}
//		if(backPack3Slot.GetItem()){
//			survivor.inventory.PickUpBackPack3(backPack3Slot.GetItem());
//		} else {
//			survivor.inventory.DropBackPack3();
//		}
//		if(otherRightHandSlot.GetItem()){
//			Survivor.inventory.PickUpRightHand(otherRightHandSlot.GetItem());
//		} else {
//			Survivor.inventory.DropRightHand();
//		}
//		if(otherBackPack1Slot.GetItem()){
//			otherSurvivor.inventory.PickUpBackPack1(otherBackPack1Slot.GetItem());
//		} else {
//			otherSurvivor.inventory.DropBackPack1();
//		}
//		if(otherBackPack2Slot.GetItem()){
//			otherSurvivor.inventory.PickUpBackPack2(otherBackPack2Slot.GetItem());
//		} else {
//			otherSurvivor.inventory.DropBackPack2();
//		}
//		if(otherBackPack3Slot.GetItem()){
//			otherSurvivor.inventory.PickUpBackPack3(otherBackPack3Slot.GetItem());
//		} else {
//			otherSurvivor.inventory.DropBackPack3();
//		}
	}

	public void ConfirmButtonClick(){
		UseAction();
		StoreItems();
		HideStoreScreen();
	}

	void UseAction(){
		bool rearranged = CheckForRearrange();
		bool stored = CheckForStored();
		if(stored || rearranged){
			Debug.Log("USED ACTION");
			survivor.action.UseAction();
		} 
	}

	public bool CheckForRearrange(){
		int handItemsSum = 0;
		int handItemsProduct = 1;
		int rearrangedHandItemsSum = 0;
		int rearrangedHandItemsProduct = 1;
		int backPackItemsSum = 0;
		int backPackItemsProduct = 1;
		int rearrangedBackPackItemsSum = 0;
		int rearrangedBackPackItemsProduct = 1;

		for(int i = 0; i < 2; i++){
			if(survivor.inventory.items[i]){
				handItemsSum += survivor.inventory.items[i].id;
				handItemsProduct *= survivor.inventory.items[i].id;
			}
			if(inventorySlots[i].GetItem()){
				rearrangedHandItemsSum += inventorySlots[i].GetItem().id;
				rearrangedHandItemsProduct *= inventorySlots[i].GetItem().id;
			}
		}

		for(int i = 2; i < 5; i++){
			if(survivor.inventory.items[i]){
				backPackItemsSum += survivor.inventory.items[i].id;
				backPackItemsProduct *= survivor.inventory.items[i].id;
			}
			if(inventorySlots[i].GetItem()){
				rearrangedBackPackItemsSum += inventorySlots[i].GetItem().id;
				rearrangedBackPackItemsProduct *= inventorySlots[i].GetItem().id;
			}
		}

//		if(survivor.inventory.items[(int)ItemSlot.LEFT_HAND]){
//			handItemsSum += survivor.inventory.items[(int)ItemSlot.LEFT_HAND].id;
//			handItemsProduct *= survivor.inventory.items[(int)ItemSlot.LEFT_HAND].id;
//		}
//		if(survivor.inventory.items[(int)ItemSlot.RIGHT_HAND]){
//			handItemsSum += survivor.inventory.items[(int)ItemSlot.RIGHT_HAND].id;
//			handItemsProduct *= survivor.inventory.items[(int)ItemSlot.RIGHT_HAND].id;
//		}
//		if(survivor.inventory.items[(int)ItemSlot.BACKPACK_1]){
//			backPackItemsSum += survivor.inventory.items[(int)ItemSlot.BACKPACK_1].id;
//			backPackItemsProduct *= survivor.inventory.items[(int)ItemSlot.BACKPACK_1].id;
//		}
//		if(survivor.inventory.items[(int)ItemSlot.BACKPACK_2]){
//			backPackItemsSum += survivor.inventory.items[(int)ItemSlot.BACKPACK_2].id;
//			backPackItemsProduct *= survivor.inventory.items[(int)ItemSlot.BACKPACK_2].id;
//		}
//		if(survivor.inventory.items[(int)ItemSlot.BACKPACK_3]){
//			backPackItemsSum += survivor.inventory.items[(int)ItemSlot.BACKPACK_3].id;
//			backPackItemsProduct *= survivor.inventory.items[(int)ItemSlot.BACKPACK_3].id;
//		}
//
//		if(inventorySlots[(int)ItemSlot.LEFT_HAND].GetItem()){
//			rearrangedHandItemsSum += inventorySlots[(int)ItemSlot.LEFT_HAND].GetItem().id;
//			rearrangedHandItemsProduct *= inventorySlots[(int)ItemSlot.LEFT_HAND].GetItem().id;
//		}
//		if(inventorySlots[(int)ItemSlot.RIGHT_HAND].GetItem()){
//			rearrangedHandItemsSum += inventorySlots[(int)ItemSlot.RIGHT_HAND].GetItem().id;
//			rearrangedHandItemsProduct *= inventorySlots[(int)ItemSlot.RIGHT_HAND].GetItem().id;
//		}
//		if(inventorySlots[(int)ItemSlot.BACKPACK_1].GetItem()){
//			rearrangedBackPackItemsSum += inventorySlots[(int)ItemSlot.BACKPACK_1].GetItem().id;
//			rearrangedBackPackItemsProduct *= inventorySlots[(int)ItemSlot.BACKPACK_1].GetItem().id;
//		}
//		if(inventorySlots[(int)ItemSlot.BACKPACK_3].GetItem()){
//			rearrangedBackPackItemsSum += inventorySlots[(int)ItemSlot.BACKPACK_3].GetItem().id;
//			rearrangedBackPackItemsProduct *= inventorySlots[(int)ItemSlot.BACKPACK_3].GetItem().id;
//		}
//		if(inventorySlots[(int)ItemSlot.BACKPACK_3].GetItem()){
//			rearrangedBackPackItemsSum += inventorySlots[(int)ItemSlot.BACKPACK_3].GetItem().id;
//			rearrangedBackPackItemsProduct *= inventorySlots[(int)ItemSlot.BACKPACK_3].GetItem().id;
//		}

		bool rearranged = false;

		if(handItemsSum != rearrangedHandItemsSum || backPackItemsSum != rearrangedBackPackItemsSum){
			rearranged = true;
		} else {
			if(handItemsProduct != rearrangedHandItemsProduct || backPackItemsProduct != rearrangedBackPackItemsProduct){
				rearranged = true;
			} else {
				rearranged = false;
			}
		}

		return rearranged;
	}

	public bool CheckForStored(){
		int storageItemsSum = 0;
		int storageItemsProduct = 1;
		int storageItemsCount = 0;
		int storedItemsSum = 0;
		int storedItemsProduct = 1;
		int storedItemsCount = 0;

		for(int i = 0; i < storageSlots.Length; i++){
			if(storageSlots[i].GetItem()){
				storageItemsSum += storageSlots[i].GetItem().id;
				storageItemsProduct *= storageSlots[i].GetItem().id;
				storageItemsCount++;
			}
		}
		for(int i = 0; i < storage.storedItems.Length; i++){
			if(storage.storedItems[i]){
				storedItemsSum += storage.storedItems[i].id;
				storedItemsProduct *= storage.storedItems[i].id;
				storedItemsCount++;
			}
		}

		bool stored = false;
		if(storedItemsCount != storageItemsCount){
			stored = true;
		} else {
			if(storedItemsSum != storageItemsSum){
				stored = true;
			} else {
				if(storedItemsProduct != storageItemsProduct){
					stored = true;
				} else {
					stored = false;
				}
			}
		}
		return stored;
	}

	public void CancelButtonClick(){
		HideStoreScreen();
	}
}
