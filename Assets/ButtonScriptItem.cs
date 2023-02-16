using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonScriptItem : MonoBehaviour
{
    public int itemId;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;
    private void Update()
    {
        PriceTxt.text = "Price " + ShopManager.GetComponent<ShopManager>().shopItems[2, itemId].ToString();
        QuantityTxt.text =  ShopManager.GetComponent<ShopManager>().shopItems[3, itemId].ToString();
    }
}
