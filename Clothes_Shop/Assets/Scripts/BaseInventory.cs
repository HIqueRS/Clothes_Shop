using GlobalConfigurations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalConfigurations;
using Unity.VisualScripting;

public class BaseInventory : MonoBehaviour
{

    [SerializeField]
    protected GameObject _panel;
    [SerializeField]
    protected KeyCode _openPanel;

    [SerializeField]
    protected List<ClothingScriptable> _clothes;

    protected ClothingScriptable _lastHair;
    protected ClothingScriptable _lastShirt;
    protected ClothingScriptable _lastPants;

    [SerializeField]
    protected PlayerEquiped _player;
    [SerializeField]
    protected PlayerEquiped _preview;

    protected List<GameObject> _buttons;

    [SerializeField]
    protected GameObject _inventoryUIContent;
    [SerializeField]
    protected GameObject _inventoryUIButton;

    [SerializeField]
    private bool _isInventory;


    [SerializeField]
    protected ClothingScriptable _blank;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenUI();
    }

    private void OpenUI()
    {
        if (!_panel.activeSelf)
        {
            if (Input.GetKeyDown(_openPanel))
            {
                _panel.SetActive(true);
                LoadInventory();
               // SetLastSprite();

            }
        }
    }
    private void LoadInventory()
    {
        if(_isInventory)
        {
            LoadClothes();
        }
        InstantiateButtons();
        LoadPreview();
    }

    public ClothingScriptable GetClothingByCategory(Category category)
    {

        return _preview.GetEquiped(category);
    }

    private void LoadPreview()
    {
        _preview.Equip(_player.GetEquiped(Category.Hair));
        _preview.Equip(_player.GetEquiped(Category.Shirt));
        _preview.Equip(_player.GetEquiped(Category.Pants));
    }
    public void LoadPlayer()
    {
        _player.Equip(_preview.GetEquiped(Category.Hair));
        _player.Equip(_preview.GetEquiped(Category.Shirt));
        _player.Equip(_preview.GetEquiped(Category.Pants));
    }

    private void LoadClothes()
    {
        _clothes = _player.GetListClothes();
    }

    private void InstantiateButtons()
    {
        GameObject aux;
        ButtonClothe aux_button;       

        _buttons = new List<GameObject>();

        foreach (ClothingScriptable clothes in _clothes)
        {
            aux = GameObject.Instantiate(_inventoryUIButton, _inventoryUIContent.transform);

            _buttons.Add(aux);

            aux_button = aux.GetComponent<ButtonClothe>();

            aux_button.PassScriptable(clothes);

            aux_button.PassBaseInventory(this);

            aux_button.SetActiveInventory(_isInventory);
        }
    }

    public void EquipPreview(ClothingScriptable clothing)
    {
        _preview.Equip(clothing);
    }
    public void UnequipPreview(Category category)
    {
        _preview.Unequip(category);
    }

    public void CloseButtons()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            Destroy(_buttons[i]);
        }

        _buttons.Clear();
    }


}
