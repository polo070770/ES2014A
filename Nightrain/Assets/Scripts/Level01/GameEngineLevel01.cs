﻿using UnityEngine;
using System.Collections;

public class GameEngineLevel01 : MonoBehaviour {
	
	public Texture2D[] cursor;
	private CursorMode mode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	public Transform[] prefab;
	private GameObject character;
	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursor[0], hotSpot, mode);

		string str_character = PlayerPrefs.GetString ("Character");
		string dificulty = PlayerPrefs.GetString ("Dificulty");

		if (str_character.Equals ("Gordo"))
						Instantiate (prefab [0]);
				else if (str_character.Equals ("Tia"))
						Instantiate (prefab [1]);
				else if (str_character.Equals ("Nino"))
						Instantiate (prefab [2]);

		this.character = GameObject.FindGameObjectWithTag ("Player");
		//this.character.transform.position = Vector3.zero;
		//this.character.transform.rotation = Quaternion.identity;

		print ("Se ha cargado el personaje " + str_character);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}