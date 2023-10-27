using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("要生成的金幣")]
    [SerializeField] GameObject coin;
    [Header("生成的金幣數量")]
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
