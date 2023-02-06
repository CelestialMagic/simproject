using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public abstract class Trigger : MonoBehaviour
{
    [SerializeField]
    protected TMP_Text displayText;

    protected abstract void OpenUI();//Opens UI
    protected abstract void CloseUI();//Closes UI

    // Start is called before the first frame update
    protected void Start()
    {
        CloseUI();

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
