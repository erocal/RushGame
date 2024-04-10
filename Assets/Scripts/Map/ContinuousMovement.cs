using UnityEngine;

/// <summary>
/// 處理任意物件每幀往三維方向移動
/// </summary>
public class ContinuousMovement : MonoBehaviour
{

    #region -- 資源參考區 --

    [Header("每幀移動的距離")]
    [SerializeField] Vector3 move;

    #endregion

    #region -- 初始化/運作 --

    void Update()
    {
        this.transform.position += move;
    }

    #endregion

}
