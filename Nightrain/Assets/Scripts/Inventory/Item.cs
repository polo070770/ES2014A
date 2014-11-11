﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class Item {

	public int id;
	public Texture2D ItemTexture;
	public int x;				// Position X in the inventory
	public int y;				// Position Y in the iventoty
	public int width;
	public int height;

	// Method when I click a Item
	public abstract void actionPerform();

}
