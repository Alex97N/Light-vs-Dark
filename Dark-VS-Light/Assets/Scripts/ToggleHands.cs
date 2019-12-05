using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHands : MonoBehaviour
{
    public GameObject handM;
	public GameObject handA;
	
	public Text handToSwitch;
	
	private bool boolM;
	private bool boolA;
	
    void Start()
    {
		boolM = true;
		boolA = false;
		
		handToSwitch.text = "Augments";
		
        handM.SetActive(boolM);
		handA.SetActive(boolA);
    }

    
    void Update()
    {
        
    }
	
	public void toggleHands(){
		
		boolM = !boolM;
		boolA = !boolA;
		
		if(boolM){
			handToSwitch.text = "Augments";
		}else{
			handToSwitch.text = "Monsters";
		}
		
        handM.SetActive(boolM);
		handA.SetActive(boolA);
		
	}
}
