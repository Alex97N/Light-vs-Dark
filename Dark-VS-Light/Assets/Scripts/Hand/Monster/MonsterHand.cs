using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHand : MonoBehaviour
{
    public List<GameObject> zones = new List<GameObject>(5);
    
    public List<GameObject> getZones(){
        return zones;
    }
    
    public int nmbMonstersInHand;
    public int getNmbMonstersInHand(){
        return nmbMonstersInHand;
    }
    public void setNmbMonstersInHand(int i){
        nmbMonstersInHand = i;
    }
    
    public GameObject getNextZone(){
        
        if (nmbMonstersInHand == 5) return null;
        else{
            return zones[nmbMonstersInHand];
        }
        
    }
    
    public void arrangeCards(){
        
        int count=0;
        
        for(int i = 0; i < nmbMonstersInHand; i++){
            
            if ( zones[i].GetComponent<HandZone>().hasCard() ){
                count++;
            }
            
        }
        
        if(count != nmbMonstersInHand){
        
            for(int i = 0; i < nmbMonstersInHand ; i++){
            
                if( !zones[i].GetComponent<HandZone>().hasCard() ){
                
                    for(int j = i+1 ; j < 5 ; j++){
                    
                        if( zones[j].GetComponent<HandZone>().hasCard() ){
                        
                            GameObject go = zones[j].GetComponent<HandZone>().getCard();
                            zones[i].GetComponent<HandZone>().setCard(go);
							go.GetComponent<ThisMonsterCard>().setZoneInHand(zones[i]);
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
        nmbMonstersInHand = 0;
    }

    void Update()
    {
        
    }
}
