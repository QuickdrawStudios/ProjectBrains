using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickable {
	void MouseOver(Survivor survivor, Item item);
	void OnClick(Survivor survivor, Item item);
}
