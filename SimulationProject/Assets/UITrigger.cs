using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITrigger : MonoBehaviour
{
    [SerializeField]
    private TMP_Text displayText;

    // Start is called before the first frame update
    void Start()
    {
       displayText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            displayText.gameObject.SetActive(true);
        }
        else
        {
            displayText.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            displayText.gameObject.SetActive(false);
        }
    }
}
