using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("金幣數量")]
    [SerializeField] Text Text_Coin;

    private void Awake()
    {
        Text_Coin.text = "0";
    }

    #region -- 方法參考區 --

    /// <summary>
    /// 計算傳入的金幣價值，對UI的金幣數進行更改
    /// </summary>
    /// <param name="worth">傳入的價值</param>
    public void CoinCalculate(int worth)
    {
        int coin = Int32.Parse( Text_Coin.text );
        Text_Coin.text = ( coin + worth ).ToString();
    }

    #endregion
}
