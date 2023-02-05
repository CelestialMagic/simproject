using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField]
    private GameObject[] menuTypes;
    [SerializeField]
    private GameObject playerToListen;

    public delegate void MenuAction();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InputManager pInput = playerToListen.GetComponent("InputManager") as InputManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (pInput.Notify() != null)
        {
            MenuAction open = menuTypes[0].Open();
        }
    }

    public void Open()
    {

    }

    public void Close()
    {

    }
}
