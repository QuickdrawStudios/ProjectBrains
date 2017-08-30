//CAN YOU REARRANGE ON THE TRADE SCREEN?

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeInventory : MonoBehaviour {

	[HideInInspector]
	public Survivor survivor;
	Survivor otherSurvivor;

	public InventorySlot leftHandSlot, rightHandSlot, backPack1Slot, backPack2Slot, backPack3Slot;
	public InventorySlot otherLeftHandSlot, otherRightHandSlot, otherBackPack1Slot, otherBackPack2Slot, otherBackPack3Slot;

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
		for(int i = 0; i < 5; i++){
			InventorySlot slotToPopulate = null;
			Item itemToPopulate = null;
			switch(i){
				case 0:
					slotToPopulate = otherLeftHandSlot;
					itemToPopulate = otherSurvivor.inventory.leftHand;
					break;
				case 1:
					slotToPopulate = otherRightHandSlot;
					itemToPopulate = otherSurvivor.inventory.rightHand;
					break;
				case 2:
					slotToPopulate = otherBackPack1Slot;
					itemToPopulate = otherSurvivor.inventory.backPack1;
					break;
				case 3:
					slotToPopulate = otherBackPack2Slot;
					itemToPopulate = otherSurvivor.inventory.backPack2;
					break;
				case 4:
					slotToPopulate = otherBackPack3Slot;
					itemToPopulate = otherSurvivor.inventory.backPack3;
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
				inventoryItem.survivor = otherSurvivor;
			}
		}
	}

	void RemoveItems(){
		if(otherLeftHandSlot.transform.childCount > 0){
			if(otherLeftHandSlot.transform.GetChild(0).tag == "ItemUI"){
				Destroy(otherLeftHandSlot.transform.GetChild(0).gameObject);
				otherLeftHandSlot.inventoryItem = null;
			}
		}
		if(otherRightHandSlot.transform.childCount > 0){
			if(otherRightHandSlot.transform.GetChild(0).tag == "ItemUI"){
				Destroy(otherRightHandSlot.transform.GetChild(0).gameObject);
				otherRightHandSlot.inventoryItem = null;
			}
		}
		if(otherBackPack1Slot.transform.childCount > 0){
			if(otherBackPack1Slot.transform.GetChild(0).tag == "ItemUI"){
				Destroy(otherBackPack1Slot.transform.GetChild(0).gameObject);
				otherBackPack1Slot.inventoryItem = null;
			}
		}
		if(otherBackPack2Slot.transform.childCount > 0){
			if(otherBackPack2Slot.transform.GetChild(0).tag == "ItemUI"){
				Destroy(otherBackPack2Slot.transform.GetChild(0).gameObject);
				otherBackPack2Slot.inventoryItem = null;
			}
		}
		if(otherBackPack3Slot.transform.childCount > 0){
			if(otherBackPack3Slot.transform.GetChild(0).tag == "ItemUI"){
				Destroy(otherBackPack3Slot.transform.GetChild(0).gameObject);
				otherBackPack3Slot.inventoryItem = null;
			}
		}
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

	void TradeItems(){
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

		if(otherLeftHandSlot.GetItem()){
			otherSurvivor.inventory.PickUpLeftHand(otherLeftHandSlot.GetItem());
		} else {
			otherSurvivor.inventory.DropLeftHand();
		}
		if(otherRightHandSlot.GetItem()){
			otherSurvivor.inventory.PickUpRightHand(otherRightHandSlot.GetItem());
		} else {
			otherSurvivor.inventory.DropRightHand();
		}
		if(otherBackPack1Slot.GetItem()){
			otherSurvivor.inventory.PickUpBackPack1(otherBackPack1Slot.GetItem());
		} else {
			otherSurvivor.inventory.DropBackPack1();
		}
		if(otherBackPack2Slot.GetItem()){
			otherSurvivor.inventory.PickUpBackPack2(otherBackPack2Slot.GetItem());
		} else {
			otherSurvivor.inventory.DropBackPack2();
		}
		if(otherBackPack3Slot.GetItem()){
			otherSurvivor.inventory.PickUpBackPack3(otherBackPack3Slot.GetItem());
		} else {
			otherSurvivor.inventory.DropBackPack3();
		}
	}

	public void ConfirmButtonClick(){
		UseAction();
		HideTradeScreen();
	}

	void UseAction(){
		List<Item> inventoryItems = new List<Item>();
		List<Item> tradedItems = new List<Item>();
		inventoryItems.Add(otherSurvivor.inventory.leftHand);
		inventoryItems.Add(otherSurvivor.inventory.rightHand);
		inventoryItems.Add(otherSurvivor.inventory.backPack1);
		inventoryItems.Add(otherSurvivor.inventory.backPack2);
		inventoryItems.Add(otherSurvivor.inventory.backPack3);
		tradedItems.Add(leftHandSlot.GetItem());
		tradedItems.Add(rightHandSlot.GetItem());
		tradedItems.Add(backPack1Slot.GetItem());
		tradedItems.Add(backPack2Slot.GetItem());
		tradedItems.Add(backPack3Slot.GetItem());

		bool traded = false;
		for(int i = 0; i < inventoryItems.Count; i++){
			if(inventoryItems[i] != null){
				if(tradedItems.Contains(inventoryItems[i])){
					traded = true;
					break;
				}
			}
		}
		if(traded){
			survivor.action.UseAction();
			TradeItems();
		}
	}

	public void CancelButtonClick(){
		HideTradeScreen();
	}
}
