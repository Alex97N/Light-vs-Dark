using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThisLord : MonoBehaviour
{

    public Lord lord;
    public Lord getLord(){
        return lord;
    }
    public void setLord(Lord l){
        lord = l;
    }
    
    public Image lordImage;
    public Image frame;
    public Text healthText; 
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lord != null){
            healthText.text = "" + lord.getHp();
            lordImage.sprite = lord.getLordImg();
            /*
            switch(lord.getType()){
                case 0: frame.GetComponent<Image>().color = new Color32(0,0,0,255);
                break;
                case 1: frame.GetComponent<Image>().color = new Color32(255,255,255,255);
                break;
                case 2: frame.GetComponent<Image>().color = new Color32(255,0,0,255);
                break;
                case 3: frame.GetComponent<Image>().color = new Color32(0,0,255,255);
                break;
                case 4: frame.GetComponent<Image>().color = new Color32(0,255,0,255);
                break;
                case 5: frame.GetComponent<Image>().color = new Color32(165,42,42,255);
                break;
                default: frame.GetComponent<Image>().color = new Color32(255,255,255,255);
                break;          
            }*/

            frame.sprite = lord.getFrame();
            
            this.name = lord.getLordName();
        }
    }
}
