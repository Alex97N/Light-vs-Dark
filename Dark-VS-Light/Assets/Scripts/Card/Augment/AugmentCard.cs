using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class AugmentCard
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
    public string augmentName;
    public string getAugmentName(){
        return augmentName;
    }
    public void setAugmentName(string s){
        augmentName = s;
    }

    // IMG
    public Sprite augmentImg;
    public Sprite getAugmentImg(){
        return augmentImg;
    }
    public void setAugmentImg(Sprite s){
        augmentImg = s;
    }

    // TYPE 0 monster 1 field 2 lord
    public int type;
    public int getType(){
        return type;
    }
    public void setType(int i){
        type = i;
    }
    
    public AugmentEffect augmentEffect;
    
    public AugmentCard(string Id, string AugmentNName, Sprite AugmentImg, int Type, AugmentEffect Effect)
    {
        id = Id;
        augmentName = AugmentNName;
        augmentImg = AugmentImg;
        type = Type;
        augmentEffect = Effect;
    }

    public void activateEffect(MonsterCard m)
    {
        augmentEffect.effect(m);
    }

    public void activateEffect(Lord l)
    {
        augmentEffect.effect(l);
    }
    
    public void activateEffect(FieldMonsterZone f)
    {
        augmentEffect.effect(f);
    }

}
