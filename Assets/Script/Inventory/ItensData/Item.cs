using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Itens/Item")]
public class Item : ScriptableObject
{
    [field: SerializeField] public bool IsStackable { get; set; }

    public int ID => GetInstanceID();

    [field: SerializeField] public int MaxStackSize { get; set; } = 5;

    [field: SerializeField] public String Name { get; set; }

    [field: SerializeField] [field: TextArea] public String Description { get; set; }

    [field: SerializeField] public Sprite ItemImage { get; set; }

}
