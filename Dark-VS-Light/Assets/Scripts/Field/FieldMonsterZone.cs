using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMonsterZone : MonoBehaviour
{

    public GameObject monster;
    public GameObject getMonster()
    {
        return monster;
    }
    public void setMonster(GameObject go)
    {
        monster = go;
    }
    
    void Start()
    {
        monster = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool hasMonster()
    {
        if (monster != null) return true;
        else return false;
    }

}
