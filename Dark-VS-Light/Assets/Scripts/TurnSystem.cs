using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
	private float waitTime;
    public int waitTimeBeforeEnd;
    
    
    // phases
    public bool drawPhase;
    
	public bool mainPhase;
	
	public bool battlePhase;
	
	public bool endPhase;
	
	// Buttons
	
	public GameObject battleButton;
	
	public GameObject endTurnButton;
	
	public GameObject handToggleA1;
    public GameObject handToggleM1;
    public GameObject handToggleA2;
    public GameObject handToggleM2;
    				
	
	//  true dark ; false dark
	public static bool darkOrLight;
	// 
	public bool humanMove;
	
	public Text timerText;

    // GO 
    public GameObject monsterCardObject;
    public GameObject augmentCardObject;
    
    //Turn number
    public int turnNumber;
    public int getTurnNumber()
    {
        return turnNumber;
    }
    public void turnPassed()
    {
        turnNumber++;
    }

    public Text turnText;

    // Players
    public GameObject player1;
    public GameObject player2;
    public Player thisPlayer;
    public Player enemyPlayer;

	public Image turnArrow;
	
	public Sprite turnArrowUp;
	public Sprite turnArowDown;
	public Sprite turnArrowFirst;
	public Sprite turnArrowSecond;
	
	public bool changeArow;

	public void setTheFirstPlayer(){
	
		changeArow = true;
	
		int chance = Random.Range(0,9999);
		
		if((chance % 2) != 0){
			
			thisPlayer = player1.GetComponent<Player>();
            enemyPlayer = player2.GetComponent<Player>();
            
            turnArrowFirst = turnArowDown;
			turnArrowSecond = turnArrowUp;
			
			humanMove = true;
			
		}else{
		
			thisPlayer = player2.GetComponent<Player>();
            enemyPlayer = player1.GetComponent<Player>();
		
			turnArrowFirst = turnArrowUp;
           	turnArrowSecond = turnArowDown;
		
			humanMove = false;
		
		}
		
		turnArrow.sprite = turnArrowFirst;
	
	}

    void Start()
    {
		waitTime = 0.2f;
		waitTimeBeforeEnd = 60;
		
		battleButton.SetActive(false);
        endTurnButton.SetActive(false);
        	
        handToggleA1.SetActive(false);
        handToggleM1.SetActive(false);
        handToggleA2.SetActive(false);
        handToggleM2.SetActive(false);
		
		mainPhase = true;

		turnNumber = 1;
		
		setTheFirstPlayer();
		
		setLord(thisPlayer,0);
		setLord(enemyPlayer,1);
		
		if(darkOrLight){
			setLord(thisPlayer,0);
            setLord(enemyPlayer,1);
		}else{
			setLord(thisPlayer,1);
            setLord(enemyPlayer,0);
		}

        StartCoroutine(beginningOfTheDuel(thisPlayer,20));
		StartCoroutine(beginningOfTheDuel(enemyPlayer,20));
		
		StartCoroutine(startEnemy(15*waitTime));
   
    }

    // Update is called once per frame
    void Update()
    {
        turnText.text = "" + turnNumber;
        checkFinished();
    }
    
	public void setLord(Player player,int i){
		player.getLordGameObject().GetComponent<ThisLord>().setLord(new Lord(Database.lordList[i]));
	}

	IEnumerator startEnemy(float f){
		
		StartCoroutine(startTimer());
		
		yield return new WaitForSeconds(f);
		
		if(!humanMove){
			StartCoroutine(enemyPlayerBot());
		}else{
			battleButton.SetActive(true);
            endTurnButton.SetActive(true);
		}
		
		handToggleA1.SetActive(true);
        handToggleA2.SetActive(true);
		
	}

    /* Each player turn:
     * 1. draw and mana gain
     * 2. 2 buttons appear, Battle & EndTurn
     * 3. the player will summon monsters/use augments/powers
     * 4. press Battle => battle phase
     * 5. press EndTurn => the turn is ended
     */
    
    // The beginning of the match 
    // 1. draw the cards
    // 2. set the mana 
    IEnumerator drawAtStart(Player player)
    {
        // DRAW MONSTERS

        player.getMonsterHandGameObject().SetActive(true);
        player.getAugmentHandGameObject().SetActive(false);
        
        // Deck and Hand
        MonsterDeck monsterDeck = player.getMonsterDeckGameObject().GetComponent<MonsterDeck>();
        MonsterHand monsterHand = player.getMonsterHandGameObject().GetComponent<MonsterHand>();
        // MonsterCard var
        MonsterCard monsterCard;

        yield return new WaitForSeconds(waitTime);
        
        for (int i = 0; i < 5; i++)
        {
            monsterCard = monsterDeck.getMonsterFromDeck();

            GameObject handZone = monsterHand.getNextZone();
            GameObject newMonsterCard = Instantiate(monsterCardObject, handZone.transform.position, handZone.transform.rotation) as GameObject;

            newMonsterCard.GetComponent<ThisMonsterCard>().setMonsterCard(monsterCard);
            newMonsterCard.GetComponent<ThisMonsterCard>().setMyPlayer(player);
            newMonsterCard.GetComponent<ThisMonsterCard>().setZoneInHand(handZone);
                        
            newMonsterCard.transform.SetParent(handZone.transform);
            newMonsterCard.transform.position = handZone.transform.position;
            newMonsterCard.transform.eulerAngles = handZone.transform.eulerAngles;

            handZone.GetComponent<HandZone>().setCard(newMonsterCard);

            monsterHand.setNmbMonstersInHand(monsterHand.getNmbMonstersInHand() + 1);
            
            yield return new WaitForSeconds(waitTime);
        }
        
        // END DRAW MONSTERS
        
        // DRAW AUGMENTS
        
        player.getMonsterHandGameObject().SetActive(false);
        player.getAugmentHandGameObject().SetActive(true);
        
        // Deck and Hand
        AugmentDeck augmentDeck = player.getAugmentDeckGameObject().GetComponent<AugmentDeck>();
        AugmentHand augmentHand = player.getAugmentHandGameObject().GetComponent<AugmentHand>();
        // AugmentCard var
        AugmentCard augmentCard;
        
        yield return new WaitForSeconds(waitTime);

        for (int i = 0; i < 5; i++)
        {
            augmentCard = augmentDeck.getAugmentFromDeck();

            GameObject handZone = augmentHand.getNextZone();
            GameObject newAugmentCard = Instantiate(augmentCardObject, handZone.transform.position, handZone.transform.rotation) as GameObject;

            newAugmentCard.GetComponent<ThisAugmentCard>().setAugmentCard(augmentCard);
            newAugmentCard.GetComponent<ThisAugmentCard>().setMyPlayer(player);
            newAugmentCard.GetComponent<ThisAugmentCard>().setZoneInHand(handZone);
            
            newAugmentCard.transform.SetParent(handZone.transform);
            newAugmentCard.transform.position = handZone.transform.position;
            newAugmentCard.transform.eulerAngles = handZone.transform.eulerAngles;
            
            handZone.GetComponent<HandZone>().setCard(newAugmentCard);
            
            augmentHand.setNmbAugmentsInHand(augmentHand.getNmbAugmentsInHand() + 1);
            
            yield return new WaitForSeconds(waitTime);
        }
        
        player.getMonsterHandGameObject().SetActive(true);
        player.getAugmentHandGameObject().SetActive(false);

        // END DRAW AUGMENTS
        
    }
    
    public void setManaAtStart(Player player, int manaAtStart){
    
        GameObject manaGo = player.getManaGameObject();
        manaGo.GetComponent<Mana>().setCurrentMana(manaAtStart);
        manaGo.GetComponent<Mana>().setMaxMana(manaAtStart);
    
    }

    IEnumerator beginningOfTheDuel(Player player, int manaAtStart)
    {
        StartCoroutine(drawAtStart(player));
        setManaAtStart(player, manaAtStart);
        yield break;
    }

	

    // For each turn :
    // 1. draw function and mana gain function
    
    IEnumerator drawAndGainMana(Player player){

	    yield return new WaitForSeconds(1);    
    
        Mana manaCounter = player.getManaGameObject().GetComponent<Mana>();
        
        if ( (turnNumber % 5) == 0 ){
        	Mana manaThis = thisPlayer.getManaGameObject().GetComponent<Mana>();
            manaThis.setMaxMana( manaThis.getMaxMana() + 10 );
            Mana manaEnemy = enemyPlayer.getManaGameObject().GetComponent<Mana>();
            manaEnemy.setMaxMana( manaEnemy.getMaxMana() + 10 );
        }
        
        int manaGain = (turnNumber/10) + 2;
        
        if( (manaCounter.getCurrentMana() + manaGain) <= manaCounter.getMaxMana() ){
            manaCounter.setCurrentMana( manaCounter.getCurrentMana() + manaGain );
        }
    
        yield return new WaitForSeconds(waitTime);  
    
        drawPhase = false;

        mainPhase = true;

        StartCoroutine(startTimer());
        
        if(!humanMove){
        	StartCoroutine(enemyPlayerBot());
		}else{
			battleButton.SetActive(true);
            endTurnButton.SetActive(true);
		}        
    }
    
    // 2. battle functions
	
	IEnumerator battleDelay()
    {
		
		Lord thisLord, enemyLord;        
		
		thisLord = thisPlayer.getLordGameObject().GetComponent<ThisLord>().getLord();
		enemyLord = enemyPlayer.getLordGameObject().GetComponent<ThisLord>().getLord();

		List<MonsterCard> thisMonsters = new List<MonsterCard> ();
		List<MonsterCard> enemyMonsters = new List<MonsterCard> ();
		
		List<GameObject> zones;

		zones = thisPlayer.getFieldGameObject().GetComponent<FieldMonsters>().getZones();
		for(int i = 0 ; i < 5 ; i++){
			if(zones[i].GetComponent<FieldMonsterZone>().hasMonster()){
				thisMonsters.Add(zones[i].GetComponent<FieldMonsterZone>().getMonster().GetComponent<ThisMonsterCard>().getMonsterCard());
			}else thisMonsters.Add(null);
		}

		zones = enemyPlayer.getFieldGameObject().GetComponent<FieldMonsters>().getZones();
		for(int i = 0 ; i < 5 ; i++){
			if(zones[i].GetComponent<FieldMonsterZone>().hasMonster()){
				enemyMonsters.Add(zones[i].GetComponent<FieldMonsterZone>().getMonster().GetComponent<ThisMonsterCard>().getMonsterCard());
			}else enemyMonsters.Add(null);
		}	
		
		yield return new WaitForSeconds(waitTime);
		
		for( int i = 0 ; i < 5 ; i++ ){
				
			if( thisMonsters[i] != null ){
				if( enemyMonsters[i] == null ){
					if( enemyLord.getHp() >= thisMonsters[i].getAtk() ){
						enemyLord.setHp( enemyLord.getHp() - thisMonsters[i].getAtk() );
					} else enemyLord.setHp(0);	
				}else{
					if( enemyMonsters[i].getHp() >=  thisMonsters[i].getAtk()){
						enemyMonsters[i].setHp( enemyMonsters[i].getHp() - thisMonsters[i].getAtk() );
					}
					else enemyMonsters[i].setHp(0);
				}
			}
			
			yield return new WaitForSeconds(waitTime);

		} 

		yield return new WaitForSeconds(waitTime);
		
		battlePhase = false;

		endTurn();
		
    }

	public void battle(){
		
		mainPhase = false;

		battlePhase = true;
		
		battleButton.SetActive(false);
        endTurnButton.SetActive(false);

		StartCoroutine(battleDelay());
		
	}

	// end battle functions
    // 3. end turn function 

    

    public void endTurn()
    {
    	battleButton.SetActive(false);
        endTurnButton.SetActive(false);
    
	    endPhase = true;
	    
	    mainPhase = false;
	    
	    Player auxPlayer;
	    auxPlayer = thisPlayer;
	    thisPlayer = enemyPlayer;
	    enemyPlayer = auxPlayer;
	    
	    if (changeArow){
	    
	    	turnArrow.sprite = turnArrowSecond;
	    
	    }else{
	    
	    	turnArrow.sprite = turnArrowFirst;
	    	
	    }
	    
	    changeArow = !changeArow;
	    
	    turnPassed();

	    endPhase = false;

	    drawPhase = true;
	    
	    humanMove = !humanMove;
	    
	    StartCoroutine(drawAndGainMana(thisPlayer));
    }

    // end end turn function
    
    
    //timer function
    
    IEnumerator startTimer(){
    	
    	for(int i = waitTimeBeforeEnd ; i > 0 ; i--){
    		if( mainPhase ){
    			
    			timerText.text = "" + i;
    			yield return new WaitForSeconds(1);
    			
    		}else{
				timerText.text = "";    		
    			break;
    		}
    	}
    	
    	timerText.text = "";  
    	
    	if(mainPhase){
	        endTurn();
    		Debug.Log("Ended turn by timer");
    	}

    }
    
    IEnumerator enemyPlayerBot(){
    
    	handToggleA2.SetActive(false);
        handToggleM2.SetActive(false);
    
    	yield return new WaitForSeconds(6*waitTime);
    	
    	Mana manaCounter = thisPlayer.getManaGameObject().GetComponent<Mana>();
                                       
    	MonsterHand mHand = thisPlayer.getMonsterHandGameObject().GetComponent<MonsterHand>();
        
        AugmentHand aHand = thisPlayer.getAugmentHandGameObject().GetComponent<AugmentHand>();
        
        FieldMonsters fMonsters = thisPlayer.getFieldGameObject().GetComponent<FieldMonsters>();
        
        thisPlayer.getMonsterHandGameObject().SetActive(true);
        thisPlayer.getAugmentHandGameObject().SetActive(false);
        
        if (fMonsters.getMonstersInPlay() <5){
        
			List<GameObject> zones = mHand.getZones();
			
			for(int i = 0 ; i < mHand.getNmbMonstersInHand() ; i++ ){
			
				MonsterCard mCard = zones[i].GetComponent<HandZone>().getCard().GetComponent<ThisMonsterCard>().getMonsterCard();
				
				if(mCard.getCost() <= manaCounter.getCurrentMana()){
				
					ThisMonsterCard tmCard = zones[i].GetComponent<HandZone>().getCard().GetComponent<ThisMonsterCard>();
					tmCard.summonMonster();
					
					GameObject tag = GameObject.Find("SummonTag(Clone)");
					
					tag.GetComponent<SummonTag>().summonMonster();
					i--;	
					yield return new WaitForSeconds(4*waitTime);
				}
			
			}
        }                
       	
       	thisPlayer.getMonsterHandGameObject().SetActive(false);
        thisPlayer.getAugmentHandGameObject().SetActive(true);        
      
        if(fMonsters.getMonstersInPlay() != 0){
                
          	List<GameObject> zones = aHand.getZones();
          	
            for(int i = 0 ; i < aHand.getNmbAugmentsInHand(); i++){
           
            	ThisAugmentCard taCard = zones[i].GetComponent<HandZone>().getCard().GetComponent<ThisAugmentCard>();
            	taCard.activateAugment();
            	
            	GameObject tag = GameObject.Find("ActivateTag(Clone)");
            	tag.GetComponent<ActivateTag>().activateEffect();
            	i--;
            	yield return new WaitForSeconds(4*waitTime);
            }    
        }

		thisPlayer.getMonsterHandGameObject().SetActive(true);
        thisPlayer.getAugmentHandGameObject().SetActive(false);      		       
                            
        yield return new WaitForSeconds(4*waitTime);                    
        
        handToggleA2.SetActive(true);
                                
    	battle();
    
    }
    
    //end timer function 
	
	
	// finish game
	
	public GameObject positionFinish;
	public GameObject winGo;
	public GameObject lostGo;
	
	public void checkFinished(){
	
		Lord enemy = player2.GetComponent<Player>().getLordGameObject().GetComponent<ThisLord>().getLord();
		
		
		if ( enemy.getHp() == 0 ){
		
			GameObject win = Instantiate(winGo, positionFinish.transform.position, positionFinish.transform.rotation) as GameObject;
			
			win.transform.SetParent(positionFinish.transform);
            win.transform.position = positionFinish.transform.position;
            win.transform.eulerAngles = positionFinish.transform.eulerAngles;
                        
			
			Destroy(this.gameObject);
		
		}
		
		Lord ally = player1.GetComponent<Player>().getLordGameObject().GetComponent<ThisLord>().getLord();
             		
			
		if ( ally.getHp() == 0 ){
        		
      		GameObject lost = Instantiate(lostGo, positionFinish.transform.position, positionFinish.transform.rotation) as GameObject;
        	
        	lost.transform.SetParent(positionFinish.transform);
            lost.transform.position = positionFinish.transform.position;
            lost.transform.eulerAngles = positionFinish.transform.eulerAngles;
                            
        	
       		Destroy(this.gameObject);
       		
        }
	
	}
	
	//end finish game
	
}
