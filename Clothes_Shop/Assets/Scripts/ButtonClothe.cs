using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GlobalConfigurations;
using static Unity.Burst.Intrinsics.X86;

public class ButtonClothe : MonoBehaviour
{
    public TMPro.TextMeshProUGUI _clotheName;
    public TMPro.TextMeshProUGUI _clotheCost;
    public Image _clotheIcon;

    public ClothingScriptable _clothingScriptable;

    public Inventory _inventory;
    public Shopkeeper _shopkeeper;
    public BaseInventory _baseInventory;

    public bool _isInventory; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PassScriptable(ClothingScriptable clothingScriptable)
    {
        _clothingScriptable = clothingScriptable;
        LoadScriptable();
    }

    public void LoadScriptable()
    {
        _clotheName.text = _clothingScriptable.name;
        _clotheCost.text = _clothingScriptable._cost.ToString();
        _clotheIcon.sprite = _clothingScriptable._sprite;
    }

    public void PassInventory(Inventory inventory)
    {
        _inventory = inventory;
    }
     public void PassBaseInventory(BaseInventory baseInventory)
    {
        _baseInventory = baseInventory;
    }

    public void PassShopkeeper(Shopkeeper shopkeeper)
    {
        _shopkeeper = shopkeeper;

    }

    public void OnButtonPressed()
    {        
        if(_isInventory)
        {
            InventoryButton();
        }
        else
        {
            ShopkeeperButton();
        }        
    }

    public void SetActiveInventory(bool bolean)
    {
        _isInventory = bolean;
    }

    private void InventoryButton()
    {
        ClothingScriptable aux;

        aux = _baseInventory.GetClothingByCategory(_clothingScriptable._category);

        if (_clothingScriptable.name == aux.name)
        {
            _baseInventory.UnequipPreview(_clothingScriptable._category);
        }
        else
        {
            _baseInventory.EquipPreview(_clothingScriptable);
        }
    }

    private void ShopkeeperButton()
    {
        ClothingScriptable aux;

        aux = _baseInventory.GetClothingByCategory(_clothingScriptable._category);

        if (_clothingScriptable.name == aux.name)
        {
            _baseInventory.UnequipPreview(_clothingScriptable._category);
        }
        else
        {
            _baseInventory.EquipPreview(_clothingScriptable);
        }
        
        _baseInventory.SumPreview();
    }

   
}
