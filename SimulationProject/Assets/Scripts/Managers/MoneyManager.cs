using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
//Code by Jessie Archer
public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;//Text used to display current money
    private static float currentIncome;//The player's current income in-game
    private static PhotonView photonView;

    public void Start()
    {
        photonView = gameObject.GetComponent<PhotonView>();
    }
    // Update() works to display the current amount of money to the screen
    public void Update()
    {
        photonView.RPC("SyncIncome", RpcTarget.All);
        displayText.text = "$" + GetCurrentIncome().ToString();
    }

    //Returns the Current Amount of Money
    public static float GetCurrentIncome()
    {
        return currentIncome;
    }
    //Sets the current amount of money through addition
    public static void SetCurrentIncome(float amount)
    {
        photonView.RPC("AddIncome", RpcTarget.All, amount);

    }
    //Deducts player bought item costs from the currentIncome. 
    public static void BuyItem(float amount)
    {
        photonView.RPC("SubtractIncome", RpcTarget.All, amount);

    }

    //Resets the amount of money earned by the player
    public static void ResetMoney()
    {
        currentIncome = 0;
    }

    [PunRPC]
    public void AddIncome(float amount)
    {
        currentIncome += amount;
    }

    [PunRPC]
    public void SubtractIncome(float amount)
    {
        currentIncome -= amount;
    }

    [PunRPC]
    public void SyncIncome()
    {
        currentIncome = currentIncome; 
    }
}
