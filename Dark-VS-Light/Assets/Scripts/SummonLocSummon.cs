using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonLocSummon : MonoBehaviour
{

    public GameObject monsterZone;
    public GameObject monsterCard;
        
    void Start()
    {
        
    }
    
    void Update()
    {
        if(monsterCard.GetComponent<ThisMonsterCard>().checkSummoned()){
            Destroy(this.gameObject);
        }
    }

    public void setMonsterZone(GameObject go)
    {
        this.monsterZone = go;
    }
    
    public void setMonsterCard(GameObject go)
    {
        this.monsterCard = go;
    }

    public void summonMonster()
    {
        monsterCard.transform.SetParent(monsterZone.transform);
        monsterCard.transform.position = monsterZone.transform.position;
        monsterCard.transform.eulerAngles = monsterZone.transform.eulerAngles;
        
        monsterCard.GetComponent<ThisMonsterCard>().setSummoned(true);
        monsterZone.GetComponent<FieldMonsterZone>().setMonster(monsterCard);
        
    }

}
