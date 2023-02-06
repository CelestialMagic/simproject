using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITrigger : MonoBehaviour
{
    [SerializeField]
    protected TMP_Text displayText;
    [SerializeField]
    protected Image displayImage;
    [SerializeField]
    protected TMP_Text descriptionText;
    [SerializeField]
    protected TMP_Text costText;

    [SerializeField]
    private GameObject player;

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

    protected virtual void OpenUI()
    {
        displayText.gameObject.SetActive(true);
        displayImage.gameObject.SetActive(true);
        descriptionText.gameObject.SetActive(true);
        costText.gameObject.SetActive(true);

    }
    protected virtual void CloseUI()
    {
        displayText.gameObject.SetActive(false);
        displayImage.gameObject.SetActive(false);
        descriptionText.gameObject.SetActive(false);
        costText.gameObject.SetActive(false);
    }
}
