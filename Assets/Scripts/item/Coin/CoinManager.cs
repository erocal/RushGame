using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    #region -- 資源參考區 --

    [Header("要生成的金幣")]
    [SerializeField] GameObject coin;
    [Header("生成的金幣數量")]
    [SerializeField] int amount = 15;

    #endregion

    #region -- 參數參考區 --

    List<GameObject> coinList = new List<GameObject>();

    int y = 1; // 固定的 y 坐标
    int zRange = 75; // z 范围
    int minZSpacing = 5; // 最小 z 间隔

    #endregion

    #region -- 初始化/運作 --

    void Awake()
    {

        for (int i = 0 ; i < amount; i++)
        {
            var coin = Instantiate(this.coin, this.transform);
            coinList.Add(coin);
        }

        SetPosition();
            
    }

    #endregion

    #region -- 方法參考區--

    /// <summary>
    /// 設定金幣的位置
    /// </summary>
    public void SetPosition()
    {
        for (int i = 0; i < amount; i++)
        {
            // 隨機在-15、0、15 中選擇一個值
            int randomX = Random.Range(0, 3) * 15 - 15;

            // 隨機生成z座標，確保 z 間隔至少為 minZSpacing
            int randomZ = Random.Range(-zRange, zRange + 1);
            int spacing = minZSpacing;

            if (i > 0)
            {
                // 計算與前一個物體的間隔
                float prevZ = transform.GetChild(i - 1).position.z;
                float minZ = prevZ + spacing;
                randomZ = (int)Mathf.Max(minZ, randomZ);
            }

            // 創建位置向量
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
