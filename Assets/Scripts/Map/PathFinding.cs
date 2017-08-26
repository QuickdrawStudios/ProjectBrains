using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {

	public static PathFinding instance; 

	void Start(){
        instance = this;
	}

	public List<Spot> FindPath(Spot startSpot, Spot endSpot){
		List<Spot> openSet = new List<Spot>();
		HashSet<Spot> closedSet = new HashSet<Spot>();
		openSet.Add(startSpot);

		while(openSet.Count > 0){
			Spot currentSpot = openSet[0];
			for(int i = 1; i < openSet.Count; i++){
				if(openSet[i].GetFCost() < currentSpot.GetFCost() || (openSet[i].GetFCost() == currentSpot.GetFCost() && openSet[i].hCost < currentSpot.hCost)){
					currentSpot = openSet[i];
				}
			}

			openSet.Remove(currentSpot);
			closedSet.Add(currentSpot);

			if(currentSpot == endSpot){
				return RetracePath(startSpot, endSpot);
			}

			foreach(Spot neighborSpot in currentSpot.GetNeighbors()){
				if(closedSet.Contains(neighborSpot)){
					continue;
				}

				float newMovementCostToNeighbor = currentSpot.gCost + Spots.GetDistance(currentSpot, neighborSpot);
				if(newMovementCostToNeighbor < neighborSpot.gCost || !openSet.Contains(neighborSpot)){
					neighborSpot.gCost = newMovementCostToNeighbor;
					neighborSpot.hCost = Spots.GetDistance(neighborSpot, endSpot);
					neighborSpot.parentSpot = currentSpot;

					if(!openSet.Contains(neighborSpot)){
						openSet.Add(neighborSpot);
					}
				 } 
			}
		}

		return null;
	}

	List<Spot> RetracePath(Spot startSpot, Spot endSpot){
		List<Spot> path = new List<Spot>();	
		Spot currentSpot = endSpot;
		while(currentSpot != startSpot){
			path.Add(currentSpot);
			currentSpot = currentSpot.parentSpot;
		}

		path.Reverse();

		return path;
	}

	public int GetPathDistance(List<Spot> path){
		return path.Count;
	}
}
