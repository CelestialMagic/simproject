using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Cdoe by Jessie Archer
public class InfoTrigger : Trigger
{
    //Opens only display text
    protected override void OpenUI()
    {
        displayText.gameObject.SetActive(true);


    }
    //Closes display text
    protected override void CloseUI()
    {
        displayText.gameObject.SetActive(false);

    }

 
}
