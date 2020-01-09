using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    // current mana
    public int currentMana;
    public int getCurrentMana(){
        return currentMana;
    }
    public void setCurrentMana(int i){
        currentMana = i;
    }
    
    // max mana
    public int maxMana;
    public int getMaxMana(){
        return maxMana;
    }
    public void setMaxMana(int i){
        maxMana = i;
    }
    
    
    public Text manaText;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        manaText.text = "" + currentMana + "/" + maxMana;
    }
    
    
}
