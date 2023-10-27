using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("�n�ͦ�������")]
    [SerializeField] GameObject coin;
    [Header("�ͦ��������ƶq")]
    [SerializeField] int amount = 15;

    void Awake()
    {
        for(int i = 0 ; i < amount; i++)
        {
            var coin = Instantiate(this.coin, this.transform);
            coin.SetActive(false);
        }
            
    }

    void Update()
    {
        
    }
}
