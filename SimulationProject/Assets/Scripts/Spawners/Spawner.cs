using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Jessie Archer, Brandon Lo, and Noel Paredes
public class Spawner : PurchaseObject
{

    [SerializeField] public List<Transform> penSpots;

    [SerializeField] private Spawner penSpawner; 
    [SerializeField]
    private List<ObjectFactory> objects;//A list of available objects to buy (buildings and animals)

    private List<GameObject> spawnedAnimals = new List<GameObject>();//A list of game objects that hold animals

    private List<Animal> animalComponents = new List<Animal>(); //A list of animal components
    [SerializeField]
    private int currentIndex;//The currently selected object

    [SerializeField]
    private GameObject spawnerToDestroy;//The spawner to destroy when building is placed


    private bool isHeld;//A boolean that checks if a menu input is held down
    private int objListLength;//An integer representing the length of the 

    //Start() initializes the objListLength and spawnedAnimals list
    private void Start()
    {
        LocationManager.AddLocation(spawnerToDestroy);
        Debug.Log("Added location");
        objListLength = objects.Count;
    
    }
    // Update is called once per frame
    void Update()
    {
        UpdateAnimals();
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

            if (placeIsHeld && place == 0)
            {
                placeIsHeld = false;

            }else if (!placeIsHeld && isTouchingPen && place == 1)
            {
                if (objects[currentIndex] is Animal && ((Animal)objects[currentIndex]).cost <= MoneyManager.GetCurrentIncome())
                {
                    SpawnAnimal();
                }
                //Building Object Code
                else if (objects[currentIndex] is Building && ((Building)objects[currentIndex]).cost <= MoneyManager.GetCurrentIncome())
                {
                    SpawnBuilding(); 

                }
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
    //SpawnAnimals() spawns an animal object and adds it to a list of spawnedAnimals,
    private void SpawnAnimal()
    {
        ((Animal)objects[currentIndex]).transform.position = gameObject.transform.position;
        GameObject animal = ((Animal)objects[currentIndex]).ReturnSpawnedObject();
        Animal animalComp = animal.GetComponent<Animal>();

        if(currentPlayer != null)
        animalComp.GetBehavior().SetCurrentPlayer(currentPlayer);
        animalComponents.Add(animalComp);
        spawnedAnimals.Add(animal);

        animalComp.SetAnimalLocation(penSpawner);
        MoneyManager.BuyItem(((Animal)objects[currentIndex]).cost);
        placeIsHeld = true;

    }
    //SpawnBuilding() destroys the existing animals at a pen, destroys the spawner,
    //and places the pen at the previous location
    private void SpawnBuilding()
    {
        ((Building)objects[currentIndex]).transform.position = gameObject.transform.position;
        DestroySpawnedAnimals();
        //LocationManager.RemoveLocation(spawnerToDestroy);
        LocationManager.RemoveLocation(this.transform.parent.gameObject);
        Destroy(spawnerToDestroy);
        GameObject building = ((Building)objects[currentIndex]).ReturnSpawnedObject();
        LocationManager.AddLocation(building);
        LocationManager.SetAccessibleLocations();
        MoneyManager.BuyItem(((Building)objects[currentIndex]).cost);
        placeIsHeld = true;
    }
    //Returns the pen's spots to the animal.
    public List<Transform> GetAllSpots()
    {
        return penSpots;
    }

    public bool GetTouchingPen()
    {
        return isTouchingPen; 
    }
        
    private void UpdateAnimals()
    {
        foreach(Animal a in animalComponents)
        {
            if(currentPlayer != null)
            a.GetBehavior().SetCurrentPlayer(currentPlayer);
            a.GetBehavior().SetCanFollowPlayer(isTouchingPen);
        }
    }
}
