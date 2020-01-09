using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Type:
0 DARK
1 LIGHT
2 FIRE
3 WATER
4 WIND
5 EARTH
*/

[System.Serializable]

public class MonsterCard{
    
    // ID
	public string id ;
	public string getId(){
		return id;
	}
	public void setId(string s){
		id = s;
	}
	
	// NAME
	public string monsterName;
	public string getMonsterName(){
		return monsterName;
	}
	public void setMonsterName(string s){
		monsterName = s;
	}	
	
	// DESCRIPTION
	public string monsterDescription;
	public string getMonsterDescription(){
		return monsterDescription;
	}
	public void setMonsterDescription(string s){
		monsterDescription = s;
	}
	
	// COST
	public int cost;
	public int getCost(){
		return cost;
	}
	public void setCost(int i){
		cost = i;
	}
	
	// ATK
	public int atk;
	public int getAtk(){
		return atk;
	}
	public void setAtk(int i){
		atk = i;
	}
	
	// HP
	public int hp;
	public int getHp(){
		return hp;
	}
	public void setHp(int i){
		hp = i;
	}
	
	// MAX HP
	public int maxHp;
	public int getMaxHp(){
		return maxHp;
	}
	public void setMaxHp(int i){
		maxHp = i;
	}
	
	// TYPE
	public int type;
	public int getType(){
		return type;
	}
	public void setType(int i){
		type = i;
	}
	
	// IMG
	public Sprite monsterImg;
	public Sprite getMonsterImg(){
		return monsterImg;
	}
	public void setMonsterImg(Sprite s){
		monsterImg = s;
	}
	
	public Sprite frame;
	public Sprite getFrame()
	{
		return frame;
	}
	public void setFrame(Sprite s)
	{
		frame = s;
	}

	public MonsterCard(string Id, string MonsterName, string MonsterDescription, int Cost, int Atk, int MaxHp, int Type, Sprite MonsterImg, Sprite Frame){
		
		id = Id;
		monsterName = MonsterName;
		monsterDescription = MonsterDescription;
		cost = Cost;
		atk = Atk;
		hp = MaxHp;
		maxHp = MaxHp;
		type = Type;
		monsterImg = MonsterImg;
		frame = Frame;
	}

	public MonsterCard( MonsterCard m ){
	
		id = m.getId();
		monsterName = m.getMonsterName();
		monsterDescription = m.getMonsterDescription();
		cost = m.getCost();
		atk = m.getAtk();
		hp = m.getMaxHp();
		maxHp = m.getMaxHp();
		type = m.getType();
		monsterImg = m.getMonsterImg();
		frame = m.getFrame();

	}

}
