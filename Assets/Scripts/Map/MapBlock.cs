using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBlock : MonoBehaviour
{
    [Header("掛載地圖方塊物件列表的物件")]
    [SerializeField] GameObject mapBlockListGameObject;

    #region -- 參數參考區 --

    InstantiateNewMapBlock instantiateNewMapBlock;

    private List<GameObject> mapBlockList;

    private bool hasbeentrigger;

    #endregion

    private void Awake()
    {
        instantiateNewMapBlock = mapBlockListGameObject.GetComponent<InstantiateNewMapBlock>();
        mapBlockList = instantiateNewMapBlock.mapBlockList;
    }

    #region -- 方法參考區 --


    private void OnTriggerEnter(Collider other)
    {
        if (hasbeentrigger) return;

        if (other.gameObject.tag == "Player")
        {
            hasbeentrigger = true;
            StartCoroutine(SetActiveMapBlock());
        }
    }

    /// <summary>
    /// 地圖方塊啟動
    /// </summary>
    IEnumerator SetActiveMapBlock()
    {

        mapBlockList[0].SetActive(true);

        yield return new WaitForSeconds(5f);

    }

    #endregion
}
