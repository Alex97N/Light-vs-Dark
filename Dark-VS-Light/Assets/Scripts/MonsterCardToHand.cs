using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCardToHand : MonoBehaviour
{

	public GameObject Hand;
	public GameObject mcToHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
		Hand = GameObject.Find("Hand");
		mcToHand.transform.SetParent(Hand.transform);
		mcToHand.transform.localScale = Vector3.one;
		mcToHand.transform.position = new Vector3(transform.position.x,transform.position.y, 0);
		mcToHand.transform.eulerAngles = new Vector3(25,0,0);

    }
}
