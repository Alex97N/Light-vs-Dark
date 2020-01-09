using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHands : MonoBehaviour
{
    public GameObject handM;
	public GameObject handA;
	
	public GameObject buttonM;
	public GameObject buttonA;
	
	public void activateHandM(){
		
		handA.SetActive(false);
		handM.SetActive(true);
	
		buttonM.SetActive(false);
		buttonA.SetActive(true);
	}
	
	public void activateHandA(){
		
		handM.SetActive(false);
		handA.SetActive(true);
		
		buttonA.SetActive(false);
		buttonM.SetActive(true);
	
	}
	
    void Start()
    {	
		
        handM.SetActive(true);
		handA.SetActive(false);
		
		buttonM.SetActive(false);
        buttonA.SetActive(true);
        		
    }

    
    void Update()
    {
        
    }
	
}
