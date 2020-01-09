using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeck : MonoBehaviour
{
    public List<MonsterCard> deckMonsters = new List<MonsterCard>(10);
    public int deckSize;
    public int getDeckSize(){
        return deckSize;
    }
    public void setDeckSize(int i){
        deckSize = i;
    }
    
    public void setDeck(int size, List<MonsterCard> deck){
    	deckSize = size;
    	deckMonsters = deck;
    }
    
    public GameObject TopBack;
    
    void Start()
    {
   		int index;
        deckSize = 10;
        
        for(int i =0;i<deckSize;i++){
        		
        	index = Random.Range(0,5);
        
       		deckMonsters[i] = new MonsterCard( Database.monsterCardList[index] );
        
        }
        
    }

    void Update()
    {
        if(deckSize == 0){
        	TopBack.SetActive(false);
        }else if (deckSize > 0 && !TopBack.activeSelf){
        	TopBack.SetActive(true);
        }
    }
    
    public void Shuffle(){
    	
    	int index;
    	MonsterCard auxMonster;
    		
    	for(int i=0;i<deckSize;i++){
    		
    		auxMonster = deckMonsters[i];
    		index = Random.Range(i,deckSize);
    		deckMonsters[i] = deckMonsters[index];
    		deckMonsters[index] = auxMonster;
    
    	}
    	
    }
    
    public MonsterCard getMonsterFromDeck(){
    	if(deckSize<1) return null;
    	else{
    		MonsterCard m = deckMonsters[deckSize-1];
    		deckMonsters.RemoveAt(deckSize-1);
    		deckSize--;
    		return m;
    	}
    }
    
    public void addMonsterInDeck(MonsterCard m){
    	deckMonsters.Add(m);
    	deckSize++;
    }
}
