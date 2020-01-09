using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTag : MonoBehaviour
{

    public GameObject lord;
    public void setLord(GameObject go)
    {
        lord = go;
    }
    
    public GameObject monster;
    public void setMonster(GameObject go)
    {
        monster = go;
    }

    public GameObject zone;
    public void setZone(GameObject go)
    {
        zone = go;
    }

    public AugmentCard augment;
    public void setAugmentCard(AugmentCard a)
    {
        augment = a;
    }
    
    public ThisAugmentCard thisAugment;
    public void setThisAugmentCard(ThisAugmentCard t)
    {
        thisAugment = t;
    }

    public void activateEffect()
    {

        switch (augment.getType())
        {
            case 0: MonsterCard m = monster.GetComponent<ThisMonsterCard>().getMonsterCard();
                augment.activateEffect(m);
                break;
            case 1: FieldMonsterZone f = zone.GetComponent<FieldMonsterZone>();
                augment.activateEffect(f);
                break;
            case 2: Lord l = lord.GetComponent<ThisLord>().getLord();
                augment.activateEffect(l);
                break;
            default: break;
        }

        thisAugment.setWasActivated(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( thisAugment.getWasActivated() )
        {
            Destroy(this.gameObject);
        }
    }
}
