using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        InitiateList();
        //LoadClothes();

        LoadInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadClothes()
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
        
    }

    private void LoadInventory()
    {
        GameObject aux;
        ButtonClothe aux_button;
        foreach (ClothingScriptable clothes in _myClothes)
        {

            aux = GameObject.Instantiate(_inventoryUIButton, _inventoryUIContent.transform);

            aux_button = aux.GetComponent<ButtonClothe>();

            aux_button.PassScriptable(clothes);

            aux_button.LoadScriptable();

        }
    }
}
