using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITrigger : MonoBehaviour
{
    [SerializeField]
    private TMP_Text displayText;
    [SerializeField]
    private Image displayImage;
    [SerializeField]
    private TMP_Text descriptionText;
    [SerializeField]
    private TMP_Text costText;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        CloseUI();

    }

    private void OnTriggerEnter(Collider other)
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
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CloseUI();
        }
    }

    private void OpenUI()
    {
        displayText.gameObject.SetActive(true);
        displayImage.gameObject.SetActive(true);
        descriptionText.gameObject.SetActive(true);
        costText.gameObject.SetActive(true);

    }
    private void CloseUI()
    {
        displayText.gameObject.SetActive(false);
        displayImage.gameObject.SetActive(false);
        descriptionText.gameObject.SetActive(false);
        costText.gameObject.SetActive(false);
    }
}
