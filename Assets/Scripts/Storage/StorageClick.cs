using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageClick : MonoBehaviour, IClickable {

	[HideInInspector]
	public Storage thisStorage;

	void Start(){
		thisStorage = GetComponent<Storage>();
	}

	public void MouseOver(Survivor survivor, Item item){
		if(item == null){
			if(survivor.currentSpot == thisStorage.currentSpot){
				if(survivor.action.GetRemainingActions() > 0){
					Cursor.SetCursor(Cursors.instance.tradeCursor,Vector2.zero,CursorMode.Auto);
				} else {
					Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
				}
			} else {
				Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
			}
		} else {
			Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
		}
	}

	public void OnClick(Survivor survivor, Item item){
		if(item == null){
			if(survivor.currentSpot == thisStorage.currentSpot){
				if(survivor.action.GetRemainingActions() > 0){
					survivor.card.ShowStoreScreen(thisStorage);
				}
			}
		} else {
			MouseControl.instance.StopUsingItem();
		}
	}
}
