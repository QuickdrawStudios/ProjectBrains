using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseControl : MonoBehaviour {

	public static MouseControl instance;

	Survivor activeSurvivor;

	//Item activeItem;
	//Door itemUseTarget;
	//bool itemUseTargetInRange;

	GameObject targetObject;
	IClickable mouseTarget;
	bool targetClickable;

	public bool controllable;
	Item activeItem;

	Texture2D mouseCursorImage;

	void Start () {
		instance = this;
		controllable = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(controllable){
			if(!EventSystem.current.IsPointerOverGameObject()){
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hitInfo;
				if (Physics.Raycast (ray, out hitInfo)){ 
					if(targetObject != hitInfo.collider.gameObject){
						targetObject = hitInfo.collider.gameObject;
						mouseTarget = targetObject.GetComponent<IClickable>();
						if(mouseTarget != null){
							targetClickable = true;
							mouseTarget.MouseOver(Survivors.instance.GetActiveSurvivor(), activeItem);
						} else {
							targetClickable = false;
							Cursor.SetCursor(mouseCursorImage, Vector2.zero, CursorMode.Auto);
						}
					}
					if(Input.GetMouseButtonUp(0)){
						if(targetClickable){
							mouseTarget.OnClick(Survivors.instance.GetActiveSurvivor(), activeItem);
							Cursor.SetCursor(mouseCursorImage, Vector2.zero, CursorMode.Auto);
							targetObject = null;
							mouseTarget = null;
							targetClickable = false;
						}
						StopUsingItem();
					}
				} else {
					//MAKE THIS ONLY RUN ONCE
					targetObject = null;
					mouseTarget = null;
					targetClickable = false;
					Cursor.SetCursor(mouseCursorImage, Vector2.zero, CursorMode.Auto);
				}
			} else {
				//MAKE THIS ONLY RUN ONCE
				targetObject = null;
				mouseTarget = null;
				targetClickable = false;
				Cursor.SetCursor(mouseCursorImage, Vector2.zero, CursorMode.Auto);
			}
		}
	}

	public void DisableControl(){
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		controllable = false;
		targetObject = null;
		mouseTarget = null;
	}

	public void EnableControl(){
		controllable = true;
	}

	public void UseItem(Item item){
		if(activeItem == item){
			StopUsingItem();
		} else {
			activeItem = item;
			mouseCursorImage = item.mouseCursorImage;
			Cursor.SetCursor(mouseCursorImage, Vector2.zero, CursorMode.Auto);
		}
	}

	public void StopUsingItem(){
		activeItem = null;
		mouseCursorImage = null;
		Cursor.SetCursor(mouseCursorImage, Vector2.zero, CursorMode.Auto);
	}
}
