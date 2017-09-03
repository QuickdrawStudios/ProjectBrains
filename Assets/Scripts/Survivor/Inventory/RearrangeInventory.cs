using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearrangeInventory : MonoBehaviour {

	[HideInInspector]
	public Survivor survivor;

	public InventorySlot[] inventorySlots = new InventorySlot[5];

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
//			InventorySlot slotToPopulate = null;
//			Item itemToPopulate = null;
//			switch(i){
//				case 0:
//					slotToPopulate = inventorySlots[ItemSlot.LEFT_HAND];
//					itemToPopulate = survivor.inventory.items[ItemSlot.LEFT_HAND];
//					break;
//				case 1:
//					slotToPopulate = inventorySlots[ItemSlot.RIGHT_HAND];
//					itemToPopulate = survivor.inventory.items[ItemSlot.RIGHT_HAND];
//					break;
//				case 2:
//					slotToPopulate = inventorySlots[ItemSlot.BACKPACK_1];
//					itemToPopulate = survivor.inventory.items[ItemSlot.BACKPACK_1];
//					break;
//				case 3:
//					slotToPopulate = inventorySlots[ItemSlot.BACKPACK_2];
//					itemToPopulate = survivor.inventory.items[ItemSlot.BACKPACK_2];
//					break;
//				case 4:
//					slotToPopulate = inventorySlots[ItemSlot.BACKPACK_3];
//					itemToPopulate = survivor.inventory.items[ItemSlot.BACKPACK_3];
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
//				inventoryItem.survivor = survivor;
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

//		if(inventorySlots[ItemSlot.LEFT_HAND].transform.childCount > 0){
//			if(inventorySlots[ItemSlot.LEFT_HAND].transform.GetChild(0).tag == "ItemUI"){
//				Destroy(inventorySlots[ItemSlot.LEFT_HAND].transform.GetChild(0).gameObject);
//				inventorySlots[ItemSlot.LEFT_HAND].inventoryItem = null;
//			}
//		}
//		if(inventorySlots[ItemSlot.RIGHT_HAND].transform.childCount > 0){
//			if(inventorySlots[ItemSlot.RIGHT_HAND].transform.GetChild(0).tag == "ItemUI"){
//				Destroy(inventorySlots[ItemSlot.RIGHT_HAND].transform.GetChild(0).gameObject);
//				inventorySlots[ItemSlot.RIGHT_HAND].inventoryItem = null;
//			}
//		}
//		if(inventorySlots[ItemSlot.BACKPACK_1].transform.childCount > 0){
//			if(inventorySlots[ItemSlot.BACKPACK_1].transform.GetChild(0).tag == "ItemUI"){
//				Destroy(inventorySlots[ItemSlot.BACKPACK_1].transform.GetChild(0).gameObject);
//				inventorySlots[ItemSlot.BACKPACK_1].inventoryItem = null;
//			}
//		}
//		if(inventorySlots[ItemSlot.BACKPACK_2].transform.childCount > 0){
//			if(inventorySlots[ItemSlot.BACKPACK_2].transform.GetChild(0).tag == "ItemUI"){
//				Destroy(inventorySlots[ItemSlot.BACKPACK_2].transform.GetChild(0).gameObject);
//				inventorySlots[ItemSlot.BACKPACK_2].inventoryItem = null;
//			}
//		}
//		if(inventorySlots[ItemSlot.BACKPACK_3].transform.childCount > 0){
//			if(inventorySlots[ItemSlot.BACKPACK_3].transform.GetChild(0).tag == "ItemUI"){
//				Destroy(inventorySlots[ItemSlot.BACKPACK_3].transform.GetChild(0).gameObject);
//				inventorySlots[ItemSlot.BACKPACK_3].inventoryItem = null;
//			}
//		}
	}

	void RearrangeItems(){
		for(int i = 0; i < inventorySlots.Length; i++){
			if(inventorySlots[i].GetItem()){
				survivor.inventory.PickUpItem(inventorySlots[i].GetItem(),(ItemSlot)i);
			} else {
				survivor.inventory.DropItem((ItemSlot)i);
			}
		}

//		if(inventorySlots[ItemSlot.LEFT_HAND].GetItem()){
//			survivor.inventory.PickUpLeftHand(inventorySlots[ItemSlot.LEFT_HAND].GetItem());
//		} else {
//			survivor.inventory.DropLeftHand();
//		}
//		if(inventorySlots[ItemSlot.RIGHT_HAND].GetItem()){
//			survivor.inventory.PickUpRightHand(inventorySlots[ItemSlot.RIGHT_HAND].GetItem());
//		} else {
//			survivor.inventory.DropRightHand();
//		}
//		if(inventorySlots[ItemSlot.BACKPACK_1].GetItem()){
//			survivor.inventory.PickUpBackPack1(inventorySlots[ItemSlot.BACKPACK_1].GetItem());
//		} else {
//			survivor.inventory.DropBackPack1();
//		}
//		if(inventorySlots[ItemSlot.BACKPACK_2].GetItem()){
//			survivor.inventory.PickUpBackPack2(inventorySlots[ItemSlot.BACKPACK_2].GetItem());
//		} else {
//			survivor.inventory.DropBackPack2();
//		}
//		if(inventorySlots[ItemSlot.BACKPACK_3].GetItem()){
//			survivor.inventory.PickUpBackPack3(inventorySlots[ItemSlot.BACKPACK_3].GetItem());
//		} else {
//			survivor.inventory.DropBackPack3();
//		}
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
//		List<Item> inventoryItems = new List<Item>();
//		List<Item> rearrangedItems = new List<Item>();
//		inventoryItems.Add(survivor.inventory.items[ItemSlot.LEFT_HAND]);
//		inventoryItems.Add(survivor.inventory.items[ItemSlot.RIGHT_HAND]);
//		inventoryItems.Add(survivor.inventory.items[ItemSlot.BACKPACK_1]);
//		inventoryItems.Add(survivor.inventory.items[ItemSlot.BACKPACK_2]);
//		inventoryItems.Add(survivor.inventory.items[ItemSlot.BACKPACK_3]);
//		rearrangedItems.Add(inventorySlots[ItemSlot.LEFT_HAND].GetItem());
//		rearrangedItems.Add(inventorySlots[ItemSlot.RIGHT_HAND].GetItem());
//		rearrangedItems.Add(inventorySlots[ItemSlot.BACKPACK_1].GetItem());
//		rearrangedItems.Add(inventorySlots[ItemSlot.BACKPACK_2].GetItem());
//		rearrangedItems.Add(inventorySlots[ItemSlot.BACKPACK_3].GetItem());
		bool rearranged = CheckForRearrange();
//		for(int i = 0; i < inventoryItems.Count; i++){
//			if(rearrangedItems[i] != null){
//				if(inventoryItems[i] != rearrangedItems[i]){
//					rearranged = true;
//					break;
//				}
//			}
//		}
		if(rearranged){
			Debug.Log("USED ACTION");
			survivor.action.UseAction();
		}
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

	public void CancelButtonClick(){
		HideInventoryScreen();
	}
}
