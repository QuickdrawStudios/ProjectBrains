using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : IState {

	Survivor survivor;
	Door door;
	Spot moveSpot;
	int distance;

	public OpenDoor(Survivor survivor, Door door, Spot moveSpot, int distance){
		this.survivor = survivor;
		this.door = door;
		this.moveSpot = moveSpot;
		this.distance = distance;
	}

	public void Enter(){
		survivor.animator.SetTrigger("OpenDoor");
	}

	public void Update(){
		AnimatorStateInfo animatorState = survivor.animator.GetCurrentAnimatorStateInfo(0);
		AnimatorStateInfo doorAnimatorState = door.animator.GetCurrentAnimatorStateInfo(0);
		if(animatorState.IsName("OpenDoor") && animatorState.normalizedTime >= 0.7f){
			if(!door.doorOpen){
				door.OpenDoor();
			}
		}
		if(doorAnimatorState.IsName("DoorOpening") && doorAnimatorState.normalizedTime >= 0.95f){
			survivor.ChangeState(new Move(survivor, moveSpot, distance));
		}
	}

	public void Exit(){
		MouseControl.instance.EnableControl();
		survivor.action.UseAction();
	}
}
