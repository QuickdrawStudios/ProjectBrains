using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursors : MonoBehaviour {

	public static Cursors instance;

	public Texture2D moveCursor;
	public Texture2D searchCursor;

	// Use this for initialization
	void Start () {
		instance = this;
	}
}
