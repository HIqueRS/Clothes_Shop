using GlobalConfigurations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{

    public ClothingScriptable _equipedHair;
    public ClothingScriptable _equipedShirt;
    public ClothingScriptable _equipedPants;

    public SpriteRenderer _renderHair;
    public SpriteRenderer _renderShirt;
    public SpriteRenderer _renderPants;

    public List<ClothingScriptable> _myClothes;

    public GameObject _inventoryUI;
    public GameObject _inventoryUIContent;
    public GameObject _inventoryUIButton;

    [Space]
    public Image _previewHair;
    public Image _previewShirt;
    public Image _previewPants;

    public ClothingScriptable _blank;
    public GameObject _panel;

    private List<GameObject> _buttons;

    // Start is called before the first frame update
    void Start()
    {
        InitiateList();
        LoadClothes();

        //LoadInventory();
    }

    // Update is called once per frame
    void Update()
    {
        OpenInventory();
    }

    public void LoadClothes()
    {
        
        _renderHair.sprite = Resources.LoadAll<Sprite>(_equipedHair._path)[_equipedHair._index];
        _renderShirt.sprite = Resources.LoadAll<Sprite>(_equipedShirt._path)[_equipedShirt._index];
        _renderPants.sprite = Resources.LoadAll<Sprite>(_equipedPants._path)[_equipedPants._index];
    }

    private void InitiateList()
    {
        _myClothes = new List<ClothingScriptable>
        {
            _equipedHair,
            _equipedShirt,
            _equipedPants
        };
    }

    private void OpenInventory()
    {
        if(!_panel.activeSelf) 
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                _panel.SetActive(true);
                LoadInventory();
            }   
        }
    }

    private void LoadInventory()
    {
        InstantiateButtons();
        LoadPreview();
    }

    private void LoadPreview()
    {
        _previewHair.sprite = _equipedHair._sprite;
        _previewShirt.sprite = _equipedShirt._sprite;
        _previewPants.sprite = _equipedPants._sprite;
    }

    public void CloseButtons()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            Destroy(_buttons[i]);
        }
    }

    private void InstantiateButtons()
    {
        GameObject aux;
        ButtonClothe aux_button;

        _buttons = new List<GameObject>();

        foreach (ClothingScriptable clothes in _myClothes)
        {

            aux = GameObject.Instantiate(_inventoryUIButton, _inventoryUIContent.transform);

            _buttons.Add(aux);

            aux_button = aux.GetComponent<ButtonClothe>();

            aux_button.PassScriptable(clothes);

            aux_button.PassInventory(this);

            aux_button.LoadScriptable();

        }
    }

    public ClothingScriptable GetEquiped(Category category)
    {
        switch (category)
        {
            case Category.Hair: return  _equipedHair;
                
            case Category.Shirt: return _equipedShirt;
                
            case Category.Pants: return _equipedPants;
                
            default: return null;
        }
    }

    public void Unequip(Category category)
    {
        switch (category)
        {
            case Category.Hair: _equipedHair = _blank;
                
                break;
            case Category.Shirt: _equipedShirt = _blank;
                
                break;
            case Category.Pants: _equipedPants = _blank;
                
                break;
            default:
                break;
        }

        LoadPreview();

    }

    public void Equip(ClothingScriptable clothing,Category category)
    {
        switch (category)
        {
            case Category.Hair:
                _equipedHair = clothing;
               
                break;
            case Category.Shirt:
                _equipedShirt = clothing;
                break;
            case Category.Pants:
                _equipedPants = clothing;
                break;
            default:
                break;
        }

        LoadPreview();
    }
}
