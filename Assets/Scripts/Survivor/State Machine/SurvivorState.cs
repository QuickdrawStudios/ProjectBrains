using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorState {

	IState currentState;

	public void ChangeState(IState newState){
		if(currentState != null){
			currentState.Exit();
		}
		currentState = newState;
		currentState.Enter();
	}

	public void StateUpdate(){
		if(currentState != null){
			currentState.Update();
		}
	}
}
