using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class MonsterCard{
    
	public string id ;
	public string cardName;
	public string cardDescription;

	public int cost;
	public int atk;
	public int health;
	public Sprite monsterImg;


	public MonsterCard(){

	}

	public MonsterCard(string Id, string CardName, int Cost, int Atk, int Health, string CardDescription,Sprite sp){
		
		id = Id;
		cardName = CardName;
		cost = Cost;
		atk = Atk;
		health = Health;
		cardDescription = CardDescription;
		monsterImg = sp;
	}

}
