using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Jessie Archer, Brandon Lo, and Noel Paredes
public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<ObjectFactory> objects;//A list of available objects to buy (buildings and animals)

    [SerializeField]
    private int currentIndex;//The currently selected object

    [SerializeField]
    private SpawnDisplay spawnDisplay; //A display card to use

    private bool isTouchingPen;//determines if player is touching pen

    [SerializeField]
    private GameObject spawnerToDestroy;//The spawner to destroy when building is placed

    private PlayerMovement currentPlayer;

    private bool canCycle;

    [SerializeField]
    private float countdown;

    [SerializeField]
    private float resetCounter;
    // Update is called once per frame
    void Update()
    {
        DisplayCurrentObject();
        int objListLength = objects.Count;

        //user selects choice
        if (Input.GetKeyDown(KeyCode.X))
        {
            //If statement determines if player has enough money to buy an animal and places animal if true
            if (objects[currentIndex] is Animal && isTouchingPen && ((Animal)objects[currentIndex]).cost <= MoneyManager.GetCurrentIncome())
            {
                ((Animal)objects[currentIndex]).transform.position = gameObject.transform.position;
                ((Animal)objects[currentIndex]).CreateObject();
                MoneyManager.BuyItem(((Animal)objects[currentIndex]).cost);

            }
            else if (objects[currentIndex] is Building && isTouchingPen && ((Building)objects[currentIndex]).cost <= MoneyManager.GetCurrentIncome())
            //Else if statement determines if player has enough money to buy a building and places the building if true, destroying the spawner
            {
                ((Building)objects[currentIndex]).transform.position = gameObject.transform.position;
                Destroy(spawnerToDestroy);
                ((Building)objects[currentIndex]).CreateObject();
                MoneyManager.BuyItem(((Building)objects[currentIndex]).cost);
            }

        }

        //user cycles left (down in objects list)
        if (currentPlayer != null)
        {
            CycleCooldown();

            if (currentPlayer.GetMenuValue() < 0.01 && canCycle == true)
            {
                if (currentIndex != 0 && currentIndex >= 0 && objListLength > 1)
                {
                    currentIndex -= 1;
                    canCycle = false; 
                }
            }
            if (currentPlayer.GetMenuValue() > 0.01 && canCycle == true)
            {
                if (objListLength > (currentIndex + 1) && objListLength > 1)
                {
                    currentIndex += 1;
                    canCycle = false;
                }
            }
        }


    }
    //Checks if player is in radius
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTouchingPen = true;
            Debug.Log("Touching pen works.");
            currentPlayer = other.GetComponent<PlayerMovement>();
        }
    }
    //Checks if player exited radius
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTouchingPen = false;
        }
    }
    //Displays the currently selected object
    private void DisplayCurrentObject()
    {
        //Checks if object is Animal and calls display methods
        if (objects[currentIndex] is Animal)
        {
            spawnDisplay.SetName(((Animal)objects[currentIndex]).name);
            spawnDisplay.SetCost(((Animal)objects[currentIndex]).cost);
            spawnDisplay.SetDescription(((Animal)objects[currentIndex]).description);

        }
        //Checks if object is Building and calls display methods
        else if (objects[currentIndex] is Building)
        {
            spawnDisplay.SetName(((Building)objects[currentIndex]).name);
            spawnDisplay.SetCost(((Building)objects[currentIndex]).cost);
            spawnDisplay.SetDescription(((Building)objects[currentIndex]).description);

        }

    }

    private void CycleCooldown()
    {
            if (countdown - Time.deltaTime <= 0)
            {
                countdown = resetCounter;
                canCycle = true;
            }
            else
            {
                countdown -= Time.deltaTime;

            }

        }
        

    }
