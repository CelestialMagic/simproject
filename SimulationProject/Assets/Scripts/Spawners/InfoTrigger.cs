using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenUI();
        }
        else
        {
            CloseUI();
        }
    }
    protected void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CloseUI();
        }
    }
}
