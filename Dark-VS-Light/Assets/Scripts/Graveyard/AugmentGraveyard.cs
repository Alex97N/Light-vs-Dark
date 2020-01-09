using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentGraveyard : MonoBehaviour
{
     
    public List<AugmentCard> augmentsInGrave = new List<AugmentCard> ();
    
    public int graveCounter;
    public int getGraveCounter(){
        return graveCounter;
    }
    
    public void addAugmentInGrave(AugmentCard a){
        
        graveCounter++;
        augmentsInGrave.Add(a);
    
    }
    
    public AugmentCard getFromTheGrave(int i){
        
        AugmentCard a = augmentsInGrave[i];
        augmentsInGrave.RemoveAt(i); 
        graveCounter--;
        return a;
        
    }
    
    public AugmentCard getFromTheGrave(){
        
        graveCounter--;
        AugmentCard a = augmentsInGrave[graveCounter];
        augmentsInGrave.RemoveAt(graveCounter);
        return a;
        
    }
    
    void Start()
    {
        graveCounter = 0;
    }

    
    void Update()
    {
        
    }
}
