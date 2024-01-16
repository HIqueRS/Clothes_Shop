using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public ClothingScriptable _equipedHair;
    public ClothingScriptable _equipedShirt;
    public ClothingScriptable _equipedPants;

    public SpriteRenderer _renderHair;
    public SpriteRenderer _renderShirt;
    public SpriteRenderer _renderPants;

    // Start is called before the first frame update
    void Start()
    {
        LoadClothes();
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
}
