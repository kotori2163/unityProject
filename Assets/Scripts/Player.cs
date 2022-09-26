using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Character
{
    
    public Image hpMeter;
    public Image expMeter;
    public TextMeshProUGUI hpText;
    // Start is called before the first frame update
    void Start()
    {
        //player=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        string hptx=hpText.text;
    }

    // Update is called once per frame
    void Update()
    {
        
            
           
            hpMeter.fillAmount=hp/max_hp;
            expMeter.fillAmount=exp/max_exp;
            hpText.text=string.Format("{0}/{1}",hp,max_hp);
        
    }
}
