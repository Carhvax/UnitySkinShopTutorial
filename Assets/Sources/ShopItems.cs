using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopItems : MonoBehaviour {
    private readonly List<ShopItem> _items = new List<ShopItem>();
    
    public event Action<ShopItem> ItemSelected;
    public void ShowItems() {
        foreach (var item in GetComponentsInChildren<ShopItem>(true)) {
            item.Selected += OnItemSelected;
            _items.Add(item);
        }    
    }

    private void OnItemSelected(ShopItem item) {
        ItemSelected?.Invoke(item);
    }

    public void HideItems() {
        foreach (var item in _items.ToArray()) {
            item.Selected -= OnItemSelected;
            _items.Remove(item);
        }
    }

    public void UpdateItems(Action<ShopItem> onItemUpdate) {
        foreach (var item in _items) {
            onItemUpdate?.Invoke(item);
        }
    }
}