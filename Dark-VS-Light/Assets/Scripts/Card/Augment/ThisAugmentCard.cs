using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ThisAugmentCard : MonoBehaviour
{

    public AugmentCard augmentCard;
    public AugmentCard getAugmentCard(){
        return augmentCard;
    }
    public void setAugmentCard(AugmentCard a){
        augmentCard = a;
    }
    
    public Image augmentImage;
    public Image frame;

    // Use effect
    
    public Player myPlayer;
    public Player getMyPlayer(){
        return myPlayer;
    }
    public void setMyPlayer(Player p){
        myPlayer = p;
    }

    public bool wasActivated;
    public bool getWasActivated()
    {
        return wasActivated;
    }
    public void setWasActivated(bool boo)
    {
        wasActivated = boo;
    }

    public bool activateTime;
    public bool getActivateTime()
    {
        return activateTime;
    }
    public void setActivateTime(bool boo)
    {
        activateTime = boo;
    }

    public GameObject activateTag;

    public void activateAugment()
    {
        if (!wasActivated && activateTime)
        {
            switch ( augmentCard.getType() )
            {
                case 0: activateAugmentMonster();
                    break;
                case 1 : activateAugmentField();
                    break;
                case 2 : activateAugmentLord();
                    break;
                default: break;
            }
        }
    }

    public void activateAugmentLord()
    {
        
        GameObject lord = myPlayer.getLordGameObject();
        
        ActivateTag at = activateTag.GetComponent<ActivateTag>();
        at.setLord(lord);
        at.setAugmentCard(augmentCard);
        at.setThisAugmentCard(this);
            
        GameObject go = Instantiate(activateTag, lord.transform.position, lord.transform.rotation) as GameObject;
        go.transform.SetParent(lord.transform);

    }

    public void activateAugmentMonster()
    {
        List<GameObject> zones = myPlayer.getFieldGameObject().GetComponent<FieldMonsters>().getZones();
        for (int i = 0 ; i< 5; i++) {
            if (zones[i].GetComponent<FieldMonsterZone>().hasMonster())
            {
                GameObject monster = zones[i].GetComponent<FieldMonsterZone>().getMonster();
                
                ActivateTag at = activateTag.GetComponent<ActivateTag>();
                
                at.setMonster(monster);
                at.setAugmentCard(augmentCard);
                at.setThisAugmentCard(this);
                
                GameObject go = Instantiate(activateTag, monster.transform.position, monster.transform.rotation) as GameObject;
                go.transform.SetParent(monster.transform);
            }
        }
    }

    public void activateAugmentField()
    {
        List<GameObject> zones = myPlayer.getFieldGameObject().GetComponent<FieldMonsters>().getZones();
        for (int i = 0 ; i < 5 ; i++) {
            
            ActivateTag at = activateTag.GetComponent<ActivateTag>();

            at.setZone(zones[i]);
            at.setAugmentCard(augmentCard);
            at.setThisAugmentCard(this);
            
            GameObject go = Instantiate(activateTag, zones[i].transform.position, zones[i].transform.rotation) as GameObject;
            go.transform.SetParent(zones[i].transform);
        }
    }
    
    // End use effect

    //Send to grave

    public GameObject zoneInHand;
    public GameObject getZoneInHand()
    {
        return zoneInHand;
    }
    public void setZoneInHand(GameObject go)
    {
        zoneInHand = go;
    }

    public void sentToGrave()
    {
        if (wasActivated)
        {
            AugmentGraveyard grave = myPlayer.getAugmentGraveyardGameObject().GetComponent<AugmentGraveyard>();
            AugmentHand hand = myPlayer.getAugmentHandGameObject().GetComponent<AugmentHand>();
            grave.addAugmentInGrave(augmentCard);

            zoneInHand.GetComponent<HandZone>().setCard(null);
            
            hand.setNmbAugmentsInHand( hand.getNmbAugmentsInHand() - 1 );
            hand.arrangeCards();
            
            Destroy(this.gameObject);
        }
    }

    //End send to grave
    
    void Start()
    {
        activateTime = true;
        wasActivated = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(augmentCard != null){
            augmentImage.sprite = augmentCard.getAugmentImg();
            /*
            switch(augmentCard.getType()){
                case 0: frame.GetComponent<Image>().color = new Color32(0,0,0,255);
                break; 
                case 1: frame.GetComponent<Image>().color = new Color32(255,255,255,255);
                break;
                case 2: frame.GetComponent<Image>().color = new Color32(255,0,0,255);
                break;
                default: frame.GetComponent<Image>().color = new Color32(255,255,255,255);
                break; 
            }*/
            this.name = augmentCard.getAugmentName();
        }

        sentToGrave();
    }
}
