using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Purpose: This is the main CompletableTask script for the laundry puzzle. It handles
starting and ending and all mechanics, it interacts with baskets and items as well
as the interactable.

Author: Jared Israel
 
 */

public class LaundryPuzzle : CompletableTask
{
    [SerializeField]
    private LaundryPuzzleInteractable interactable;
    [SerializeField]
    private PuzzleTimer pt;
    private const float PUZZLE_TIME_LIMIT = 20f;
    [SerializeField]
    private int difficultyLevel;
    [SerializeField]
    private GameObject LaundryItem;
    [SerializeField]
    private Transform ItemInstanPoint;
    private int totalItems;
    private bool itemClicked;
    private bool completed = false;
    private GameObject currentItem;
    [SerializeField]
    private PlayerController pc;


    private void Awake()
    {
        TaskCompletedEvent = new UnityEngine.Events.UnityEvent<CompletableTask>();

    }

    void Start()
    {
        this.description = "Sort the laundry";
        ObjectivesManager.Instance.AddObjective(this);
        interactable.InteractedWith.AddListener(BeginPuzzle);
        pt.TimeRanOutEvent.AddListener(TimeRunOut);
    }

    void BeginPuzzle()
    {
        Cursor.visible = true;
        pt.startTimer(PUZZLE_TIME_LIMIT);
        switch (difficultyLevel)
        {
            case 1:
                totalItems = 5;
                break;
            case 2:
                totalItems = 10;
                break;
            case 3:
                totalItems = 15;
                break;
            default:
                totalItems = 5;
                break;
        }


        StartCoroutine(SpawnItems());

    }

    IEnumerator SpawnItems()
    {
        currentItem = GameObject.Instantiate(LaundryItem, ItemInstanPoint.position, Quaternion.identity);
        itemClicked = false;
        int itemsClicked = 0;
        while(!completed)
        {
            while (!itemClicked)
            {
                if (Input.GetMouseButtonDown(0)) RaycastMouse();
                yield return null;
            }
            itemsClicked++;
            if (itemsClicked >= totalItems) {
                OnGameWin();
                completed = true;
            }
            else
            {
                currentItem = GameObject.Instantiate(LaundryItem, ItemInstanPoint.position, Quaternion.identity);
                itemClicked = false;
            }
        }
    }

    public void RaycastMouse()
    {
        RaycastHit hit;
        Ray ray = pc.cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f, 5, QueryTriggerInteraction.Ignore))
        {
            Transform objectHit = hit.transform;
            LaundryBasket basket = objectHit.gameObject.GetComponent<LaundryBasket>();
            if (basket!=null)
            {
                switch (basket.color)
                {
                    case BasketColor.Black:
                        onClickBlack(basket);
                        break;
                    case BasketColor.White:
                        onClickWhite(basket);
                        break;
                    case BasketColor.Red:
                        onClickRed(basket);
                        break;
                    case BasketColor.Green:
                        onClickGreen(basket);
                        break;
                    case BasketColor.Blue:
                        onClickBlue(basket);
                        break;
                }
            }
        }


    }

    /*

    All of the onClick methods here have repeated code, but I think this might be
    good to have when we start introducing difficulty mechanisms later on. If it
    is not, we can easily refactor to take in an extra param that is the color

     */

    private void onClickBlack(LaundryBasket basket)
    {
        LaundryItem li = currentItem.GetComponent<LaundryItem>();
        if (li.color == BasketColor.Black)
        {
            li.moveToPosition(basket.transform);
            itemClicked = true;
        }
        else
        {
            li.ShakeAnimate();
        }
    }

    private void onClickWhite(LaundryBasket basket)
    {
        LaundryItem li = currentItem.GetComponent<LaundryItem>();
        if (li.color == BasketColor.White)
        {
            li.moveToPosition(basket.transform);
            itemClicked = true;
        }
        else
        {
            li.ShakeAnimate();
        }
    }

    private void onClickRed(LaundryBasket basket)
    {
        LaundryItem li = currentItem.GetComponent<LaundryItem>();
        if (li.color == BasketColor.Red)
        {
            li.moveToPosition(basket.transform);
            itemClicked = true;
        }
        else
        {
            li.ShakeAnimate();
        }
    }

    private void onClickGreen(LaundryBasket basket)
    {
        LaundryItem li = currentItem.GetComponent<LaundryItem>();
        if (li.color == BasketColor.Green)
        {
            li.moveToPosition(basket.transform);
            itemClicked = true;
        }
        else
        {
            li.ShakeAnimate();
        }
    }

    private void onClickBlue(LaundryBasket basket)
    {
        LaundryItem li = currentItem.GetComponent<LaundryItem>();
        if (li.color == BasketColor.Blue)
        {
            li.moveToPosition(basket.transform);
            itemClicked = true;
        }
        else
        {
            li.ShakeAnimate();
        }
    }

    void TimeRunOut()
    {
        Cursor.visible = false;
        currentItem.gameObject.SetActive(false);
        completed = false;
        StopAllCoroutines();
        interactable.MoveBackToInitialPosition();
        pt.DisableTimer();
        interactable.ResetInteract();
        
        Debug.Log("Ran out of time");
    }

    void OnGameWin()
    {
        Cursor.visible = false;
        completed = true;
        interactable.MoveBackToInitialPosition();
        pt.DisableTimer();
        TaskCompletedEvent.Invoke(this);
        Debug.Log("Completed");
    }

}
