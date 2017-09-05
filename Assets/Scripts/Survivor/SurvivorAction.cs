using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorAction : MonoBehaviour {

	public int numberOfActions;
	public int numberOfMoveActions;
	public int numberOfSearchActions;

	public int remainingActions;
	public int remainingMoveActions;
	public int remainingSearchActions;

	public SurvivorCard survivorCard;

	void Awake(){
		remainingActions = numberOfActions;
		remainingMoveActions = numberOfMoveActions;
		remainingSearchActions = numberOfSearchActions;
	}

	public void UseMoveAction(int distance){
		if(remainingMoveActions > 0){
			if(remainingMoveActions >= distance){
				remainingMoveActions -= distance;
			} else {
				distance -= remainingMoveActions;
				remainingMoveActions = 0;
				if(remainingActions >= distance){
					remainingActions -= distance;
				}
			}
		} else {
			if(remainingActions >= distance){
				remainingActions -= distance;
			}
		}
		CheckForEndTurn();
	}

	public void UseSearchAction(){
		if(remainingSearchActions > 0){
			remainingSearchActions--;
		} else if(remainingActions > 0){
			remainingActions--;
		}
		CheckForEndTurn();
	}

	public void UseAction(){
		if(remainingActions > 0){
			remainingActions--;
		}
		CheckForEndTurn();
	}

	public int GetRemainingMoveActions(){
		return remainingActions + remainingMoveActions;
	}

	public int GetRemainingMoveOnlyActions(){
		return remainingMoveActions;
	}

	public int GetRemainingSearchActions(){
		return remainingActions + remainingSearchActions;
	}

	public int GetRemainingSearchOnlyActions(){
		return remainingSearchActions;
	}
	public int GetRemainingActions(){
		return remainingActions;
	}

	void CheckForEndTurn(){
		survivorCard.UpdateActionsDisplay(GetRemainingActions(), GetRemainingMoveOnlyActions(), GetRemainingSearchOnlyActions());
		if(remainingActions <= 0 && remainingMoveActions <= 0 && remainingSearchActions <= 0){
			EndTurn();
		}
	}

	public void EndTurn(){
		Survivors.instance.NextTurn();
	}

	public void ResetActions(){
		remainingActions = numberOfActions;
		remainingMoveActions = numberOfMoveActions;
		remainingSearchActions = numberOfSearchActions;
		survivorCard.UpdateActionsDisplay(GetRemainingActions(), GetRemainingMoveOnlyActions(), GetRemainingSearchOnlyActions());
	}
}
