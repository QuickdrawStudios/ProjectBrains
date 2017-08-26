using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : IState {

	Survivor survivor;
	Spot moveSpot;
	int distance;

	public Move(Survivor survivor, Spot moveSpot, int distance){
		this.survivor = survivor;
		this.moveSpot = moveSpot;
		this.distance = distance;
	}

	public void Enter () {
		MouseControl.instance.DisableControl();
		survivor.animator.SetBool("Walking", true);
		survivor.navMeshAgent.SetDestination(moveSpot.FindStandingSpot());
	}

	public void Update(){
		if(Vector3.Distance(survivor.navMeshAgent.destination, survivor.transform.position) <= 1.5f){
			survivor.ChangeState(new Idle(survivor));
		}
	}

	public void Exit () {
		MouseControl.instance.EnableControl();
		survivor.animator.SetBool("Walking", false);
		survivor.action.UseMoveAction(distance);
		if(survivor.currentSpot != null){
			survivor.currentSpot.RemoveOccupant(survivor);
		}
		survivor.currentSpot = moveSpot;
		if(!moveSpot.occupants.Contains(survivor)){
			moveSpot.occupants.Add(survivor);
		}
	}
}
