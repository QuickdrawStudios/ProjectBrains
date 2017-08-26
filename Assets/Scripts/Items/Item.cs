using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour {

	public enum Type {
		WEAPON,
		COLLECTIBLE,
		POWERUP
	}

	public Type type;

	public GameObject objectPrefab;
	[HideInInspector]
	public GameObject _object;
	public Sprite inventoryImage;

	public Texture2D mouseCursorImage;
	public Texture2D mouseCursorActiveImage;

	public bool canOpenDoor;

	public virtual void UseItem(Survivor survivor){
		MouseControl.instance.UseItem(this);
	}

	public void DestroyObject(){
		Destroy(_object);
	}
}
