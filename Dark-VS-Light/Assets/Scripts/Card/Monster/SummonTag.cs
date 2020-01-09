using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonTag : MonoBehaviour
{

    public GameObject monster;
    public void setMonster(GameObject go){
        monster = go;
    }
    
    public GameObject zone;
    public void setZone(GameObject go){
        zone = go;
    }

    public void summonMonster(){
    
        monster.transform.SetParent(zone.transform);
        monster.transform.position = zone.transform.position;
        monster.transform.eulerAngles = zone.transform.eulerAngles;
        
        monster.GetComponent<ThisMonsterCard>().setSummoned(true);
        monster.GetComponent<ThisMonsterCard>().setZoneSummoned(zone);
        monster.GetComponent<ThisMonsterCard>().getZoneInHand().GetComponent<HandZone>().setCard(null);
        monster.GetComponent<ThisMonsterCard>().setZoneInHand(null);
        zone.GetComponent<FieldMonsterZone>().setMonster(monster);
        
        MonsterCard monsterCard = monster.GetComponent<ThisMonsterCard>().getMonsterCard();
        Mana manaCounter = monster.GetComponent<ThisMonsterCard>().getMyPlayer().getManaGameObject().GetComponent<Mana>();
        MonsterHand hand = monster.GetComponent<ThisMonsterCard>().getMyPlayer().getMonsterHandGameObject().GetComponent<MonsterHand>();
    
        // Pay the mana cost 
        manaCounter.setCurrentMana( manaCounter.getCurrentMana() - monsterCard.getCost() );
        // Set the correct number of cards in hand and Arrange them
        hand.setNmbMonstersInHand( hand.getNmbMonstersInHand() - 1 );
        hand.arrangeCards();
        
        FieldMonsters f = monster.GetComponent<ThisMonsterCard>().getMyPlayer().getFieldGameObject().GetComponent<FieldMonsters>();
        f.setMonstersInPlay( f.getMonstersInPlay() + 1 );
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(monster.GetComponent<ThisMonsterCard>().getIsSummoned()){
            Destroy(this.gameObject);
        }
    }
    
    
}
