using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGraveyard : MonoBehaviour
{
    
    public List<MonsterCard> monstersInGrave = new List<MonsterCard> ();
        
    public int graveCounter;
    public int getGraveCounter(){
        return graveCounter;
    }
        
    public void addMonsterInGrave(MonsterCard m){
    
         graveCounter++;
         monstersInGrave.Add(m);
        
    }
        
    public MonsterCard getFromTheGrave(int i){
 
         MonsterCard m = monstersInGrave[i];
         monstersInGrave.RemoveAt(i); 
         graveCounter--;
         return m;
            
    }
    
    public MonsterCard getFromTheGrave(){
 
        graveCounter--;
        MonsterCard m = monstersInGrave[graveCounter];
        monstersInGrave.RemoveAt(graveCounter);
        return m;
            
    }
   
    void Start()
    {
       graveCounter = 0;
    }
    
    void Update()
    {
    }
    
}
