using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentDeck : MonoBehaviour
{
    public List<AugmentCard> deckAugments = new List<AugmentCard>(10);
    public int deckSize;
    public int getDeckSize(){
        return deckSize;
    }
    public void setDeckSize(int i){
        deckSize = i;
    }    
    
    public void setDeck(int size, List<AugmentCard> deck){
        deckSize = size;
        deckAugments = deck;
    }
        
    public GameObject TopBack;
    
    void Start()
    {
   		int index;
        deckSize = 10;
        
        for(int i =0;i<deckSize;i++){
        		
        	index = Random.Range(0,5);
        
       		deckAugments[i] = Database.augmentCardList[index];
        
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
    	AugmentCard auxAugment;
    		
    	for(int i=0;i<deckSize;i++){
    		
    		auxAugment = deckAugments[i];
    		index = Random.Range(i,deckSize);
    		deckAugments[i] = deckAugments[index];
    		deckAugments[index] = auxAugment;
    
    	}
    	
    }
    
    public AugmentCard getAugmentFromDeck(){
    	if(deckSize<1) return null;
    	else{
    		AugmentCard a = deckAugments[deckSize-1];
    		deckAugments.RemoveAt(deckSize-1);
    		deckSize--;
    		return a;
    	}    	
    }
    
    public void addAugmentInDeck(AugmentCard a){
    	deckAugments.Add(a);
    	deckSize++;
    }
}
