using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject _shopUI;
    public int selectedItem;
    public int selectedItemCost;
    private Player _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            if(_player != null)
            {
                UIManager.Instance.OpenShop(_player.diamonds);
            }
            
            _shopUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _shopUI.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        Debug.Log("Selected item: " + item);

        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(64);
                selectedItem = 0;
                selectedItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-32);
                selectedItem = 1;
                selectedItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-136);
                selectedItem = 2;
                selectedItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if(_player.diamonds >= selectedItemCost)
        {
            //award item
            if(selectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            _player.diamonds -= selectedItemCost;
            UIManager.Instance.UpdateGemCount(_player.diamonds);
            _shopUI.SetActive(false);
        }
        else
        {
            //not enough gems
            _shopUI.SetActive(false);
        }
    }
}
