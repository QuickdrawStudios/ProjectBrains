using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorInventory : MonoBehaviour {

	[HideInInspector]
	public Survivor survivor;
	//[HideInInspector]
	public Item leftHand, rightHand, backPack1, backPack2, backPack3;

	public void PickUpItem(Item item, SurvivorCard survivorCard){
		if(item.type == Item.Type.WEAPON){
			if(leftHand == null){
				leftHand = item;
				survivorCard.LeftHandEquip(item);
			} else if(rightHand == null){
				rightHand = item;
				survivorCard.RightHandEquip(item);
			} else if(backPack1 == null){
				backPack1 = item;
				survivorCard.BackPack1Equip(item);
			} else if(backPack2 == null){
				backPack2 = item;
				survivorCard.BackPack2Equip(item);
			} else if(backPack3 == null){
				backPack3 = item;
				survivorCard.BackPack3Equip(item);
			}
		} else {
			if(backPack1 == null){
				backPack1 = item;
				survivorCard.BackPack1Equip(item);
			} else if(backPack2 == null){
				backPack2 = item;
				survivorCard.BackPack2Equip(item);
			} else if(backPack3 == null){
				backPack3 = item;
				survivorCard.BackPack3Equip(item);
			} else if(leftHand == null){
				leftHand = item;
				survivorCard.LeftHandEquip(item);
			} else if(rightHand == null){
				rightHand = item;
				survivorCard.RightHandEquip(item);
			}
		}
	}

	public void LeftHandItemUse(){
		if(leftHand != null){
			leftHand.UseItem(survivor);
		}
	}

	public void RightHandItemUse(){
		if(rightHand != null){
			rightHand.UseItem(survivor);
		}
	}

	public Item ChooseDoorOpener(){
		if(leftHand != null){
			if(leftHand.canOpenDoor){
				return leftHand;
			} else {
				if(rightHand != null){
					if(rightHand.canOpenDoor){
						return rightHand;
					} else {
						return null;
					}
				} else {
					return null;
				}
			}
		} else if(rightHand != null){
			if(rightHand.canOpenDoor){
				return rightHand;
			} else {
				return null;
			}
		} else {
			return null;
		}
	}

	public void PickUpLeftHand(Item item){
		leftHand = item;
		survivor.card.LeftHandEquip(leftHand);
	}

	public void DropLeftHand(){
		leftHand = null;
		survivor.card.LeftHandEquip(leftHand);
	}

	public void PickUpRightHand(Item item){
		rightHand = item;
		survivor.card.RightHandEquip(rightHand);
	}

	public void DropRightHand(){
		rightHand = null;
		survivor.card.RightHandEquip(rightHand);
	}

	public void PickUpBackPack1(Item item){
		backPack1 = item;
		survivor.card.BackPack1Equip(backPack1);
	}

	public void DropBackPack1(){
		backPack1 = null;
		survivor.card.BackPack1Equip(backPack1);
	}

	public void PickUpBackPack2(Item item){
		backPack2 = item;
		survivor.card.BackPack2Equip(backPack2);
	}

	public void DropBackPack2(){
		backPack2 = null;
		survivor.card.BackPack2Equip(backPack2);
	}

	public void PickUpBackPack3(Item item){
		backPack3 = item;
		survivor.card.BackPack3Equip(backPack3);
	}

	public void DropBackPack3(){
		backPack3 = null;
		survivor.card.BackPack3Equip(backPack3);
	}
}
