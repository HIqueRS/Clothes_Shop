using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalConfigurations;
using System.IO;

[CreateAssetMenu(fileName = "Clothing", menuName = "Scriptables/Clothing")]
public class ClothingScriptable : ScriptableObject
{
    public string _path;
    public int _index;
    public string _name;
    public Sprite _sprite;
    public Category _category;
    public int _cost;
}
