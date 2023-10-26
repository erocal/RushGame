using System.Collections.Generic;
using UnityEngine;

public class MapBlockManager : MonoBehaviour
{
    [Header("要生成的地圖方塊物件列表")]
    [SerializeField] List<GameObject> instantiateMapBlockList;

    /// <summary>
    /// 地圖方塊的間距
    /// </summary>
    [Header("地圖方塊的間距")]
    [SerializeField] Vector3 mapBlockOffset;

    #region -- 參數參考區 --

    [Header("地圖方塊列表")]
    [SerializeField] List<GameObject> mapBlockList = new List<GameObject>();

    private int currentActiveIndex = 0;

    #endregion

    private void Awake()
    {

        InitMapBlock();

    }

    private void InitMapBlock()
    {
        for (int i = 0; i < instantiateMapBlockList.Count; i++)
        {
            GameObject mapBlock = Instantiate(instantiateMapBlockList[i], this.transform);
            mapBlock.GetComponentInChildren<MapBlock>().SetComponent(this);
            mapBlockList.Add(mapBlock);

            // 設置每個地圖方塊的位置
            SetMapBlockPosition(mapBlock, i);
        }
    }

    /// <summary>
    /// 啟動地圖方塊
    /// </summary>
    public void ActiveMapBlock()
    {
        for (int i = 0; i < mapBlockList.Count; i++)
        {
            bool shouldBeActive = (i >= currentActiveIndex && i < currentActiveIndex + 6) || (i < currentActiveIndex - mapBlockList.Count + 6);
            mapBlockList[i].SetActive(shouldBeActive);
        }

        if (currentActiveIndex == mapBlockList.Count - 3)
        {
            transform.position = Vector3.zero;
        }

        currentActiveIndex = (currentActiveIndex + 1) % (mapBlockList.Count - 2);
    }



    /// <summary>
    /// 設定地圖方塊的位置
    /// </summary>
    /// /// <param name="mapBlock">地圖方塊</param>
    /// <param name="blockIndex">地圖方塊的索引</param>
    /// <returns>地圖方塊的位置</returns>
    private void SetMapBlockPosition(GameObject mapBlock, int blockIndex)
    {
        Vector3 position = blockIndex * mapBlockOffset;

        // 設置每個地圖方塊的位置
        mapBlock.transform.position = position;
    }
}
