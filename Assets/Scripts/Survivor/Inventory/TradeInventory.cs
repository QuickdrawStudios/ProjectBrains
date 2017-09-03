//CAN YOU REARRANGE ON THE TRADE SCREEN?

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeInventory : MonoBehaviour {

	[HideInInspector]
	public Survivor survivor;
	Survivor otherSurvivor;

	public InventorySlot[] inventorySlots = new InventorySlot[5];// leftHandSlot, rightHandSlot, backPack1Slot, backPack2Slot, backPack3Slot;
	public InventorySlot[] otherInventorySlots = new InventorySlot[5];//, otherRightHandSlot, otherBackPack1Slot, otherBackPack2Slot, otherBackPack3Slot;

	public Image characterImage, otherCharacterImage;

	public GameObject tradeScreen;
	public GameObject inventoryItemUIPrefab;

	public void ShowTradeScreen(Survivor otherSurvivor){
		MouseControl.instance.controllable = false;
		this.otherSurvivor = otherSurvivor;
		SetCharacterImages();
		PopulateItems();
		tradeScreen.SetActive(true);
	}

	void HideTradeScreen(){
		MouseControl.instance.controllable = true;
		RemoveItems();
		otherSurvivor = null;
		tradeScreen.SetActive(false);
	}

	void SetCharacterImages(){
		characterImage.sprite = survivor.characterImage;
		otherCharacterImage.sprite = otherSurvivor.characterImage;
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

		for(int i = 0; i < otherInventorySlots.Length; i++){
			if(otherSurvivor.inventory.items[i]){
				GameObject _item = (GameObject)Instantiate(inventoryItemUIPrefab, otherInventorySlots[i].transform, false);
				_item.transform.SetAsFirstSibling();
				InventoryItem inventoryItem = _item.GetComponent<InventoryItem>();
				otherInventorySlots[i].inventoryItem = inventoryItem;
				inventoryItem.inventorySlot = otherInventorySlots[i];
				inventoryItem.item = otherSurvivor.inventory.items[i];
				inventoryItem.itemImage.sprite = otherSurvivor.inventory.items[i].inventoryImage;
			}
		}

//
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
//		for(int i = 0; i < 5; i++){
//			InventorySlot slotToPopulate = null;
//			Item itemToPopulate = null;
//			switch(i){
//				case 0:
//					slotToPopulate = otherLeftHandSlot;
//					itemToPopulate = otherSurvivor.inventory.leftHand;
//					break;
//				case 1:
//					slotToPopulate = otherRightHandSlot;
//					itemToPopulate = otherSurvivor.inventory.rightHand;
//					break;
//				case 2:
//					slotToPopulate = otherBackPack1Slot;
//					itemToPopulate = otherSurvivor.inventory.backPack1;
//					break;
//				case 3:
//					slotToPopulate = otherBackPack2Slot;
//					itemToPopulate = otherSurvivor.inventory.backPack2;
//					break;
//				case 4:
//					slotToPopulate = otherBackPack3Slot;
//					itemToPopulate = otherSurvivor.inventory.backPack3;
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
//				//inventoryItem.survivor = otherSurvivor;
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
		for(int i = 0; i < otherInventorySlots.Length; i++){
			if(otherInventorySlots[i].transform.childCount > 0){
				if(otherInventorySlots[i].transform.GetChild(0).tag == "ItemUI"){
					Destroy(otherInventorySlots[i].transform.GetChild(0).gameObject);
					otherInventorySlots[i].inventoryItem = null;
				}
			}
		}

//		if(otherLeftHandSlot.transform.childCount > 0){
//			if(otherLeftHandSlot.transform.GetChild(0).tag == "ItemUI"){
//				Destroy(otherLeftHandSlot.transform.GetChild(0).gameObject);
//				otherLeftHandSlot.inventoryItem = null;
//			}
//		}
//		if(otherRightHandSlot.transform.childCount > 0){
//			if(otherRightHandSlot.transform.GetChild(0).tag == "ItemUI"){
//				Destroy(otherRightHandSlot.transform.GetChild(0).gameObject);
//				otherRightHandSlot.inventoryItem = null;
//			}
//		}
//		if(otherBackPack1Slot.transform.childCount > 0){
//			if(otherBackPack1Slot.transform.GetChild(0).tag == "ItemUI"){
//				Destroy(otherBackPack1Slot.transform.GetChild(0).gameObject);
//				otherBackPack1Slot.inventoryItem = null;
//			}
//		}
//		if(otherBackPack2Slot.transform.childCount > 0){
//			if(otherBackPack2Slot.transform.GetChild(0).tag == "ItemUI"){
//				Destroy(otherBackPack2Slot.transform.GetChild(0).gameObject);
//				otherBackPack2Slot.inventoryItem = null;
//			}
//		}
//		if(otherBackPack3Slot.transform.childCount > 0){
//			if(otherBackPack3Slot.transform.GetChild(0).tag == "ItemUI"){
//				Destroy(otherBackPack3Slot.transform.GetChild(0).gameObject);
//				otherBackPack3Slot.inventoryItem = null;
//			}
//		}
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

	void TradeItems(){
		for(int i = 0; i < otherInventorySlots.Length; i++){
			if(otherInventorySlots[i].GetItem()){
				otherSurvivor.inventory.PickUpItem(otherInventorySlots[i].GetItem(), (ItemSlot)i);
			} else {
				otherSurvivor.inventory.DropItem((ItemSlot)i);
			}
		}

		for(int i = 0; i < inventorySlots.Length; i++){
			if(inventorySlots[i].GetItem()){
				survivor.inventory.PickUpItem(inventorySlots[i].GetItem(),(ItemSlot)i);
			} else {
				survivor.inventory.DropItem((ItemSlot)i);
			}
		}
//
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
//
//		if(otherLeftHandSlot.GetItem()){
//			otherSurvivor.inventory.PickUpLeftHand(otherLeftHandSlot.GetItem());
//		} else {
//			otherSurvivor.inventory.DropLeftHand();
//		}
//		if(otherRightHandSlot.GetItem()){
//			otherSurvivor.inventory.PickUpRightHand(otherRightHandSlot.GetItem());
//		} else {
//			otherSurvivor.inventory.DropRightHand();
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
		TradeItems();
		HideTradeScreen();
	}

	void UseAction(){
		bool rearranged = CheckForRearrange();
		bool otherRearranged = CheckForOtherSurvivorRearrange();
		bool traded = CheckForTraded();
		//StoreItems();
		if(traded || rearranged || otherRearranged){
			Debug.Log("USED ACTION");
			survivor.action.UseAction();
		} 
//		List<Item> inventoryItems = new List<Item>();
//		List<Item> tradedItems = new List<Item>();
//		inventoryItems.Add(otherSurvivor.inventory.leftHand);
//		inventoryItems.Add(otherSurvivor.inventory.rightHand);
//		inventoryItems.Add(otherSurvivor.inventory.backPack1);
//		inventoryItems.Add(otherSurvivor.inventory.backPack2);
//		inventoryItems.Add(otherSurvivor.inventory.backPack3);
//		tradedItems.Add(leftHandSlot.GetItem());
//		tradedItems.Add(rightHandSlot.GetItem());
//		tradedItems.Add(backPack1Slot.GetItem());
//		tradedItems.Add(backPack2Slot.GetItem());
//		tradedItems.Add(backPack3Slot.GetItem());
//
//		bool traded = false;
//		for(int i = 0; i < inventoryItems.Count; i++){
//		//////////////////BAD LOGIC
//			if(inventoryItems[i] != null){
//				if(tradedItems.Contains(inventoryItems[i])){
//					traded = true;
//					break;
//				}
//			}
//		}
//		if(traded){
//			survivor.action.UseAction();
//			TradeItems();
//		}
	}

	bool CheckForRearrange(){
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

	bool CheckForOtherSurvivorRearrange(){
		int handItemsSum = 0;
		int handItemsProduct = 1;
		int rearrangedHandItemsSum = 0;
		int rearrangedHandItemsProduct = 1;
		int backPackItemsSum = 0;
		int backPackItemsProduct = 1;
		int rearrangedBackPackItemsSum = 0;
		int rearrangedBackPackItemsProduct = 1;

		for(int i = 0; i < 2; i++){
			if(otherSurvivor.inventory.items[i]){
				handItemsSum += otherSurvivor.inventory.items[i].id;
				handItemsProduct *= otherSurvivor.inventory.items[i].id;
			}
			if(otherInventorySlots[i].GetItem()){
				rearrangedHandItemsSum += otherInventorySlots[i].GetItem().id;
				rearrangedHandItemsProduct *= otherInventorySlots[i].GetItem().id;
			}
		}

		for(int i = 2; i < 5; i++){
			if(otherSurvivor.inventory.items[i]){
				backPackItemsSum += otherSurvivor.inventory.items[i].id;
				backPackItemsProduct *= otherSurvivor.inventory.items[i].id;
			}
			if(otherInventorySlots[i].GetItem()){
				rearrangedBackPackItemsSum += otherInventorySlots[i].GetItem().id;
				rearrangedBackPackItemsProduct *= otherInventorySlots[i].GetItem().id;
			}
		}

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

	public bool CheckForTraded(){
		int inventoryItemsCount = 0;
		int inventoryItemsSum = 0;
		int inventoryItemsProduct = 1;
		int tradedItemsCount = 0;
		int tradedItemsSum = 0;
		int tradedItemsProduct = 1;
		for(int i = 0; i < inventorySlots.Length; i++){
			if(inventorySlots[i].GetItem()){
				tradedItemsSum += inventorySlots[i].GetItem().id;
				tradedItemsProduct *= inventorySlots[i].GetItem().id;
				tradedItemsCount++;
			}
		}
		for(int i = 0; i < survivor.inventory.items.Length; i++){
			if(survivor.inventory.items[i]){
				inventoryItemsSum += survivor.inventory.items[i].id;
				inventoryItemsProduct *= survivor.inventory.items[i].id;
				inventoryItemsCount++;
			}
		}

		bool traded = false;
		if(tradedItemsCount != inventoryItemsCount){
			traded = true;
		} else {
			if(tradedItemsSum != inventoryItemsSum){
				traded = true;
			} else {
				if(tradedItemsProduct != inventoryItemsProduct){
					traded = true;
				} else {
					traded = false;
				}
			}
		}
		return traded;
	}

	public void CancelButtonClick(){
		HideTradeScreen();
	}
}
