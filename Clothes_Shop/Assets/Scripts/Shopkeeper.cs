using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GlobalConfigurations;

public class Shopkeeper : MonoBehaviour
{
    public List<ClothingScriptable> _storeItens;

    public Inventory _inventory;

    public GameObject _panel;

    private List<GameObject> _buttons;

    public Image _previewHair;
    public Image _previewShirt;
    public Image _previewPants;

    public GameObject _inventoryUIContent;
    public GameObject _inventoryUIButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenShop();
    }

    private void OpenShop()
    {
        if (!_panel.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                _panel.SetActive(true);
                LoadShop();
            }
        }
    }

    private void LoadShop()
    {
        InstantiateButtons();
        LoadPreview();
    }

    private void InstantiateButtons()
    {
        GameObject aux;
        ButtonClothe aux_button;

        _buttons = new List<GameObject>();

        foreach (ClothingScriptable clothes in _storeItens)
        {

            aux = GameObject.Instantiate(_inventoryUIButton, _inventoryUIContent.transform);

            _buttons.Add(aux);

            aux_button = aux.GetComponent<ButtonClothe>();

            aux_button.PassScriptable(clothes);

            aux_button.PassInventory(_inventory);
            aux_button.PassShopkeeper(this);

            aux_button.LoadScriptable();

            aux_button.SetActiveInventory(false);

        }
    }

    private void LoadPreview()
    {
        _previewHair.sprite = _inventory.GetEquiped(Category.Hair)._sprite;
        _previewShirt.sprite = _inventory.GetEquiped(Category.Shirt)._sprite;
        _previewPants.sprite = _inventory.GetEquiped(Category.Pants)._sprite;
    }


}
