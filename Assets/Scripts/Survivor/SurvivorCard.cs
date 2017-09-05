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
	ItemStats itemStats;

	public Button[] itemButtons = new Button[5];
	public Image characterImage;

	public Sprite emptySlotSprite;

	public Text nameText;

	public Text actionText, moveActionText, searchActionText;

	public void SetUp(Survivor survivor){
		this.survivor = survivor;
		survivor.action.survivorCard = this;
		rearrangeInventory = GetComponent<RearrangeInventory>();
		tradeInventory = GetComponent<TradeInventory>();
		storeInventory = GetComponent<StoreInventory>();
		itemStats = GetComponent<ItemStats>();
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

	public void LeftHandButtonClick(){
		survivor.inventory.LeftHandItemUse();
	}

	public void RightHandButtonClick(){
		survivor.inventory.RightHandItemUse();
	}

	public void LeftHandMouseOver(){
		if(survivor.inventory.items[(int)ItemSlot.LEFT_HAND]){
			if(survivor.inventory.items[(int)ItemSlot.LEFT_HAND].type == Item.Type.WEAPON){
				itemStats.MouseOver((Weapon)survivor.inventory.items[(int)ItemSlot.LEFT_HAND], ItemSlot.LEFT_HAND);
			}
		}
	}

	public void RightHandMouseOver(){
		if(survivor.inventory.items[(int)ItemSlot.RIGHT_HAND]){
			if(survivor.inventory.items[(int)ItemSlot.RIGHT_HAND].type == Item.Type.WEAPON){
				itemStats.MouseOver((Weapon)survivor.inventory.items[(int)ItemSlot.RIGHT_HAND], ItemSlot.RIGHT_HAND);
			}
		}
	}

	public void LeftHandMouseExit(){
		itemStats.HideItemStats();
	}

	public void RightHandMouseExit(){
		itemStats.HideItemStats();
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

	public void UpdateActionsDisplay(int actions, int moveActions, int searchActions){
		actionText.text = actions.ToString() + " Actions";
		if(moveActions > 0) {
			moveActionText.text = moveActions.ToString() + " Move Actions";
		} else {
			moveActionText.text = "";
		}
		if(searchActions > 0) {
			searchActionText.text = searchActions.ToString() + " Search Actions";
		} else {
			searchActionText.text = "";
		}

	}
}
