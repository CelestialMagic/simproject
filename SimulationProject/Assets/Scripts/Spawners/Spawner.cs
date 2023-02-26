using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Jessie Archer, Brandon Lo, and Noel Paredes
public class Spawner : PurchaseObject
{
    [SerializeField]
    private List<ObjectFactory> objects;//A list of available objects to buy (buildings and animals)

    private List<GameObject> spawnedAnimals;//A list of game objects that hold animals

    [SerializeField]
    private int currentIndex;//The currently selected object

    [SerializeField]
    private GameObject spawnerToDestroy;//The spawner to destroy when building is placed



    private bool isHeld;//A boolean that checks if a menu input is held down
    private int objListLength;//An integer representing the length of the 

    //Start() initializes the objListLength and spawnedAnimals list
    private void Start()
    {
        objListLength = objects.Count;
        spawnedAnimals = new List<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
        DisplayCurrentObject();
        SpawnObject();
        ScrollObjects();
        

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
    protected override void SpawnObject()
    {
        //Null check for play er
        if (currentPlayer != null)
        {
            float place = currentPlayer.GetMenuPlace();
            //Switch statement executes based on input
            switch (place)
            {
                //No key press
                case 0:
                    if (placeIsHeld)
                        placeIsHeld = false;
                    break;

                //Player presses button to place object
                case 1:
                    if (!placeIsHeld && isTouchingPen)
                    {
                        //Animal Object Code
                        if (objects[currentIndex] is Animal && ((Animal)objects[currentIndex]).cost <= MoneyManager.GetCurrentIncome())
                        {
                            
                            ((Animal)objects[currentIndex]).transform.position = gameObject.transform.position;
                            GameObject animal = ((Animal)objects[currentIndex]).ReturnSpawnedObject();
                            spawnedAnimals.Add(animal);
                            MoneyManager.BuyItem(((Animal)objects[currentIndex]).cost);
                            placeIsHeld = true;
                        }
                        //Building Object Code
                        else if (objects[currentIndex] is Building && ((Building)objects[currentIndex]).cost <= MoneyManager.GetCurrentIncome())
                        {
                            ((Building)objects[currentIndex]).transform.position = gameObject.transform.position;
                            DestroySpawnedAnimals();
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
                //Scroll Left Code
                case -1:
                    if ((!isHeld) && currentIndex != 0 && currentIndex >= 0 && objListLength > 1)
                    {
                        isHeld = true;
                        currentIndex--;
                    }
                        break;
                //No Scroll Code
                case 0:
                    if (isHeld)
                        isHeld = false;
                    break;
                //Scroll Right Code
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

    //DestroySpawnedAnimals() destroys any animals spawned by the players
    //This is used to allow for buildings to be placed. 
    private void DestroySpawnedAnimals()
    {
        foreach(GameObject animal in spawnedAnimals)
        {
            Destroy(animal);
        }
    }

    
    }
