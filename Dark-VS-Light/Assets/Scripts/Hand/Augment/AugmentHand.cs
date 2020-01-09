using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentHand : MonoBehaviour
{
    public List<GameObject> zones = new List<GameObject>(5);
    public List<GameObject> getZones(){
        return zones;
    }
    
    
    public int nmbAugmentsInHand;
    public int getNmbAugmentsInHand(){
        return nmbAugmentsInHand;
    }
    public void setNmbAugmentsInHand(int i){
        nmbAugmentsInHand = i;
    }
    
    public GameObject getNextZone(){
        
        if (nmbAugmentsInHand == 5) return null;
        else{
            return zones[nmbAugmentsInHand];
        }
        
    }
    
    public void arrangeCards(){
        
        int count=0;
        
        for(int i = 0; i < nmbAugmentsInHand; i++){
            
            if ( zones[i].GetComponent<HandZone>().hasCard() ){
                count++;
            }
            
        }
        
        if(count != nmbAugmentsInHand){
        
            for(int i = 0; i < nmbAugmentsInHand ; i++){
            
                if( !zones[i].GetComponent<HandZone>().hasCard() ){
                
                    for(int j = i+1 ; j < 5 ; j++){
                    
                        if( zones[j].GetComponent<HandZone>().hasCard() ){
                        
                            GameObject go = zones[j].GetComponent<HandZone>().getCard();
                            zones[i].GetComponent<HandZone>().setCard(go);
                            go.GetComponent<ThisAugmentCard>().setZoneInHand(zones[i]);
                            zones[j].GetComponent<HandZone>().setCard(null);
                            
                            go.transform.SetParent(zones[i].transform);
                            go.transform.position = zones[i].transform.position;
                            go.transform.eulerAngles = zones[i].transform.eulerAngles;
                        
                            break;
                        }
                    
                    }
                
                }
            
            }
        
        }
    
    }
    
    
    void Start()
    {
        nmbAugmentsInHand = 0;
    }

    void Update()
    {
        
    }
   
}
