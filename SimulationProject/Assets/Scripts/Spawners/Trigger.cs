using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
//Code by Jessie Archer
public abstract class Trigger : MonoBehaviour
{
    [SerializeField]
    protected TMP_Text displayText;//A text that displays object info

    protected abstract void OpenUI();//Opens UI
    protected abstract void CloseUI();//Closes UI

    // Start is called before the first frame update
    protected void Start()
    {
        CloseUI();

    }
    //Checks if the player is in range
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
    //Checks if the player exited range
    protected void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CloseUI();
        }
    }

}
