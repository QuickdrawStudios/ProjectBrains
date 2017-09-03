using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour {

	public Sprite storageImage;

	public Spot currentSpot;

	public Item[] storedItems = new Item[5];

	public void StoreItem(int slot, Item item){
		storedItems[slot] = item;
	}

	public void UnStoreItem(int slot){
		storedItems[slot] = null;
	}
}
