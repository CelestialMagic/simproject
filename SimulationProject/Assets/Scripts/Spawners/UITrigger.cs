using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Code by Jessie Archer
public class UITrigger : Trigger
{
    [SerializeField]
    protected Image displayImage;//Displays an icon 
    [SerializeField]
    protected TMP_Text descriptionText;//Object description display
    [SerializeField]
    protected TMP_Text costText;//Object cost display

    //Displays UI
    protected override void OpenUI()
    {
        displayText.gameObject.SetActive(true);
        displayImage.gameObject.SetActive(true);
        descriptionText.gameObject.SetActive(true);
        costText.gameObject.SetActive(true);

    }
    //Closes UI
    protected override void CloseUI()
    {
        displayText.gameObject.SetActive(false);
        displayImage.gameObject.SetActive(false);
        descriptionText.gameObject.SetActive(false);
        costText.gameObject.SetActive(false);
    }
}
