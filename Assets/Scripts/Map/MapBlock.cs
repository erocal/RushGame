using UnityEngine;

public class MapBlock : MonoBehaviour
{

    #region -- 資源參考區 --

    [Header("金幣管理")]
    [SerializeField] CoinManager coinManager;

    #endregion

    #region -- 變數參考區 --

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
