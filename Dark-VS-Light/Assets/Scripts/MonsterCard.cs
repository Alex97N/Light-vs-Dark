using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class MonsterCard{
    
	public string id ;
	public string cardName;
	public string cardDescription;

	public int cost;
	public int atk;
	public int health;


	public MonsterCard(){

	}

	public MonsterCard(string Id, string CardName, int Cost, int Atk, int Health, string CardDescription){
		
		id = Id;
		cardName = CardName;
		cost = Cost;
		atk = Atk;
		health = Health;
		cardDescription = CardDescription;
	}

	/*
	public string getId(){ return this.id; }
	public void setId(string id){ this.id = id; }

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
	*/

}
