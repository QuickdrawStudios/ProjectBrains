using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorInventory : MonoBehaviour {

	[HideInInspector]
	public Survivor survivor;
	//[HideInInspector]
	//public Item leftHand, rightHand, backPack1, backPack2, backPack3;
	public Item[] items = new Item[5];

	public void PickUpItem(Item item, SurvivorCard survivorCard){
		if(item.type == Item.Type.WEAPON){
			if(items[(int)ItemSlot.LEFT_HAND] == null){
				items[(int)ItemSlot.LEFT_HAND] = item;
				survivorCard.EquipItem(item, ItemSlot.LEFT_HAND);
			} else if(items[(int)ItemSlot.RIGHT_HAND] == null){
				items[(int)ItemSlot.RIGHT_HAND] = item;
				survivorCard.EquipItem(item, ItemSlot.RIGHT_HAND);
			} else if(items[(int)ItemSlot.BACKPACK_1] == null){
				items[(int)ItemSlot.BACKPACK_1] = item;
				survivorCard.EquipItem(item, ItemSlot.BACKPACK_1);
			} else if(items[(int)ItemSlot.BACKPACK_2] == null){
				items[(int)ItemSlot.BACKPACK_2] = item;
				survivorCard.EquipItem(item, ItemSlot.BACKPACK_2);
			} else if(items[(int)ItemSlot.BACKPACK_3] == null){
				items[(int)ItemSlot.BACKPACK_3] = item;
				survivorCard.EquipItem(item, ItemSlot.BACKPACK_3);
			}
		} else {
			if(items[(int)ItemSlot.BACKPACK_1] == null){
				items[(int)ItemSlot.BACKPACK_1] = item;
				survivorCard.EquipItem(item, ItemSlot.BACKPACK_1);
			} else if(items[(int)ItemSlot.BACKPACK_2] == null){
				items[(int)ItemSlot.BACKPACK_2] = item;
				survivorCard.EquipItem(item, ItemSlot.BACKPACK_2);
			} else if(items[(int)ItemSlot.BACKPACK_3] == null){
				items[(int)ItemSlot.BACKPACK_3] = item;
				survivorCard.EquipItem(item, ItemSlot.BACKPACK_3);
			} else if(items[(int)ItemSlot.LEFT_HAND] == null){
				items[(int)ItemSlot.LEFT_HAND] = item;
				survivorCard.EquipItem(item, ItemSlot.LEFT_HAND);
			} else if(items[(int)ItemSlot.RIGHT_HAND] == null){
				items[(int)ItemSlot.RIGHT_HAND] = item;
				survivorCard.EquipItem(item, ItemSlot.RIGHT_HAND);
			}
		}
	}

	public void LeftHandItemUse(){
		if(items[(int)ItemSlot.LEFT_HAND] != null){
			items[(int)ItemSlot.LEFT_HAND].UseItem(survivor);
		}
	}

	public void RightHandItemUse(){
		if(items[(int)ItemSlot.RIGHT_HAND] != null){
			items[(int)ItemSlot.RIGHT_HAND].UseItem(survivor);
		}
	}

	public Item ChooseDoorOpener(){
		if(items[(int)ItemSlot.LEFT_HAND] != null){
			if(items[(int)ItemSlot.LEFT_HAND].canOpenDoor){
				return items[(int)ItemSlot.LEFT_HAND];
			} else {
				if(items[(int)ItemSlot.RIGHT_HAND] != null){
					if(items[(int)ItemSlot.RIGHT_HAND].canOpenDoor){
						return items[(int)ItemSlot.RIGHT_HAND];
					} else {
						return null;
					}
				} else {
					return null;
				}
			}
		} else if(items[(int)ItemSlot.RIGHT_HAND] != null){
			if(items[(int)ItemSlot.RIGHT_HAND].canOpenDoor){
				return items[(int)ItemSlot.RIGHT_HAND];
			} else {
				return null;
			}
		} else {
			return null;
		}
	}

	public void PickUpItem(Item item, ItemSlot slot){
		items[(int)slot] = item;
		survivor.card.EquipItem(items[(int)slot], slot);
	}

	public void DropItem(ItemSlot slot){
		items[(int)slot] = null;
		survivor.card.EquipItem(items[(int)slot], slot);
	}

//	public void PickUpLeftHand(Item item){
//		items[ItemSlot.LEFT_HAND] = item;
//		survivor.card.LeftHandEquip(items[ItemSlot.LEFT_HAND]);
//	}
//
//	public void DropLeftHand(){
//		items[ItemSlot.LEFT_HAND] = null;
//		survivor.card.LeftHandEquip(items[ItemSlot.LEFT_HAND]);
//	}
//
//	public void PickUpRightHand(Item item){
//		items[ItemSlot.RIGHT_HAND] = item;
//		survivor.card.RightHandEquip(items[ItemSlot.RIGHT_HAND]);
//	}
//
//	public void DropRightHand(){
//		items[ItemSlot.RIGHT_HAND] = null;
//		survivor.card.RightHandEquip(items[ItemSlot.RIGHT_HAND]);
//	}
//
//	public void PickUpBackPack1(Item item){
//		items[ItemSlot.BACKPACK_1] = item;
//		survivor.card.BackPack1Equip(items[ItemSlot.BACKPACK_1]);
//	}
//
//	public void DropBackPack1(){
//		items[ItemSlot.BACKPACK_1] = null;
//		survivor.card.BackPack1Equip(items[ItemSlot.BACKPACK_1]);
//	}
//
//	public void PickUpBackPack2(Item item){
//		items[ItemSlot.BACKPACK_2] = item;
//		survivor.card.BackPack2Equip(items[ItemSlot.BACKPACK_2]);
//	}
//
//	public void DropBackPack2(){
//		items[ItemSlot.BACKPACK_2] = null;
//		survivor.card.BackPack2Equip(items[ItemSlot.BACKPACK_2]);
//	}
//
//	public void PickUpBackPack3(Item item){
//		items[ItemSlot.BACKPACK_3] = item;
//		survivor.card.BackPack3Equip(items[ItemSlot.BACKPACK_3]);
//	}
//
//	public void DropBackPack3(){
//		items[ItemSlot.BACKPACK_3] = null;
//		survivor.card.BackPack3Equip(items[ItemSlot.BACKPACK_3]);
//	}
}
