using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GlobalConfigurations;

public class PlayerEquiped : MonoBehaviour
{
    [SerializeField]
    private ClothingScriptable _equipedHair;
    [SerializeField]
    private ClothingScriptable _equipedShirt;
    [SerializeField]
    private ClothingScriptable _equipedPants;

    [Space(20)]
    [SerializeField]
    public List<ClothingScriptable> _myClothes;

    [Space(20)]
    [SerializeField]
    private int _money;

    [Space(20)]
    [Header("Sprite renderer")]
    [SerializeField]
    private SpriteRenderer _renderHair;
    [SerializeField]
    private SpriteRenderer _renderShirt;
    [SerializeField]
    private SpriteRenderer _renderPants;

    [Space(20)]
    [Header("Preview")]
    [SerializeField]
    private bool _isPreview;
    [SerializeField]
    private Image _imageHair;
    [SerializeField]
    private Image _imageShirt;
    [SerializeField]
    private Image _imagePants;


    [SerializeField]
    private ClothingScriptable _blankHair;
    [SerializeField]
    private ClothingScriptable _blankShirt;
    [SerializeField]
    private ClothingScriptable _blankPants;
    // Start is called before the first frame update
    void Start()
    {
        if(_isPreview == false)
        {
            LoadClothes();
            LoadList();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public List<ClothingScriptable> GetListClothes()
    {
        return _myClothes;
    }

    private void LoadClothes()
    {
        _renderHair.sprite = _equipedHair._sprite;
        _renderShirt.sprite = _equipedShirt._sprite;
        _renderPants.sprite = _equipedPants._sprite;
    }
    private void LoadPreview()
    {
        _imageHair.sprite = _equipedHair._sprite;
        _imageShirt.sprite = _equipedShirt._sprite;
        _imagePants.sprite = _equipedPants._sprite;
    }



    private void LoadList()
    {
        _myClothes = new List<ClothingScriptable>
        {
            _equipedHair,
            _equipedShirt,
            _equipedPants
        };
    }

    public void Unequip(Category category)
    {
        switch (category)
        {
            case Category.Hair:
                _equipedHair = _blankHair;
                break;
            case Category.Shirt:
                _equipedShirt = _blankShirt;
                break;
            case Category.Pants:
                _equipedPants = _blankPants;
                break;
            default:
                break;
        }

        LoadPreview();
    }

    public void Equip(ClothingScriptable clothe)
    {
        switch (clothe._category)
        {
            case Category.Hair: _equipedHair = clothe;
                break;
            case Category.Shirt: _equipedShirt = clothe;
                break;
            case Category.Pants: _equipedPants = clothe;
                break;
            default:
                break;
        }

        AddOnMyClothes(clothe);
        ChangeVisualization(clothe);
    }

    public void AddOnMyClothes(ClothingScriptable clothe)
    {
        if(_myClothes.Contains(clothe) == false && clothe._name != "Blank")
        {
            _myClothes.Add(clothe);
        }
    }

    public void ReduceMoney(int i)
    {
        _money -= i;
    }

    public void AddMoney(int i)
    {
        _money += i;
    }

    private void ChangeVisualization(ClothingScriptable clothe)
    {
        if (_isPreview)
        {
            ChangePreview(clothe);
        }
        else 
        {
            ChangePlayer(clothe);
        }
    }

    private void ChangePlayer(ClothingScriptable clothe)
    {
        switch (clothe._category)
        {
            case Category.Hair: _renderHair.sprite = clothe._sprite;
                break;
            case Category.Shirt:  _renderShirt.sprite = clothe._sprite;
                break;
            case Category.Pants:  _renderPants.sprite = clothe._sprite;
                break;
        }
    }
    private void ChangePreview(ClothingScriptable clothe)
    {
        switch (clothe._category)
        {
            case Category.Hair: _imageHair.sprite = clothe._sprite;
                break;
            case Category.Shirt: _imageShirt.sprite = clothe._sprite;
                break;
            case Category.Pants: _imagePants.sprite = clothe._sprite;
                break;
        }
    }

    public ClothingScriptable GetEquiped(Category category)
    {
        switch (category)
        {
            case Category.Hair: return _equipedHair;

            case Category.Shirt: return _equipedShirt;

            case Category.Pants: return _equipedPants;

            default: return null;
        }
    }

    public int GetMoney()
    {
        return _money;
    }
}
