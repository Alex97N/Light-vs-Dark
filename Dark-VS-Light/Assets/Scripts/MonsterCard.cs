using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class MonsterCard : MonoBehaviour {
    
	private string id ;
	private string cardName;
	private string cardDescription;

	private int cost;
	private int atk;
	private int health;


	public MonsterCard(){

	}

	public MonsterCard(string id, string cardName, int cost, int atk, int health, string cardDescription){
		
		this.id = id;
		this.cardName = cardName;
		this.cost = cost;
		this.atk = atk;
		this.health = health;
		this.cardDescription = cardDescription;
	}

	public string getId(){ return this.id; }
	public void setID(string id){ this.id = id; }

	public string getCardName(){ return this.cardName; }
	public void setCardName(string cardName){ this.cardName = cardName; }

	public string getCardDescription(){ return this.cardDescription; }
	public void setCardDescription(string cardDescription){ this.cardDescription = cardDescription; }

	public int getCost (){ return this.cost;}
	public void setCost (int cost){ this.cost = cost;}

	public int getAtk (){ return this.atk;}
	public void setAtk (int atk){ this.atk = atk;}

	public int getHealth (){ return this.health;}
	public void setHealth (int health){ this.health = health;}

}
