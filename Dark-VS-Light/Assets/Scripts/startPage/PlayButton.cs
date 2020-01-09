using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject darkButton;
    public GameObject ligthButton;
    public bool tog;

    // Start is called before the first frame update
    void Start()
    {
        darkButton.SetActive(false);   
        ligthButton.SetActive(false);
        
        tog = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void toggle(){
    
        darkButton.SetActive(tog);   
        ligthButton.SetActive(tog);       
        
        tog = !tog;
    }
}
