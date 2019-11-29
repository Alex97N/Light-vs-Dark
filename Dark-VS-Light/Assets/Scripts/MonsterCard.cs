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

}
