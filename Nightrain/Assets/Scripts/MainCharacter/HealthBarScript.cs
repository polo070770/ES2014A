﻿using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {
	

	private CharacterScript cs;
	private GameObject character;

	public float scale;		// <-- Scale of the HealthBar

	private float health;	// <-- This value is to calculate the health 'Cutoff' of the texture [0.5, 1]
	private float magic;	// <-- This value is to calculate the magic 'Cutoff' of the texture [0.5, 1]
	private float damage;

	private float resize_health;	// <-- This value is to do more large or short the health bar
	private float resize_bar_health;
	private float resize_magic;		// <-- This value is to do more large or short the magic bar
	private float resize_bar_magic;

	public float max_health;
	public float max_magic;

	private float fadeSpeed = 2f;
	private float alpha = 1.0f;
	private int direction = -1;		// Direction -1 = Fade in
									// Direction  1 = Fade out

	private float VIT;
	private float PM;
	// HEALTH BAR
	// --- TEXTURES ---
	private Texture2D AvatarTexture;
	
	private Texture2D HealthTexture;
	private Texture2D HealthBarTexture;

	private Texture2D DamageBarTexture;
	
	private Texture2D MagicTexture;
	private Texture2D MagicBarTexture;
	private Texture2D LowMagicTexture;

	private Texture2D DecotrationTextureUp;
	private Texture2D DecotrationTextureDown;
	
	// --- MATERIALS ---
	private Material HealthBarMaterial;
	private Material DamageBarMaterial;
	private Material MagicBarMaterial;

	private bool critical = false;
	private bool low_magic = false;


	// Use this for initialization
	void Start () {

		this.character = GameObject.FindGameObjectWithTag ("Player");
		this.cs = this.character.GetComponent<CharacterScript> ();
		
		this.max_health = this.cs.getMaxHealth ();
		this.VIT = this.max_health;
		this.max_magic = this.cs.getMaxMagic ();
		this.PM = this.max_magic;

		// Resize the health and magic bar with the actual values
		this.resize_health = this.scale * Mathf.Pow(this.cs.getHealth() / this.cs.getMaxHealth (), -1);
		this.resize_magic = this.scale * Mathf.Pow(this.cs.getMagic() / this.cs.getMaxMagic (), -1);

		// Set the news actual max life and magic
		this.cs.setMaxHealth ();
		this.cs.setMaxMagic ();
		//this.max_health = this.bar_health;
		//this.max_magic = this.bar_magic;

		// ADD TEXTURES
		this.AvatarTexture = Resources.Load<Texture2D>("HealthBar/avatar_" + PlayerPrefs.GetString("Player"));
		this.HealthTexture = Resources.Load<Texture2D>("HealthBar/health");
		this.HealthBarTexture = Resources.Load<Texture2D>("HealthBar/bar_health");
		this.DamageBarTexture = Resources.Load<Texture2D>("HealthBar/damage_health");
		this.MagicTexture = Resources.Load<Texture2D>("HealthBar/magic");
		this.MagicBarTexture = Resources.Load<Texture2D>("HealthBar/bar_magic");
		this.LowMagicTexture = Resources.Load<Texture2D>("HealthBar/caution");
		this.DecotrationTextureUp = Resources.Load<Texture2D>("HealthBar/decoracion_up");
		this.DecotrationTextureDown = Resources.Load<Texture2D>("HealthBar/decoracion_down");

		// ADD MATERIALS
		this.HealthBarMaterial = Resources.Load<Material>("HealthBar/Materials/bar_health");
		this.DamageBarMaterial = Resources.Load<Material>("HealthBar/Materials/damage_health");
		this.MagicBarMaterial = Resources.Load<Material>("HealthBar/Materials/bar_magic");

		this.health = 0f;
		this.HealthBarMaterial.SetFloat("_Cutoff", this.health);

		this.damage = 0f;
		this.DamageBarMaterial.SetFloat("_Cutoff", this.damage);

		this.magic = 0f;
		this.MagicBarMaterial.SetFloat("_Cutoff", this.magic);
	
	}
	
	// Update is called once per frame
	void Update () {

		VIT = this.cs.getMemoryCard ().load.loadVIT ();
		PM = this.cs.getMemoryCard ().load.loadPM ();
<<<<<<< HEAD
		//print ("VIT:" + VIT + " GetHealth: " + this.cs.getHealth () + " GetMaxHealth: " + this.cs.getMaxHealth () + " MaxHealth: " + this.max_health);
		this.resize_health = this.scale * Mathf.Pow((this.cs.getMaxHealth()/*VIT/* + this.cs.getVIT()*/)/ this.max_health, -1);
		//this.resize_bar_health = this.scale * Mathf.Pow(this.cs.getHealth() / this.max_health, -1);
		this.resize_magic = this.scale * Mathf.Pow((this.cs.getMaxMagic() /*+ this.cs.getPM()*/) / this.max_magic, -1);
=======

		this.resize_health = this.scale * Mathf.Pow((VIT/* + this.cs.getVIT()*/)/ this.max_health, -1);
		//this.resize_bar_health = this.scale * Mathf.Pow(this.cs.getHealth() / this.max_health, -1);
		this.resize_magic = this.scale * Mathf.Pow((PM /*+ this.cs.getPM()*/) / this.max_magic, -1);
>>>>>>> 710a951727f91ce211db816c812bc01edeb77703
		//this.resize_bar_magic = this.scale * Mathf.Pow(this.cs.getMagic() / this.max_magic, -1);

		this.UpdateHealth ();
		this.UpdateMagic ();
	}


	void UpdateHealth () {
			
		// Esto es para cuando le quede 1/4 de vida se ponga en rojo
		if(this.health >= 0.9f){
			this.critical = true;
			this.cs.setCritical(true);
		}else{
			this.critical = false;
			this.cs.setCritical(false);
		}

		if(this.health == 1.0f){
			this.cs.setHealth(0);
		}else{
			this.health = 1 - ((this.cs.getHealth() / this.cs.getMaxHealth()));
			this.HealthBarMaterial.SetFloat("_Cutoff", health);
			this.DamageBarMaterial.SetFloat("_Cutoff", health);
		}
		
	}
	

	// Este metodo debera ser implementado mas adelante con el tema de magias etc
	void UpdateMagic () {

		this.magic = 1 - (this.cs.getMagic() / this.cs.getMaxMagic());

		if(this.magic >= 0.9f)
			this.low_magic = true;
		else
			this.low_magic = false;

		if(this.magic <= 1)	
			this.MagicBarMaterial.SetFloat("_Cutoff", magic);
	}


	public float x;
	public float y;

	void OnGUI(){

		if (Event.current.type.Equals (EventType.Repaint)) {
	
			// AVATAR ZONE
			Rect avatar_box = new Rect (0, 0, this.AvatarTexture.width / this.scale, this.AvatarTexture.height / this.scale);
			Graphics.DrawTexture (avatar_box, this.AvatarTexture);

			// HEALTH BAR ZONE	
			Rect healthbar_box = new Rect ((this.AvatarTexture.width / this.scale) - 2,
			                                35, 
			                                this.HealthBarTexture.width / this.resize_health, 
			                                this.HealthBarTexture.height*1.2f / this.scale);

			if(!critical)
				Graphics.DrawTexture (healthbar_box, this.HealthBarTexture, this.HealthBarMaterial);
			else
				Graphics.DrawTexture (healthbar_box, this.DamageBarTexture, this.DamageBarMaterial);

			Rect health_box = new Rect ((this.AvatarTexture.width / this.scale) - 2,
			                             35, 
			                             this.HealthTexture.width / this.resize_health, 
			                             this.HealthTexture.height*1.2f / this.scale);

			Graphics.DrawTexture (health_box, this.HealthTexture);

			Rect decorationUp_box = new Rect (((this.AvatarTexture.width / this.scale) + (this.HealthTexture.width / this.resize_health)) - 3,
					                            35, 
			                                    this.DecotrationTextureUp.width / this.scale, 
			                                    this.DecotrationTextureUp.height*1.2f / this.scale);
			
			Graphics.DrawTexture (decorationUp_box, this.DecotrationTextureUp);

			// MAGIC BAR ZONE

			Rect lowmagic_box = new Rect ((this.AvatarTexture.width / this.scale) - 3,
			                              66, 
			                              this.LowMagicTexture.width / this.resize_magic, 
			                              (this.LowMagicTexture.height*1.2f / this.scale) - 8);
			
			
			
			if(low_magic){
				this.alpha += direction * fadeSpeed * Time.deltaTime;		// We decrease or increase alpha depends direction.
				alpha = Mathf.Clamp01 (this.alpha);							// Values between 0 and 1.
				GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, this.alpha);
				GUI.DrawTexture (lowmagic_box, this.LowMagicTexture);
				if(alpha == 0) this.direction = 1; else if(alpha >= 0.5f) this.direction = -1;
			}

			Rect magicbar_box = new Rect ((this.AvatarTexture.width / this.scale) - 3,
	                             		   66, 
			                              this.MagicBarTexture.width / this.resize_magic, 
			                               (this.MagicBarTexture.height*1.2f / this.scale) - 8);

			Graphics.DrawTexture (magicbar_box, this.MagicBarTexture, this.MagicBarMaterial);


			Rect magic_box = new Rect ((this.AvatarTexture.width / this.scale) - 3,
		                                66, 
		                                this.MagicTexture.width / this.resize_magic, 
			                            this.MagicTexture.height*1.2f / this.scale);

			Graphics.DrawTexture (magic_box, this.MagicTexture);



			Rect decorationDown_box = new Rect (((this.AvatarTexture.width / this.scale) + (this.MagicTexture.width / this.resize_magic)) - 3,
		                                  	  	66, 
			                                    this.DecotrationTextureDown.width / this.scale, 
			                                    this.DecotrationTextureDown.height*1.2f / this.scale);
			
			Graphics.DrawTexture (decorationDown_box, this.DecotrationTextureDown);

			
		}
	}
}
