using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowForShop : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        if (gameObject.name == "NameCoinsOff") 
        {
            ShopIndex(0);
        }
        else if (gameObject.name == "NameTrickOff")
        {
            ShopIndex(2);
        }
        else if (gameObject.name == "NameSkinsOff")
        {
            ShopIndex(1);
        }
        else if (Buttons.PromoCodeMenu)
        {
            ShopMenu.indexShopItem = 3;
            Debug.Log(ShopMenu.indexShopItem);
        }
    }

    void ShopIndex(int index)
    {
        ShopMenu.indexShopItem = index;
        Debug.Log(ShopMenu.indexShopItem);
        Buttons.PromoCodeMenu = false;
        Buttons.Shop = true;
    }
}
