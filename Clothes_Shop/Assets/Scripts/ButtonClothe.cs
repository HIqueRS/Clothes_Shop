using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GlobalConfigurations;
using static Unity.Burst.Intrinsics.X86;

public class ButtonClothe : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _clotheName;
    [SerializeField]
    private TMPro.TextMeshProUGUI _clotheCost;
    [SerializeField]
    private Image _clotheIcon;

    [SerializeField]
    private ClothingScriptable _clothingScriptable;

  
    [SerializeField]
    private BaseInventory _baseInventory;

    [SerializeField]
    private bool _isInventory; 
    [SerializeField]
    private bool _isSelling; 

    public void PassScriptable(ClothingScriptable clothingScriptable)
    {
        _clothingScriptable = clothingScriptable;
        LoadScriptable();
    }

    public void LoadScriptable()
    {
        _clotheName.text = _clothingScriptable.name;
        _clotheCost.text = string.Concat("$", _clothingScriptable._cost.ToString());
        _clotheIcon.sprite = _clothingScriptable._sprite;
    }

   
     public void PassBaseInventory(BaseInventory baseInventory)
    {
        _baseInventory = baseInventory;
    }

    

    public void OnButtonPressed()
    {        
        if(_isInventory)
        {
            InventoryButton();
        }
        else
        {
            if(_isSelling == false)
            {
                ShopkeeperButton();
            }
            else
            {
                SellingButton();
            }
        }        
    }


    public void SetActiveInventory(bool bolean)
    {
        _isInventory = bolean;
    }

    public void SetActiveSelling(bool bolean)
    {
        _isSelling = bolean;
    }

    private void SellingButton()
    {
        
        _baseInventory.AddSellingList(_clothingScriptable);

        ClothingScriptable aux;

        aux = _baseInventory.GetClothingByCategory(_clothingScriptable._category);

        if (_clothingScriptable.name == aux.name)
        {
            _baseInventory.UnequipPreview(_clothingScriptable._category);
        }

       

        Destroy(this.gameObject);
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
