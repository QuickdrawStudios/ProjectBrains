using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivorCard : MonoBehaviour {

	[HideInInspector]
	public Survivor survivor;

	public Button leftHandImage, rightHandImage, backPack1Image, backPack2Image, backPack3Image;
	public Image characterImage;

	public Sprite emptySlotSprite;

	public Text nameText;

	public void EndButtonClick(){
		survivor.action.EndTurn();
	}

	public void HideCard(){
		this.gameObject.SetActive(false);
	}

	public void ShowCard(){
		this.gameObject.SetActive(true);
	}

	public void LeftHandEquip(Item item){
		if(item){
			leftHandImage.image.sprite = item.inventoryImage;
		} else {
			leftHandImage.image.sprite = emptySlotSprite;
		}
	}

	public void RightHandEquip(Item item){
		if(item){
			rightHandImage.image.sprite = item.inventoryImage;
		} else {
			rightHandImage.image.sprite = emptySlotSprite;
		}
	}

	public void BackPack1Equip(Item item){
		if(item){
			backPack1Image.image.sprite = item.inventoryImage;
		} else {
			backPack1Image.image.sprite = emptySlotSprite;
		}
	}

	public void BackPack2Equip(Item item){
		if(item){
			backPack2Image.image.sprite = item.inventoryImage;
		} else {
			backPack2Image.image.sprite = emptySlotSprite;
		}
	}

	public void BackPack3Equip(Item item){
		if(item){
			backPack3Image.image.sprite = item.inventoryImage;
		} else {
			backPack3Image.image.sprite = emptySlotSprite;
		}
	}

	public void LeftHandButtonClick(){
		survivor.inventory.LeftHandItemUse();
	}

	public void RightHandButtonClick(){
		survivor.inventory.RightHandItemUse();
	}
}
