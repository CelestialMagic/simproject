using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnDisplay : MonoBehaviour
{
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI costText;
    private TextMeshProUGUI description;
    private Image icon;

    private void SetName(string name)
    {
        nameText.text = name;

    }

    private void SetCost(int cost)
    {
        costText.text = cost.ToString();

    }

    private void SetImage(Image image)
    {
        icon = image;

    }

    private void SetDescription(string text)
    {
        description.text = text;
    }

}
