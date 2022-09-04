using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkinShopScreen : MonoBehaviour {
    [SerializeField] private ShopItems _items;
    [SerializeField] private int _coins;
    [SerializeField] private TMP_Text _coinsField;
    [SerializeField] private List<int> _skins;

    private void OnEnable() {
        _items.ShowItems();
        _items.ItemSelected += OnSelectItem;
        UpdateCoinsView();
    }

    private void OnItemUpdate(ShopItem item) {
        if (item.SingleInstance && _skins.Contains(item.Id)) {
            item.SetState(false, "already has");
            return;
        }
        
        item.SetState(item.Price <= _coins, "not enough coins");
    }

    private void OnSelectItem(ShopItem item) {
        if (_coins >= item.Price) {
            _coins -= item.Price;
            _skins.Add(item.Id);
            UpdateCoinsView();
        }
    }

    private void UpdateCoinsView() {
        _coinsField.text = _coins.ToString();
        _items.UpdateItems(OnItemUpdate);
    }

    private void OnDisable() {
        _items.HideItems();
    }
}
