﻿using UnityEngine;
using System.Collections;

public class LoadData : MonoBehaviour {

	public float loadTimePlayed(){
		return PlayerPrefs.GetFloat("Time");
	}

	public string loadTimeFormat(){
		return PlayerPrefs.GetString("TimeFormat");
	}

	public int loadCutScene(){
		return PlayerPrefs.GetInt("Cutscene");
	}

	public int loadFrames(){
		return PlayerPrefs.GetInt("Frames");
	}

	public string loadPath(){
		return PlayerPrefs.GetString("Path");
	}

	public int loadLevel(){
		return PlayerPrefs.GetInt("Level");
	}

	public string loadLevelName(){
		return PlayerPrefs.GetString("LevelName");
	}

	public string loadLoading(){
		return PlayerPrefs.GetString("Loading");
	}

	public string loadPlayer(){
		return PlayerPrefs.GetString ("Player");
	}

	public string loadDifficulty(){
		return PlayerPrefs.GetString("Difficult");
	}

	public int loadLVL(){
		return PlayerPrefs.GetInt("LVL");
	}

	public int loadVIT(){
		return PlayerPrefs.GetInt("VIT");
	}

	public int loadPM(){
		return PlayerPrefs.GetInt("PM");
	}

	public int loadSTR(){
		return PlayerPrefs.GetInt("STR");
	}

	public int loadDEF(){
		return PlayerPrefs.GetInt("DEF");
	}

	public int loadSPD(){
		return PlayerPrefs.GetInt("SPD");
	}

	public int loadEXP(){
		return PlayerPrefs.GetInt("EXP");
	}

	public int loadNumItemsInventory(){
		return PlayerPrefs.GetInt ("NumItemsInventory");
	}

	public void loadInventoryItems(){

	}

	public Item[] loadEquipItem(){

		InventoryScript inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<InventoryScript> ();

		Item[] equip = new Item[5];
		string[] item = null;

		string weapon_item = PlayerPrefs.GetString ("Equip_weapon");
		string shield_item = PlayerPrefs.GetString ("Equip_shield");
		string helmet_item = PlayerPrefs.GetString ("Equip_helmet");
		string armor_item = PlayerPrefs.GetString ("Equip_armor");
		string boots_item = PlayerPrefs.GetString ("Equip_boots");

		if (weapon_item != "") {
			item = weapon_item.Split(new char[] {','});

			equip[0] = (Weapon)GetItem.setWeapon(int.Parse(item[0]), item[1], item[2],
			                             int.Parse(item[3]), int.Parse(item[4]), int.Parse(item[5]),
			                             int.Parse(item[6]), int.Parse(item[7]), item[10],
			                             int.Parse(item[13]), int.Parse(item[14]));

			print ("Weapon\nId: " + int.Parse(item[0]) +
			       "\nName: " + item[1] +
			       "\nType: " + item[2] +
			       "\nVIT: " + item[3] +
			       "\nPM: " + item[4] +
			       "\nFRZ: " + item[5] +
			       "\nDEF: " + item[6] +
			       "\nSPD: " + item[7] +
			       "\nHeal: " + item[8] +
			       "\nMagic: " + item[9] +
			       "\nIcon Name: " + item[10] +
			       "\nslot_x: " + item[11] +
			       "\nslot_y: " + item[12]);

			ItemsInventory.addWeapon (int.Parse(item[0]), equip[0]);
			//inventory.addItem (ItemsInventory.getWeapon (int.Parse(item[0])));
			//inventory.removeItem(equip[0]);
			EquipWeapons.setWeapon((Weapon)equip[0]);

		}else equip[0] = null;

		if (shield_item != "") {
			item = shield_item.Split(new char[] {','});
			equip[1] = (Shield)GetItem.setShield(int.Parse(item[0]), item[1], item[2],
			                             int.Parse(item[3]), int.Parse(item[4]), int.Parse(item[5]),
			                             int.Parse(item[6]), int.Parse(item[7]), item[10],
			                             int.Parse(item[13]), int.Parse(item[14]));

			print ("Shield\nId: " + int.Parse(item[0]) +
			       "\nName: " + item[1] +
			       "\nType: " + item[2] +
			       "\nVIT: " + item[3] +
			       "\nPM: " + item[4] +
			       "\nFRZ: " + item[5] +
			       "\nDEF: " + item[6] +
			       "\nSPD: " + item[7] +
			       "\nHeal: " + item[8] +
			       "\nMagic: " + item[9] +
			       "\nIcon Name: " + item[10] +
			       "\nslot_x: " + item[11] +
			       "\nslot_y: " + item[12]);

			ItemsInventory.addShield (int.Parse(item[0]), equip[1]);
			//inventory.addItem (ItemsInventory.getShield (int.Parse(item[0])));
			//inventory.removeItem(equip[1]);
			EquipWeapons.setShield((Shield)equip[1]);
			
		}else equip[1] = null;

		if (helmet_item != "") {
			item = helmet_item.Split(new char[] {','});
			equip[2] = (Helmet)GetItem.setHelmet(int.Parse(item[0]), item[1], item[2],
			                             int.Parse(item[3]), int.Parse(item[4]), int.Parse(item[5]),
			                             int.Parse(item[6]), int.Parse(item[7]), item[10],
			                             int.Parse(item[13]), int.Parse(item[14]));

			print ("Helmet\nId: " + int.Parse(item[0]) +
			       "\nName: " + item[1] +
			       "\nType: " + item[2] +
			       "\nVIT: " + item[3] +
			       "\nPM: " + item[4] +
			       "\nFRZ: " + item[5] +
			       "\nDEF: " + item[6] +
			       "\nSPD: " + item[7] +
			       "\nHeal: " + item[8] +
			       "\nMagic: " + item[9] +
			       "\nIcon Name: " + item[10] +
			       "\nslot_x: " + item[11] +
			       "\nslot_y: " + item[12]);

			ItemsInventory.addHelmet (int.Parse(item[0]), equip[2]);
			//inventory.addItem (ItemsInventory.getHelmet (int.Parse(item[0])));
			//inventory.removeItem(equip[2]);
			EquipWeapons.setHelmet((Helmet)equip[2]);
			
		}else equip[2] = null;

		if (armor_item != "") {
			item = armor_item.Split(new char[] {','});
			equip[3] = (Armor)GetItem.setArmor(int.Parse(item[0]), item[1], item[2],
			                            int.Parse(item[3]), int.Parse(item[4]), int.Parse(item[5]),
			                            int.Parse(item[6]), int.Parse(item[7]), item[10],
			                            int.Parse(item[13]), int.Parse(item[14]));

			print ("Armor\nId: " + int.Parse(item[0]) +
			       "\nName: " + item[1] +
			       "\nType: " + item[2] +
			       "\nVIT: " + item[3] +
			       "\nPM: " + item[4] +
			       "\nFRZ: " + item[5] +
			       "\nDEF: " + item[6] +
			       "\nSPD: " + item[7] +
			       "\nHeal: " + item[8] +
			       "\nMagic: " + item[9] +
			       "\nIcon Name: " + item[10] +
			       "\nslot_x: " + item[11] +
			       "\nslot_y: " + item[12]);

			ItemsInventory.addArmor (int.Parse(item[0]), equip[3]);
			//inventory.addItem (ItemsInventory.getArmor (int.Parse(item[0])));
			//inventory.removeItem(equip[3]);
			EquipWeapons.setArmor((Armor)equip[3]);
			
		}else equip[3] = null;

		if (boots_item != "") {
			item = boots_item.Split(new char[] {','});
			equip[4] = (Boots)GetItem.setBoots(int.Parse(item[0]), item[1], item[2],
			                            int.Parse(item[3]), int.Parse(item[4]), int.Parse(item[5]),
			                            int.Parse(item[6]), int.Parse(item[7]), item[10],
			                            int.Parse(item[13]), int.Parse(item[14]));

			print ("Boots\nId: " + int.Parse(item[0]) +
			       "\nName: " + item[1] +
			       "\nType: " + item[2] +
			       "\nVIT: " + item[3] +
			       "\nPM: " + item[4] +
			       "\nFRZ: " + item[5] +
			       "\nDEF: " + item[6] +
			       "\nSPD: " + item[7] +
			       "\nHeal: " + item[8] +
			       "\nMagic: " + item[9] +
			       "\nIcon Name: " + item[10] +
			       "\nslot_x: " + item[11] +
			       "\nslot_y: " + item[12]);

			ItemsInventory.addBoots (int.Parse(item[0]), equip[4]);
			//inventory.addItem (ItemsInventory.getBoots (int.Parse(item[0])));
			//inventory.removeItem(equip[4]);
			EquipWeapons.setBoots((Boots)equip[4]);
			
		}else equip[4] = null;


		return equip;

	}


}
