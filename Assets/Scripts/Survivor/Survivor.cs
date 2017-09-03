using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Survivor : MonoBehaviour {

	[HideInInspector]
	public SurvivorInventory inventory;
	[HideInInspector]
	public SurvivorCard card;
	[HideInInspector]
	public SurvivorAction action;
	[HideInInspector]
	public NavMeshAgent navMeshAgent;
	[HideInInspector]
	public Animator animator;

	SurvivorState stateMachine = new SurvivorState();

	public string _name;
	public Sprite characterImage;

	//[HideInInspector]
	public Spot currentSpot;

	public void SetUp(){
		navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.updatePosition = true;
		inventory = GetComponent<SurvivorInventory>();
		inventory.survivor = this;
		action = GetComponent<SurvivorAction>();
		animator = GetComponent<Animator>();
	}

	void Update(){
		stateMachine.StateUpdate();
	}

	public void ChangeState(IState state){
		stateMachine.ChangeState(state);
	}
}
