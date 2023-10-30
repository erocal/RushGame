using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("要生成的金幣")]
    [SerializeField] GameObject coin;
    [Header("生成的金幣數量")]
    [SerializeField] int amount = 15;

    #region -- 參數參考區 --

    List<GameObject> coinList = new List<GameObject>();

    int y = 1; // 固定的 y 坐标
    int zRange = 75; // z 范围
    int minZSpacing = 5; // 最小 z 间隔

    #endregion

    void Awake()
    {

        for (int i = 0 ; i < amount; i++)
        {
            var coin = Instantiate(this.coin, this.transform);
            coinList.Add(coin);
        }

        SetPosition();
            
    }

    #region -- 方法參考區--

    /// <summary>
    /// 設定金幣的位置
    /// </summary>
    public void SetPosition()
    {
        for (int i = 0; i < amount; i++)
        {
            // 随机选择 x 坐标值
            int randomX = Random.Range(0, 3) * 15 - 15; // 在 -15、0、15 中选择一个值

            // 随机生成 z 坐标，确保 z 间隔至少为 minZSpacing
            int randomZ = Random.Range(-zRange, zRange + 1);
            int spacing = minZSpacing;

            if (i > 0)
            {
                // 計算與前一個物體的間隔
                float prevZ = transform.GetChild(i - 1).position.z;
                float minZ = prevZ + spacing;
                randomZ = (int)Mathf.Max(minZ, randomZ);
            }

            // 创建位置向量
            Vector3 randomPosition = new Vector3(randomX, y, randomZ);

            coinList[i].transform.position = randomPosition;

        }
    }

    /// <summary>
    /// 開啟List中儲存的金幣
    /// </summary>
    public void ActiveAllCoin()
    {
        foreach(GameObject coin in coinList)
        {
            coin.SetActive(true);
        }
    }

    #endregion
}
