using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour, IClickable {

	[HideInInspector]
	public float gCost, hCost;
	[HideInInspector]
	public Spot parentSpot;

	public List<Spot> neighbors = new List<Spot>();

	public List<Survivor> occupants = new List<Survivor>();

	public bool searchable;
	public List<Item> loot = new List<Item>();

	void Start(){
		GetComponent<Renderer>().material.color = Color.clear;
	}

	public void MouseOver(Survivor survivor, Item item){
		if(item == null){
			int moveDistance = CheckMoveDistance(survivor);
			if(moveDistance > 0){
				if(moveDistance <= survivor.action.GetRemainingMoveActions()){
					Cursor.SetCursor(Cursors.instance.moveCursor,Vector2.zero,CursorMode.Auto);
				} else {
					Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
				}
			} else {
				if(searchable){
					if(survivor.action.GetRemainingSearchActions() > 0){
						Cursor.SetCursor(Cursors.instance.searchCursor,Vector2.zero,CursorMode.Auto);
					} else {
						Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
					}
				}
			}
		} else {
			Cursor.SetCursor(item.mouseCursorImage, Vector2.zero, CursorMode.Auto);
		}
	}

	public void OnClick(Survivor survivor, Item item){
		if(item == null){
			int moveDistance = CheckMoveDistance(survivor);
			if(moveDistance > 0){
				if(moveDistance <= survivor.action.GetRemainingMoveActions()){
					survivor.ChangeState(new Move(survivor, this, moveDistance));
				}
			} else {
				if(searchable){
					if(survivor.action.GetRemainingSearchActions() > 0){
						survivor.ChangeState(new Search(survivor, this));
					}
				}
			}
		} else {
			MouseControl.instance.StopUsingItem();
		}
	}

	int CheckMoveDistance(Survivor survivor){
		List<Spot> path = PathFinding.instance.FindPath(survivor.currentSpot, this);
		if(path != null){
			return PathFinding.instance.GetPathDistance(path);
		}
		return int.MaxValue;
	}

	public List<Spot> GetNeighbors(){
		return neighbors;
	}

	public float GetFCost() {
		float gCostIncrement = 0f;
		return gCost + hCost + gCostIncrement;
	}

	public void AddNeighbor(Spot spot){
		if(!neighbors.Contains(spot)){
			neighbors.Add(spot);
		}
	}

	public void AddOccupant(Survivor survivor){
		if(!occupants.Contains(survivor)){
			occupants.Add(survivor);
		}
	}

	public void RemoveOccupant(Survivor survivor){
		if(occupants.Contains(survivor)){
			occupants.Remove(survivor);
		}
	}
	/*
	public void PlaceSurvivor(Survivor survivor){
		survivor.transform.position = FindStandingSpot();
	}
	*/
	public Vector3 FindStandingSpot(){
		Vector2 randomPosition = Random.insideUnitCircle * (Mathf.Min(transform.localScale.x * 0.8f, transform.localScale.z * 0.8f)/2f);
		Vector3 newPosition = new Vector3(randomPosition.x,1.3f,randomPosition.y);
		return transform.position + newPosition;
	}

	void OnDrawGizmosSelected(){
		Vector3 thisSpot = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
		Gizmos.color = new Color(1f,1f,0f,1f);
		Gizmos.DrawSphere(thisSpot,1f);

		Gizmos.color = new Color(1f,1f,1f,1f);
		foreach(Spot neighbor in neighbors){
			Vector3 thatSpot = new Vector3(neighbor.transform.position.x, neighbor.transform.position.y + 2f, neighbor.transform.position.z);
			Gizmos.DrawSphere(thatSpot,1f);
			Gizmos.DrawLine(thisSpot, thatSpot);
		}
	}
}
