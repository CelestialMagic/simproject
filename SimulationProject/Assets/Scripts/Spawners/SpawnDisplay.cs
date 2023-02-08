using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;//Name Text to display
    [SerializeField]
    private TextMeshProUGUI costText;//Cost Text to display
    [SerializeField]
    private TextMeshProUGUI description;//Description to display
    [SerializeField]
    private Image icon;//Icon to display (currently unused)

    //Sets name text
    public void SetName(string name)
    {
        nameText.text = name;

    }
    //Sets cost text
    public void SetCost(int cost)
    {
        costText.text = cost.ToString();

    }
    //Sets image 
    public void SetImage(Image image)
    {
        icon = image;

    }
    //Sets description
    public void SetDescription(string text)
    {
        description.text = text;
    }

}
