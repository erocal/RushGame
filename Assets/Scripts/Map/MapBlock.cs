using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    [Header("金幣管理")]
    [SerializeField] CoinManager coinManager;

    #region -- 參數參考區 --

    MapBlockManager mapBlockManager;

    #endregion

    #region -- 方法參考區 --

    /// <summary>
    /// 獲取MapBlockManager組件
    /// </summary>
    /// <param name="component">MapBlockManager</param>
    public void SetComponent(MapBlockManager component)
    {
        mapBlockManager = component;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mapBlockManager.ActiveMapBlock();
            coinManager.SetPosition();
            coinManager.ActiveAllCoin();
        }
    }

    #endregion
}
