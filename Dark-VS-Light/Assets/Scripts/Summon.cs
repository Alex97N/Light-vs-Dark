using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
	public List<GameObject> monsterZones = new List<GameObject>() ;

	public GameObject summonLoc;
	//public GameObject monsterCard;
    void Start()
    {
	    for (int i = 0; i < 5; i++)
        {
	        monsterZones.Add(GameObject.Find("FieldMonsterZone"+(i+1)));
        }

    }

    // Update is called once per frame
    void Update()
    {
    
     
    }
	
	
	public void summon(){

		for (int i = 0; i < 5; i++)
		{
			if (!monsterZones[i].GetComponent<FieldMonsterZone>().hasMonster() )
			{
				Debug.Log("Zone "+ (i+1));
				GameObject gameObject = Instantiate(summonLoc, monsterZones[i].transform.position, monsterZones[i].transform.rotation) as GameObject;
				
				gameObject.transform.SetParent(monsterZones[i].transform);
				//gameObject.transform.localScale = Vector3.one;
				//gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
				//gameObject.transform.eulerAngles = new Vector3(0, 0, 0);

				gameObject.GetComponent<SummonLocSummon>().setMonsterZone(monsterZones[i]);
				gameObject.GetComponent<SummonLocSummon>().setMonsterCard(this.gameObject);

			}
		}


	}

	

}
