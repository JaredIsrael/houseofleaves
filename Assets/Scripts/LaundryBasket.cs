using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*

Purpose: This script is for the landry baskets of the laundry puzzle, it holds
data for each basket

Author: Jared Israel

 */

public enum BasketColor
{
    Black,
    White,
    Red,
    Green,
    Blue
}


public class LaundryBasket : MonoBehaviour
{
    public BasketColor color;

}
