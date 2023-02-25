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

    private PlayerMovement currentPlayer;//The current player character being controlled

    private bool isHeld;//A boolean that checks if a menu input is held down
    private bool placeIsHeld;
    private int objListLength;

    [SerializeField]
    private float resetCounter;
    //Start() initializes the objListLength
    private void Start()
    {
        objListLength = objects.Count;
    }
    // Update is called once per frame
    void Update()
    {
        DisplayCurrentObject();
        SpawnObject();
        ScrollObjects();
        

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
    //SpawnObject() allows players to place an object
    private void SpawnObject()
    {
        if (currentPlayer != null)
        {
            float place = currentPlayer.GetMenuPlace();
            switch (place)
            {
                case 0:
                    if (placeIsHeld)
                        placeIsHeld = false;
                    break;

                case 1:
                    if (!placeIsHeld && isTouchingPen)
                    {
                        if (objects[currentIndex] is Animal && ((Animal)objects[currentIndex]).cost <= MoneyManager.GetCurrentIncome())
                        {
                            ((Animal)objects[currentIndex]).transform.position = gameObject.transform.position;
                            ((Animal)objects[currentIndex]).CreateObject();
                            MoneyManager.BuyItem(((Animal)objects[currentIndex]).cost);
                            placeIsHeld = true;
                        }
                        else if (objects[currentIndex] is Building && ((Building)objects[currentIndex]).cost <= MoneyManager.GetCurrentIncome())
                        {
                            ((Building)objects[currentIndex]).transform.position = gameObject.transform.position;
                            Destroy(spawnerToDestroy);
                            ((Building)objects[currentIndex]).CreateObject();
                            MoneyManager.BuyItem(((Building)objects[currentIndex]).cost);
                            placeIsHeld = true;

                        }
                    }
                    break;

                default:
                    break;
            } 
        }
        }

    //ScrollObjects() allows users to scroll through objects by tracking the index
    //of the list. 
    private void ScrollObjects()
    {
        //user selects choice
        if (currentPlayer != null)
        {
            float scrollSelect = currentPlayer.GetMenuValue();
            switch (scrollSelect)
            {
                case -1:
                    if ((!isHeld) && currentIndex != 0 && currentIndex >= 0 && objListLength > 1)
                    {
                        isHeld = true;
                        currentIndex--;
                    }
                        break;
                case 0:
                    if (isHeld)
                        isHeld = false;
                    break;
                case 1:
                    if ((!isHeld) && objListLength > (currentIndex + 1) && objListLength > 1)
                    {
                        isHeld = true;
                        currentIndex++;
                    }
                    break;
                default:
                    break;
            }

        }
    }

    
    }
