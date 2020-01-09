using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMonsters : MonoBehaviour
{

    public List<GameObject> zones = new List<GameObject>(5);
    public List<GameObject> getZones()
    {
        return zones;
    }

    public int monstersInPlay;
    public int getMonstersInPlay()
    {
        return monstersInPlay;
    }
    public void setMonstersInPlay(int i)
    {
        monstersInPlay = i;
    }


    // Start is called before the first frame update
    void Start()
    {
        monstersInPlay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
