using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
    [SerializeField]
    private TMP_Text displayText;
    [SerializeField]
    private Image displayImage;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        displayText.gameObject.SetActive(false);
        displayImage.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            displayText.gameObject.SetActive(true);
            displayImage.gameObject.SetActive(true);
        }
        else
        {
            displayText.gameObject.SetActive(false);
            displayImage.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            displayText.gameObject.SetActive(false);
            displayImage.gameObject.SetActive(false);
        }
    }
}
