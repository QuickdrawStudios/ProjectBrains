using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToDoor : IState {

	Survivor survivor;
	Door door;
	Spot moveSpot;
	int distance;

	public MoveToDoor(Survivor survivor, Door door, Spot moveSpot, int distance){
		MouseControl.instance.DisableControl();
		this.survivor = survivor;
		this.door = door;
		this.moveSpot = moveSpot;
		this.distance = distance;
	}

	public void Enter () {
		survivor.animator.SetBool("Walking", true);
		survivor.navMeshAgent.SetDestination(door.FindOpenSpot(moveSpot));
	}

	public void Update () {
		if(Vector3.Distance(survivor.navMeshAgent.destination, survivor.transform.position) <= 1.5f){
			survivor.ChangeState(new OpenDoor(survivor, door, moveSpot, distance));
		}
	}

	public void Exit () {
		survivor.animator.SetBool("Walking", false);
	}
}
