using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour {
    [SerializeField] private int _id;
    [SerializeField] private int _price;
    [SerializeField] private bool _singleInstance;
    [Space] 
    [SerializeField] private TMP_Text _priceField;
    [SerializeField] private Button _button;

    public event Action<ShopItem> Selected;

    public int Id => _id;
    public int Price => _price;
    public bool SingleInstance => _singleInstance;

    public void SetState(bool itemEnabled, string reason) {
        _button.interactable = itemEnabled;

        _priceField.text = itemEnabled ? _price.ToString() : reason;
    }

    private void OnEnable() {
        _priceField.text = _price.ToString();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick() => Selected?.Invoke(this);

    private void OnDisable() => _button.onClick.RemoveAllListeners();
}
