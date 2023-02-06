using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTrigger : UITrigger
{
    protected override void OpenUI()
    {
        displayText.gameObject.SetActive(true);


    }
    protected override void CloseUI()
    {
        displayText.gameObject.SetActive(false);

    }
}
