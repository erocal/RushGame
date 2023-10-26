using UnityEngine;

/// <summary>
/// 處理任意物件每幀往三維方向移動
/// </summary>
public class ContinuousMovement : MonoBehaviour
{
    [Header("每幀移動的距離")]
    [SerializeField] Vector3 move;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += move;
    }
}
