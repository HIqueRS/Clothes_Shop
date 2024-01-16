using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClothe : MonoBehaviour
{
    public TMPro.TextMeshProUGUI _clotheName;
    public TMPro.TextMeshProUGUI _clotheCost;
    public Image _clotheIcon;

    public ClothingScriptable _clothingScriptable;
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
    }

    public void LoadScriptable()
    {
        _clotheName.text = _clothingScriptable.name;
        _clotheCost.text = _clothingScriptable._cost.ToString();
        _clotheIcon.sprite = _clothingScriptable._sprite;
    }
}
