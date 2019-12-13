using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour
{
    public  List<GameObject> monstersCardsInGrave = new List<GameObject> ();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void addInGrave(GameObject go){
        
        monstersCardsInGrave.Add(go);
    
    }
}
