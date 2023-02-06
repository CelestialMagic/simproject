using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI costText;
    [SerializeField]
    private TextMeshProUGUI description;
    [SerializeField]
    private Image icon;

    public void SetName(string name)
    {
        nameText.text = name;

    }

    public void SetCost(int cost)
    {
        costText.text = cost.ToString();

    }

    public void SetImage(Image image)
    {
        icon = image;

    }

    public void SetDescription(string text)
    {
        description.text = text;
    }

}
