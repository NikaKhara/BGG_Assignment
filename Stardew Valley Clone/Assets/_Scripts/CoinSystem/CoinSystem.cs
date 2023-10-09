using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private TextMeshProUGUI _coinTxt;
    [SerializeField] private int _startingCoins = 500;
    
    public int Coins => _coins;
    
    #region Singleton
    public static CoinSystem instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CoinSystem>();
            }
            return _instance;
        }
    }
    static CoinSystem _instance;
    
    void Awake ()
    {
        _instance = this;
    }
    #endregion

    private void Start()
    {
        AddCoins(_startingCoins);
    }

    public void AddCoins(int amount)
    {
        _coins += amount;
        UpdateUI();
    }
    
    public void RemoveCoins(int amount)
    {
        _coins -= amount;
        if (_coins < 0)
        {
            _coins = 0;
        }
        UpdateUI();
    }
    
    public bool CanAfford(int amount)
    {
        return _coins >= amount;
    }
    private void UpdateUI()
    {
        _coinTxt.text = _coins.ToString();
    }
}