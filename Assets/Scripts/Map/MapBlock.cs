using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    #region -- 參數參考區 --

    MapBlockManager mapBlockManager;

    #endregion

    public void SetComponent(MapBlockManager component)
    {
        mapBlockManager = component;
    }

    #region -- 方法參考區 --


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mapBlockManager.ActiveMapBlock();
        }
    }

    #endregion
}
