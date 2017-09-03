using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public static HUD instance;

	public GameObject dialogBox;
	public Text dialogBoxText;

	void Awake(){
		instance = this;
	}

	public void HideSurvivorCards(){
		foreach(Survivor survivor in Survivors.instance.survivors){
			survivor.card.HideCard();
		}
	}

	public void ShowSurvivorCard(Survivor survivor){
		survivor.card.ShowCard();
	}

	public void ShowDialogBox(string dialogText){
		dialogBoxText.text = dialogText;
		dialogBox.SetActive(true);
	}

	public void HideDialogBox(){
		dialogBoxText.text = "";
		dialogBox.SetActive(false);
	}
}
