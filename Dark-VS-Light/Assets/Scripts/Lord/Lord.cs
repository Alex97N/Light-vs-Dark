using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Type:
0 DARK
1 LIGHT
2 FIRE
3 WATER
4 WIND
5 EARTH
*/

[System.Serializable]

public class Lord
{
    // ID
    public string id;
    public string getId(){
        return id;
    }
    public void setId(string s){
        id = s;
    }
    
    // NAME 
    public string lordName;
    public string getLordName(){
        return lordName;
    }
    public void setLordName(string s){
        lordName = s;
    }
    
    // DESCRIPTION
    public string lordDescription;
    public string getLordDescription(){
        return lordDescription;
    }
    public void setLordDescription(string s){
        lordDescription = s;
    }
    
    // TYPE
    public int type;
    public int getType(){
        return type;
    }
    public void setType(int i){
        type = i;
    }
    
    // HP
    public int hp;
    public int getHp(){
        return hp;
    }
    public void setHp(int i){
        hp = i;
    }
    
    // MAX HP
    public int maxHp;
    public int getMaxHp(){
        return maxHp;
    }
    public void setMaxHp(int i){
        maxHp = i;
    }
    
    // IMG
    public Sprite lordImg;
    public Sprite getLordImg(){
        return lordImg;
    }
    public void setLordImg(){
    
    }

    public Sprite frame;
    public Sprite getFrame()
    {
        return frame;
    }
    public void setFrame(Sprite s)
    {
        frame = s;
    }

    public Lord(string Id, string LordName, string LordDescription, int Type, int MaxHp, Sprite LordImg, Sprite Frame){
        id = Id;
        lordName = LordName;
        lordDescription = LordDescription;
        type = Type;
        hp = MaxHp;
        maxHp = MaxHp;
        lordImg = LordImg;
        frame = Frame;
    }

    public Lord( Lord l )
    {
        id = l.getId();
        lordName = l.getLordName();
        lordDescription = l.getLordDescription();
        type = l.getType();
        hp = l.getMaxHp();
        maxHp = l.getMaxHp();
        lordImg = l.getLordImg();
        frame = l.getFrame();
    }
    
}
