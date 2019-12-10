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
	public Sprite monsterImg;
	
	public Sprite monsterImgSprite;
	public Image monsterImage;
	
	public bool isSummoned;

	public GameObject HandObject;


    void Start()
    {
		
		isSummoned = false;
        HandObject = GameObject.Find("HandMonsters");

        //monsterCard = MonsterCardDataBase.monsterCardList[monsterCardId];
        if (this.tag == "CardToHand")
        {

            GameObject zone = HandObject.GetComponent<Hand>().positionForCard();

            this.transform.SetParent(zone.transform);
            this.transform.localScale = Vector3.one;
            this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            this.transform.eulerAngles = new Vector3(0, 0, 0);

            this.tag = "Untagged";
        }

    }

    // Update is called once per frame
    void Update()
    {
	    if (monsterCard != null)
	    {
		    id = monsterCard.id;
		    cardName = monsterCard.cardName;
		    cardDescription = monsterCard.cardDescription;

			monsterImgSprite = monsterCard.monsterImg; 

		    cost = monsterCard.cost;
		    atk = monsterCard.atk;
		    health = monsterCard.health;

		    costText.text = "" + cost;
		    atkText.text = "" + atk;
		    healthText.text = "" + health;
			
			monsterImage.sprite =  monsterImgSprite;
			
			this.name = cardName;
			
	    }

	   
    }

	public void setMonster(MonsterCard m){
		monsterCard = m;
	}
	
	public bool checkSummoned(){
		return isSummoned;
	}
	
	public void setSummoned(bool boo){
		isSummoned = boo;
	}
	
}
