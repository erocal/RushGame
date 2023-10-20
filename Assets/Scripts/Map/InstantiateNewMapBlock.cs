using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNewMapBlock : MonoBehaviour
{
    [Header("�n�ͦ����a�Ϥ������C��")]
    public List<GameObject> mapBlockList;

    private void Awake()
    {
        for (int i = 0; i < 12; i++)
            foreach (var mapBlock in mapBlockList)
            {
                GameObject newMapBlock = Instantiate(mapBlock, this.transform);

                // �N�s�ͦ����a�Ϥ������
                if (i > 0) newMapBlock?.SetActive(false);
            }


        
    }
}
