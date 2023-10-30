using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("�����ƶq")]
    [SerializeField] Text Text_Coin;

    private void Awake()
    {
        Text_Coin.text = "0";
    }

    #region -- ��k�ѦҰ� --

    /// <summary>
    /// �p��ǤJ���������ȡA��UI�������ƶi����
    /// </summary>
    /// <param name="worth">�ǤJ������</param>
    public void CoinCalculate(int worth)
    {
        int coin = Int32.Parse( Text_Coin.text );
        Text_Coin.text = ( coin + worth ).ToString();
    }

    #endregion
}
