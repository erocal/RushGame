using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNewMapBlock : MonoBehaviour
{
    [Header("要生成的地圖方塊物件列表")]
    public List<GameObject> mapBlockList;

    private void Awake()
    {
        for (int i = 0; i < 12; i++)
            foreach (var mapBlock in mapBlockList)
            {
                GameObject newMapBlock = Instantiate(mapBlock, this.transform);

                // 將新生成的地圖方塊關掉
                if (i > 0) newMapBlock?.SetActive(false);
            }


        
    }
}
