using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//Code by Jessie Archer, Brandon Lo, and Noel Paredes
public class Spawner : PurchaseObject
{

    [SerializeField] public List<Transform> penSpots;//A list of waypoints within the current pen

    [SerializeField] private Spawner penSpawner;//The spawner object of pen 
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
    private Vector3 spawnLocation;
    //Start() initializes the objListLength and spawnedAnimals list
    private void Start()
    {
        LocationManager.AddLocation(spawnerToDestroy);
        Debug.Log("Added location");
        objListLength = objects.Count;
        spawnLocation = this.gameObject.transform.position;
    
    }
    // Update is called once per frame
    void Update()
    {
        UpdateAnimals();
        DisplayCurrentObject();
        Debug.Log("About to Spawn");
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
        //Null check for player
        if (currentPlayer != null && currentPlayer.GetView().IsMine )
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
        if (currentPlayer != null && currentPlayer.GetView().IsMine)
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
            PhotonNetwork.Destroy(animal);
            Destroy(animal);
        }
    }
    //SpawnAnimals() spawns an animal object and adds it to a list of spawnedAnimals,
    private void SpawnAnimal()
    {
        //Animal is spawned and animal component is saved
        ((Animal)objects[currentIndex]).transform.position = gameObject.transform.position;


        GameObject animal = ((Animal)objects[currentIndex]).ReturnSpawnedObject(((Animal)objects[currentIndex]).prefabName, spawnLocation);
        Animal animalComp = animal.GetComponent<Animal>();
        
        //If-statement performs null check and updates the animal component to
        //the current player in pen radius. 
        if(currentPlayer != null)
        animalComp.GetBehavior().SetCurrentPlayer(currentPlayer);
      
        //Spawned Animal and its component are added to lists 
        animalComponents.Add(animalComp);
        spawnedAnimals.Add(animal);
        //AI location is set
        animalComp.SetAnimalLocation(penSpawner);
        //Animal price is deducted from money 
        MoneyManager.BuyItem(((Animal)objects[currentIndex]).cost);
        placeIsHeld = true;

    }
    //SpawnBuilding() destroys the existing animals at a pen, destroys the spawner,
    //and places the pen at the previous location
    private void SpawnBuilding()
    {
        //Building location is set
        ((Building)objects[currentIndex]).transform.position = gameObject.transform.position;

        //Animals are destroyed, pen location is removed from list for visitors,
        //and spawner is destroyed
        DestroySpawnedAnimals();
        LocationManager.RemoveLocation(this.transform.parent.gameObject);
        PhotonNetwork.Destroy(spawnerToDestroy);
        Destroy(spawnerToDestroy);

        //Building is spawned, added to visitor location list, and purchased. 
        GameObject building = ((Building)objects[currentIndex]).ReturnSpawnedObject(((Building)objects[currentIndex]).prefabName, spawnLocation);
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

    //GetTouchingPen() is a public getter method that 
    public bool GetTouchingPen()
    {
        return isTouchingPen; 
    }

    //UpdateAnimals() notifies all spawned animals in the pen about whether the
    //player has entered the pen and can be followed
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
