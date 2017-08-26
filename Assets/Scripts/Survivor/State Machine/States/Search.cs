using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Search : IState {
	Survivor survivor;
	Spot searchSpot;

	public Search(Survivor survivor, Spot searchSpot){
		this.survivor = survivor;
		this.searchSpot = searchSpot;
	}

	public void Enter(){
		MouseControl.instance.DisableControl();
		survivor.animator.SetTrigger("Search");
	}


	public void Update(){
		AnimatorStateInfo animatorState = survivor.animator.GetCurrentAnimatorStateInfo(0);
		if(animatorState.IsName("Search") && animatorState.normalizedTime >= 0.7f){
			//SHOW INVENTORY SCREEN
			if(searchSpot.loot.Count > 0){
				survivor.inventory.PickUpItem(searchSpot.loot[0], survivor.card);
				if(searchSpot.loot[0]._object){
					searchSpot.loot[0].DestroyObject();
				}
				searchSpot.loot.RemoveAt(0);
			}
			survivor.ChangeState(new Idle(survivor));
		}
	}


	public void Exit(){
		MouseControl.instance.EnableControl();
		survivor.action.UseSearchAction();
	}
}
