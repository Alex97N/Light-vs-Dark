using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMonsterZone : MonoBehaviour
{

    public GameObject monster;
    
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

    public void setMonster(GameObject go)
    {
        this.monster = go;
    }

}
