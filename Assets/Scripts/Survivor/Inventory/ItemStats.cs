using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStats : MonoBehaviour {

	Weapon weapon;
	ItemSlot itemSlot;

	public float showItemStatsDelay;
	float delayTimer;

	bool showingItemStats;

	public Animator leftHandItemStatsAnimator, rightHandItemStatsAnimator;
	public Text leftHandRangeText, leftHandDiceText, leftHandHitChanceText, leftHandDamageText;
	public Text rightHandRangeText, rightHandDiceText, rightHandHitChanceText, rightHandDamageText;

	// Update is called once per frame
	void Update () {
		if(showingItemStats){
			if(delayTimer < showItemStatsDelay){
				delayTimer += Time.deltaTime;
			} else {
				delayTimer = 0;
				showingItemStats = false;
				ShowItemStats();
			}
		}
	}

	public void MouseOver(Weapon weapon, ItemSlot itemSlot){
		this.weapon = weapon;
		this.itemSlot = itemSlot;
		showingItemStats = true;
	}

	public void ShowItemStats(){
		if(itemSlot == ItemSlot.LEFT_HAND){
			leftHandRangeText.text = weapon.stats.range.ToString();
			leftHandDiceText.text = weapon.stats.dice.ToString();
			leftHandHitChanceText.text = weapon.stats.hitChance.ToString();
			leftHandDamageText.text = weapon.stats.damage.ToString();
			leftHandItemStatsAnimator.SetBool("Open", true);
		} else if(itemSlot == ItemSlot.RIGHT_HAND) {
			rightHandRangeText.text = weapon.stats.range.ToString();
			rightHandDiceText.text = weapon.stats.dice.ToString();
			rightHandHitChanceText.text = weapon.stats.hitChance.ToString();
			rightHandDamageText.text = weapon.stats.damage.ToString();
			rightHandItemStatsAnimator.SetBool("Open", true);
		}
	}

	public void HideItemStats(){
		rightHandItemStatsAnimator.SetBool("Open", false);
		leftHandItemStatsAnimator.SetBool("Open", false);
		delayTimer = 0;
		showingItemStats = false;
		weapon = null;
	}
}
