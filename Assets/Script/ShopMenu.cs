using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class ShopMenu : MonoBehaviour
{
    public static int indexShopItem;
    public Text shopName;
    public GameObject[] menuCoins = new GameObject[3];
    public GameObject[] lenghtItem = new GameObject[10];
    public GameObject[] allTricks = new GameObject[10];
    public GameObject[] allTshirt = new GameObject[4];
    public Text[] textPack = new Text[3];
    public GameObject CoinsOn, CoinsOff, TrickOn, TrickOff, SkinsOn, SkinsOff;
    public Text[] price = new Text[8];
    private PostProcessVolume _postProcessVolume;
    private Bloom _bloom;
    public GameObject MenuTextCoins;
    public GameObject PromoBtnMenuNotActive;
    public GameObject PromoBtnMenuActive;
    public GameObject shopMenuActive;
    public GameObject PromoMenu;
    public GameObject MenuGcoins;
    public Image MenuCoinsI;
    public GameObject MenuCoinsT;
    public GameObject MenuCoins1;
    public GameObject MoneyCountShop;

    public GameObject ZakeLogo;

    void Start()
    {
        indexShopItem = 0;
        // _postProcessVolume = GetComponent<PostProcessVolume>();
        // _postProcessVolume.profile.TryGetSettings(out _bloom);
        
        // PlayerPrefs.SetInt("TrickMethod", 0);
        // PlayerPrefs.SetInt("TrickMethodPick", 0);
        // PlayerPrefs.SetInt("TrickNollie", 0);
        // PlayerPrefs.SetInt("TrickNolliePick", 0);
        // PlayerPrefs.SetInt("TrickNollieFlip", 0);
        // PlayerPrefs.SetInt("TrickNollieFlipPick", 0);
        // PlayerPrefs.SetInt("TrickChrist", 0);
        // PlayerPrefs.SetInt("TrickChristPick", 0);
        if (PlayerPrefs.GetInt("Tshirt2Pick") != 1 && PlayerPrefs.GetInt("Tshirt3Pick") != 1 &&
            PlayerPrefs.GetInt("Tshirt4Pick") != 1)
        {
            PlayerPrefs.SetInt("Tshirt1", 1);
            PlayerPrefs.SetInt("Tshirt1Pick", 1);
        }
    }

    void Update()
    {
        if (Buttons.Shop || Buttons.PromoCodeMenu)
        {
            // MenuBackCoins.SetActive(false);
            MenuTextCoins.SetActive(false);
            //MenuCoins.SetActive(false);
            MenuGcoins.SetActive(false);
        }
        else
        {
            // MenuBackCoins.SetActive(true);
            MenuTextCoins.SetActive(true);
            //MenuCoins.SetActive(true);
            MenuGcoins.SetActive(true);
        }

        if (Buttons.Shop)
        {
            MenuCoins1.SetActive(false);
            MenuCoinsI.enabled = false;
            MenuCoinsT.SetActive(false);
            MenuGcoins.SetActive(false);
            PromoBtnMenuNotActive.SetActive(true);
            PromoBtnMenuActive.SetActive(false);
            shopMenuActive.SetActive(true);
            PromoMenu.SetActive(false);
            MoneyCountShop.SetActive(true);
        }
        else if (Buttons.PromoCodeMenu)
        {
            PromoBtnMenuNotActive.SetActive(true);
            PromoBtnMenuActive.SetActive(false);
            shopMenuActive.SetActive(false);
            PromoMenu.SetActive(true);
            MoneyCountShop.SetActive(true);
        }
        else
        {
            MoneyCountShop.SetActive(false);
            MenuCoins1.SetActive(true);
            MenuCoinsI.enabled = true;
            MenuCoinsT.SetActive(true);
            MenuGcoins.SetActive(true);
        }
        
        if (indexShopItem == 0)
        {
            // shopName.text = "COINS";
            CoinsOn.SetActive(true);
            CoinsOff.SetActive(false);
            TrickOn.SetActive(false);
            TrickOff.SetActive(true);
            SkinsOn.SetActive(false);
            SkinsOff.SetActive(true);
            
            for (int i = 0; i < menuCoins.Length; i++)
            {
                menuCoins[i].SetActive(true);
            }

            for (int i = 0; i < 3; i++)
            {
                lenghtItem[i].SetActive(true);
            }

            for (int i = 3; i < 10; i++)
            {
                lenghtItem[i].SetActive(false);
            }
            
            // for (int i = 0; i < 2; i++)
            // {
            //     lenghtItem[i].SetActive(false);
            // }
            
            for (int i = 0; i < 3; i++)
            {
                price[i].text = i + ".99$";
            }

            for (int i = 0; i < allTricks.Length; i++)
            {
                allTricks[i].SetActive(false);
            }
            
            for (int i = 0; i < allTshirt.Length; i++)
            {
                allTshirt[i].SetActive(false);
            }
        }
        else if (indexShopItem == 1)
        {
            // shopName.text = "SKINS";
            CoinsOn.SetActive(false);
            CoinsOff.SetActive(true);
            TrickOn.SetActive(false);
            TrickOff.SetActive(true);
            SkinsOn.SetActive(true);
            SkinsOff.SetActive(false);
            for (int i = 0; i < menuCoins.Length; i++)
            {
                menuCoins[i].SetActive(false);
            }
            
            for (int i = 0; i < 4; i++)
            {
                lenghtItem[i].SetActive(true);
            }
            
            for (int i = 4; i < 10; i++)
            {
                lenghtItem[i].SetActive(false);
            }
            
            for (int i = 0; i < allTricks.Length; i++)
            {
                allTricks[i].SetActive(false);
            }
            
            for (int i = 0; i < allTshirt.Length; i++)
            {
                allTshirt[i].SetActive(true);
            }
            
            for (int i = 1; i < 4; i++)
            {
                price[i].text = "10";
            }

            for (int i = 0; i < allTshirt.Length; i++)
            {
                if (i == 0 && PlayerPrefs.GetInt("Tshirt1") == 1 && PlayerPrefs.GetInt("Tshirt1Pick") != 1 && indexShopItem == 1)
                {
                    price[i].text = "Choose";
                } else if (i == 0 && PlayerPrefs.GetInt("Tshirt1") == 1 && PlayerPrefs.GetInt("Tshirt1Pick") == 1 &&
                           indexShopItem == 1)
                {
                    price[i].text = "Picked";
                }
                
                if (i == 1 && PlayerPrefs.GetInt("Tshirt2") == 1 && PlayerPrefs.GetInt("Tshirt2Pick") != 1 && indexShopItem == 1)
                {
                    price[i].text = "Choose";
                } else if (i == 1 && PlayerPrefs.GetInt("Tshirt2") == 1 && PlayerPrefs.GetInt("Tshirt2Pick") == 1 &&
                           indexShopItem == 1)
                {
                    price[i].text = "Picked";
                }
                else if (i == 1 && PlayerPrefs.GetInt("Tshirt2") != 1 && PlayerPrefs.GetInt("Tshirt2Pick") != 1 &&
                         indexShopItem == 1)
                {
                    price[i].text = "10";
                }
                
                if (i == 2 && PlayerPrefs.GetInt("Tshirt3") == 1 && PlayerPrefs.GetInt("Tshirt3Pick") != 1 && indexShopItem == 1)
                {
                    price[i].text = "Choose";
                } else if (i == 2 && PlayerPrefs.GetInt("Tshirt3") == 1 && PlayerPrefs.GetInt("Tshirt3Pick") == 1 &&
                           indexShopItem == 1)
                {
                    price[i].text = "Picked";
                }
                else if (i == 2 && PlayerPrefs.GetInt("Tshirt3") != 1 && PlayerPrefs.GetInt("Tshirt3Pick") != 1 &&
                         indexShopItem == 1)
                {
                    price[i].text = "10";
                }
                
                if (i == 3 && PlayerPrefs.GetInt("Tshirt4") == 1 && PlayerPrefs.GetInt("Tshirt4Pick") != 1 && indexShopItem == 1)
                {
                    price[i].text = "Choose";
                } else if (i == 3 && PlayerPrefs.GetInt("Tshirt4") == 1 && PlayerPrefs.GetInt("Tshirt4Pick") == 1 &&
                           indexShopItem == 1)
                {
                    price[i].text = "Picked";
                }
                else if (i == 3 && PlayerPrefs.GetInt("Tshirt4") != 1 && PlayerPrefs.GetInt("Tshirt4Pick") != 1 &&
                         indexShopItem == 1)
                {
                    price[i].text = "10";
                }
            }
        } 
        else if (indexShopItem == 2)
        {
            // shopName.text = "TRICKS";
            CoinsOn.SetActive(false);
            CoinsOff.SetActive(true);
            TrickOn.SetActive(true);
            TrickOff.SetActive(false);
            SkinsOn.SetActive(false);
            SkinsOff.SetActive(true);

            for (int i = 0; i < menuCoins.Length; i++)
            {
                menuCoins[i].SetActive(false);
            }

            for (int i = 0; i < 10; i++)
            {
                lenghtItem[i].SetActive(true);
            }

            for (int i = 0; i < allTricks.Length; i++)
            {
                allTricks[i].SetActive(true);
            }

            for (int i = 0; i < allTshirt.Length; i++)
            {
                allTshirt[i].SetActive(false);
            }

            for (int i = 0; i < price.Length; i++)
            {
                price[i].text = "10";
            }

            for (int i = 0; i < price.Length; i++)
            {
                if (i == 0 && PlayerPrefs.GetInt("TrickOllieFlip") == 1 && indexShopItem == 2)
                {
                    price[i].text = "Used";
                }
                else if (i == 0 && PlayerPrefs.GetInt("TrickOllieFlip") != 1 && indexShopItem == 2)
                {
                    price[i].text = "10";
                }
                
                if (i == 1 && PlayerPrefs.GetInt("TrickImpossible") == 1 && indexShopItem == 2)
                {
                    price[i].text = "Used";
                }
                else if (i == 1 && PlayerPrefs.GetInt("TrickImpossible") != 1 && indexShopItem == 2)
                {
                    price[i].text = "10";
                } 
                
                if (i == 2 && PlayerPrefs.GetInt("TrickMethod") == 1 && indexShopItem == 2)
                {
                    price[i].text = "Used";
                }
                else if (i == 2 && PlayerPrefs.GetInt("TrickMethod") != 1 && indexShopItem == 2)
                {
                    price[i].text = "10";
                }

                if (i == 3 && PlayerPrefs.GetInt("TrickNollie") == 1 && indexShopItem == 2)
                {
                    price[i].text = "Used";
                }
                else if (i == 3 && PlayerPrefs.GetInt("TrickNollie") != 1 && indexShopItem == 2)
                {
                    price[i].text = "10";
                }

                if (i == 4 && PlayerPrefs.GetInt("TrickNollieFlip") == 1 && indexShopItem == 2)
                {
                    price[i].text = "Used";
                }
                else if (i == 4 && PlayerPrefs.GetInt("TrickNollieFlip") != 1 && indexShopItem == 2)
                {
                    price[i].text = "10";
                }

                if (i == 5 && PlayerPrefs.GetInt("TrickChrist") == 1 && indexShopItem == 2)
                {
                    price[i].text = "Used";
                }
                else if (i == 5 && PlayerPrefs.GetInt("TrickChristFlip") != 1 && indexShopItem == 2)
                {
                    price[i].text = "10";
                }
                
                if (i == 6 && PlayerPrefs.GetInt("TrickBenihana") == 1 && indexShopItem == 2)
                {
                    price[i].text = "Used";
                }
                else if (i == 6 && PlayerPrefs.GetInt("TrickBenihana") != 1 && indexShopItem == 2)
                {
                    price[i].text = "10";
                }
                
                if (i == 7 && PlayerPrefs.GetInt("Trick360") == 1 && indexShopItem == 2)
                {
                    price[i].text = "Used";
                }
                else if (i == 7 && PlayerPrefs.GetInt("Trick360") != 1 && indexShopItem == 2)
                {
                    price[i].text = "10";
                }

                if (i == 8 && PlayerPrefs.GetInt("Trick360Christ") == 1 && indexShopItem == 2)
                {
                    price[i].text = "Used";
                }
                else if (i == 8 && PlayerPrefs.GetInt("Trick360Christ") != 1 && indexShopItem == 2)
                {
                    price[i].text = "10";
                }
                
                if (i == 9 && PlayerPrefs.GetInt("TrickBackFlip") == 1 && indexShopItem == 2)
                {
                    price[i].text = "Used";
                }
                else if (i == 9 && PlayerPrefs.GetInt("TrickBackFlip") != 1 && indexShopItem == 2)
                {
                    price[i].text = "10";
                }
            }
        } 
        else if (indexShopItem == 3)
        {
            CoinsOn.SetActive(false);
            CoinsOff.SetActive(true);
            TrickOn.SetActive(false);
            TrickOff.SetActive(true);
            SkinsOn.SetActive(false);
            SkinsOff.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("Tshirt1Pick") == 1 && !Buttons.Shop && !Buttons.PromoCodeMenu)
        {

        } else if (PlayerPrefs.GetInt("Tshirt2Pick") == 1 && !Buttons.Shop && !Buttons.PromoCodeMenu)
        {
            
        } else if (PlayerPrefs.GetInt("Tshirt3Pick") == 1 && !Buttons.Shop && !Buttons.PromoCodeMenu)
        {

        } else if (PlayerPrefs.GetInt("Tshirt4Pick") == 1 && !Buttons.Shop && !Buttons.PromoCodeMenu)
        {

        }
    }
}
