using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivorCard : MonoBehaviour {

	[HideInInspector]
	public Survivor survivor;

	[HideInInspector]
	public RearrangeInventory rearrangeInventory;
	[HideInInspector]
	public TradeInventory tradeInventory;
	[HideInInspector]
	public StoreInventory storeInventory;

	//public Button leftHandImage, rightHandImage, backPack1Image, backPack2Image, backPack3Image;
	public Button[] itemButtons = new Button[5];
	public Image characterImage;

	public Sprite emptySlotSprite;

	public Text nameText;

	public void SetUp(Survivor survivor){
		this.survivor = survivor;
		rearrangeInventory = GetComponent<RearrangeInventory>();
		tradeInventory = GetComponent<TradeInventory>();
		storeInventory = GetComponent<StoreInventory>();
		rearrangeInventory.survivor = survivor;
		tradeInventory.survivor = survivor;
		storeInventory.survivor = survivor;
	}

	public void EndButtonClick(){
		survivor.action.EndTurn();
	}

	public void HideCard(){
		this.gameObject.SetActive(false);
	}

	public void ShowCard(){
		this.gameObject.SetActive(true);
	}

	public void EquipItem(Item item, ItemSlot slot){
		if(item){
			itemButtons[(int)slot].image.sprite = item.inventoryImage;
		} else {
			itemButtons[(int)slot].image.sprite = emptySlotSprite;
		}
	}

//	public void LeftHandEquip(Item item){
//		if(item){
//			leftHandImage.image.sprite = item.inventoryImage;
//		} else {
//			leftHandImage.image.sprite = emptySlotSprite;
//		}
//	}
//
//	public void RightHandEquip(Item item){
//		if(item){
//			rightHandImage.image.sprite = item.inventoryImage;
//		} else {
//			rightHandImage.image.sprite = emptySlotSprite;
//		}
//	}
//
//	public void BackPack1Equip(Item item){
//		if(item){
//			backPack1Image.image.sprite = item.inventoryImage;
//		} else {
//			backPack1Image.image.sprite = emptySlotSprite;
//		}
//	}
//
//	public void BackPack2Equip(Item item){
//		if(item){
//			backPack2Image.image.sprite = item.inventoryImage;
//		} else {
//			backPack2Image.image.sprite = emptySlotSprite;
//		}
//	}
//
//	public void BackPack3Equip(Item item){
//		if(item){
//			backPack3Image.image.sprite = item.inventoryImage;
//		} else {
//			backPack3Image.image.sprite = emptySlotSprite;
//		}
//	}

	public void LeftHandButtonClick(){
		survivor.inventory.LeftHandItemUse();
	}

	public void RightHandButtonClick(){
		survivor.inventory.RightHandItemUse();
	}

	public void ShowRearrangeScreen(){
		rearrangeInventory.ShowInventoryScreen();
	}

	public void ShowTradeScreen(Survivor otherSurvivor){
		tradeInventory.ShowTradeScreen(otherSurvivor);
	}

	public void ShowStoreScreen(Storage storage){
		storeInventory.ShowStoreScreen(storage);
	}
}
