﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheLiquidFire.AspectContainer;

public class Card : Container {
	public string id;
	public string name;
	public string text;
	public int cost;
	public int orderOfPlay = int.MaxValue;
	public int ownerIndex;
	public Zones zone = Zones.Deck;

	public virtual void Load (Dictionary<string, object> data) {
		id = (string)data ["id"];
		name = (string)data ["name"];
		text = (string)data ["text"];
		cost = System.Convert.ToInt32(data["cost"]);
	}
}