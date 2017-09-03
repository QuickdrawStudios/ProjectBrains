using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorClick : MonoBehaviour, IClickable {

	[HideInInspector]
	public Survivor thisSurvivor;

	void Start(){
		thisSurvivor = GetComponent<Survivor>();
	}

	public void MouseOver(Survivor survivor, Item item){
		if(item == null){
			if(thisSurvivor != survivor){
				if(survivor.currentSpot == thisSurvivor.currentSpot){
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
		} else {
			Cursor.SetCursor(item.mouseCursorImage, Vector2.zero, CursorMode.Auto);
		}
	}

	public void OnClick(Survivor survivor, Item item){
		if(item == null){
			if(thisSurvivor != survivor){
				if(survivor.currentSpot == thisSurvivor.currentSpot){
					if(survivor.action.GetRemainingActions() > 0){
						survivor.card.ShowTradeScreen(thisSurvivor);
					}
				}
			}
		} else {
			MouseControl.instance.StopUsingItem();
		}
	}
}
