using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ThisMonsterCard : MonoBehaviour{

	//  VAR for UI
    public MonsterCard monsterCard;
    public MonsterCard getMonsterCard(){
    	return monsterCard;
    }
    public void setMonsterCard(MonsterCard m){
    	monsterCard = m;
   	}

	public Text costText;
	public Text atkText;
	public Text hpText;
	
	public Image frame;
	public Image monsterImg;
	
	
	// VAR for FUNCTIONALITIES	
	
	public Player myPlayer;
	public Player getMyPlayer(){
		return myPlayer;
	}
	public void setMyPlayer(Player p){
		myPlayer = p;
	}
    	
	
	public bool isSummoned;
	public bool getIsSummoned(){
   		return isSummoned;
    }
    	
   	public void setSummoned(bool boo){
   		isSummoned = boo;
   	}

	public bool summonTime;
	public bool getSummonTime(){
		return summonTime;
	}
	public void setSummonTime(bool boo){
		summonTime = boo;
	}
	
	public GameObject summonTag;
	
	// The field zone used for this card
	public GameObject zoneSummoned;
	public GameObject getZoneSummoned(){
		return zoneSummoned;
	}
	public void setZoneSummoned(GameObject go){
		zoneSummoned = go;
	}
	
	// The hand zone used for this card
	public GameObject zoneInHand;
	public GameObject getZoneInHand(){
		return zoneInHand;
	}
	public void setZoneInHand(GameObject go){
		zoneInHand = go;
	}
	
	// Summon Monster
	
	public void summonMonster(){
	
		List<GameObject> zones = myPlayer.getFieldGameObject().GetComponent<FieldMonsters>().getZones();
		Mana manaCounter = myPlayer.getManaGameObject().GetComponent<Mana>();
		
		if ( (myPlayer.getFieldGameObject().GetComponent<FieldMonsters>().getMonstersInPlay() < 5) && 
		!isSummoned && summonTime && ( monsterCard.getCost() <= manaCounter.getCurrentMana() ) ){
		
			for(int i = 0 ; i<5 ; i++){
				if( !zones[i].GetComponent<FieldMonsterZone>().hasMonster() ){
					
					GameObject go = Instantiate(summonTag, zones[i].transform.position, zones[i].transform.rotation) as GameObject;
					go.transform.SetParent(zones[i].transform);
					
					go.GetComponent<SummonTag>().setZone(zones[i]);
                    go.GetComponent<SummonTag>().setMonster(this.gameObject);
					
				}	
			}
		
		}
		
	}
	
	// End Summon Monster

	// Die
	
	public void monsterDied(){

		if ( isSummoned ){
		
			if( monsterCard.getHp() == 0 ){
			
				MonsterGraveyard grave = myPlayer.getMonsterGraveyardGameObject().GetComponent<MonsterGraveyard>();
				grave.addMonsterInGrave(monsterCard);

                FieldMonsters f = myPlayer.getFieldGameObject().GetComponent<FieldMonsters>();
                f.setMonstersInPlay( f.getMonstersInPlay() - 1 );

				Destroy(this.gameObject);
			}

		}
		
	}

	// End Die

    void Start()
    {
		isSummoned = false;
		summonTime = true;
    }

    // Update is called once per frame
    void Update()
    {
	    if (monsterCard != null)
	    {

		    costText.text = "" + monsterCard.getCost();
		    atkText.text = "" + monsterCard.getAtk();
		    hpText.text = "" + monsterCard.getHp();
			
			monsterImg.sprite =  monsterCard.getMonsterImg();
			/*
			switch(monsterCard.getType()){
                case 0: frame.GetComponent<Image>().color = new Color32(0,0,0,255);
                break;
                case 1: frame.GetComponent<Image>().color = new Color32(255,255,255,255);
                break;
                case 2: frame.GetComponent<Image>().color = new Color32(255,0,0,255);
                break;
                case 3: frame.GetComponent<Image>().color = new Color32(0,0,255,255);
                break;
                case 4: frame.GetComponent<Image>().color = new Color32(0,255,0,255);
                break;
                case 5: frame.GetComponent<Image>().color = new Color32(165,42,42,255);
                break;
                default: frame.GetComponent<Image>().color = new Color32(255,255,255,255);
                break;          
            }			*/

			frame.sprite = monsterCard.getFrame();
            
     
			
			this.name = monsterCard.getMonsterName();
			
	    }
		
		monsterDied();
	   
    }
	
}
