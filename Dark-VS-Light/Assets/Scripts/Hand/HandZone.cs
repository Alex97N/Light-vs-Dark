using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandZone : MonoBehaviour
{
    public GameObject card;
    public GameObject getCard()
    {
        return card;
    }
    public void setCard(GameObject go)
    {
        card = go;
    }
    public bool hasCard(){
        if(card != null) return true;
        else return false;
    }
    

    void Start()
    {
        card = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
