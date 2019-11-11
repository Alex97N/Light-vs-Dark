using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ThisMonsterCard : MonoBehaviour{

    public MonsterCard monsterCard;
	public int monsterCardId;

	public string id;
	public string cardName;
	public string cardDescription;

	public int cost;
	public int atk;
	public int health;

	public Text costText;
	public Text atkText;
	public Text healthText;

    void Start()
    {
        monsterCard = MonsterCardDataBase.monsterCardList[monsterCardId];
    }

    // Update is called once per frame
    void Update()
    {
	/*
        this.id = this.monsterCard.getId();
		this.cardName = this.monsterCard.getCardName();
		this.cardDescription = this.monsterCard.getCardDescription();

		this.cost = this.monsterCard.getCost();
		this.atk = this.monsterCard.getAtk();
		this.health = this.monsterCard.getHealth();


		this.costText.text = "" + this.cost;
		this.atkText.text = "" + this.atk;
		this.healthText.text = "" + this.health;
	*/
		id = monsterCard.id;
		cardName = monsterCard.cardName;
		cardDescription = monsterCard.cardDescription;

		cost = monsterCard.cost;
		atk = monsterCard.atk;
		health = monsterCard.health;

		costText.text = "" + cost;
		atkText.text = "" + atk;
		healthText.text = "" + health;
    }
}
