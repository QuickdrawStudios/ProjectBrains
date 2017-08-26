using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivors : MonoBehaviour {

	public static Survivors instance;

	public GameObject survivorPrefab;
	public GameObject survivorCardPrefab;

	public Transform survivorCardParent;

	public List<Survivor> survivors = new List<Survivor>();

	int activeSurvivorIndex = 0;

	public Spot spawnSpot;

	public int numberOfSurvivors;

	public List<Sprite> characterImages = new List<Sprite>();

	void Start () {
		instance = this;
		SpawnSurvivors();
		ActivateSurvivor(survivors[activeSurvivorIndex]);
	}

	void SpawnSurvivors(){
		for(int i = 0; i < numberOfSurvivors; i++){
			GameObject survivorClone = Instantiate(survivorPrefab);
			Survivor survivor = survivorClone.GetComponent<Survivor>();
			survivor.inventory = survivor.gameObject.GetComponent<SurvivorInventory>();
			survivor.inventory.survivor = survivor;
			survivor.action = survivor.gameObject.GetComponent<SurvivorAction>();
			survivor.animator = survivor.gameObject.GetComponent<Animator>();
			switch (survivors.Count) {
				case 0:
					survivor._name = "J o s h";
					break;
				case 1:
					survivor._name = "N e d";
					break;
				case 2:
					survivor._name = "D o u g";
					break;
				case 3:
					survivor._name = "A m y";
					break;
			}
			survivor.characterImage = characterImages[survivors.Count];
			survivors.Add(survivor);
			survivor.ChangeState(new Spawn(survivor, spawnSpot));
			SpawnSurvivorCard(survivor);
		}
	}

	void SpawnSurvivorCard(Survivor survivor){
		GameObject cardClone = Instantiate(survivorCardPrefab, survivorCardParent, false);
		survivor.card = cardClone.GetComponent<SurvivorCard>();
		cardClone.GetComponent<InventoryScreen>().survivor = survivor;
		survivor.card.survivor = survivor;
		survivor.card.nameText.text = survivor._name;
		survivor.card.characterImage.sprite = survivor.characterImage;
	}

	void ActivateSurvivor(Survivor survivor){
		StartCoroutine(_ActivateSurvivor(survivor));
	}

	IEnumerator _ActivateSurvivor(Survivor survivor){
		yield return new WaitForSeconds(1f);
		survivor.action.ResetActions();
		HUD.instance.HideSurvivorCards();
		HUD.instance.ShowSurvivorCard(survivor);
		Cam.instance.LookAt(survivor.transform);
	}

	public void NextTurn(){
		activeSurvivorIndex++;
		if(activeSurvivorIndex >= survivors.Count){
			activeSurvivorIndex = 0;
		}
		ActivateSurvivor(survivors[activeSurvivorIndex]);
	}

	public Survivor GetActiveSurvivor(){
		return survivors[activeSurvivorIndex];
	}
}
