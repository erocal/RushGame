using UnityEngine;

public class DynamicMap : MonoBehaviour
{
    [Header("位移的速度")]
    [SerializeField] float moveSpeed = 50.0f;
    [Header("往左位移位置")]
    [SerializeField] Vector3 toLeftPosition = new Vector3(15f, 0, 0);
    [Header("往右位移位置")]
    [SerializeField] Vector3 toRightPosition = new Vector3(-15f, 0, 0);

    #region -- 參數參考區 --

    InputController input;

    // 下一幀要移動到的位置
    private Vector3 targetPosition = Vector3.zero;
    // 是否正在移動
    private bool isMoving = false;

    #endregion

    #region -- 初始化/運作 --

    private void Awake()
    {
        input = GameManagerSingleton.Instance.InputController;
    }

    private void Update()
    {
        // 地圖移動行為
        MoveBehaviour();
    }

    #endregion

    #region -- 方法參考區 --

    /// <summary>
    /// 移動行為
    /// </summary>
    private void MoveBehaviour()
    {
        // 使用Lerp平滑移動地圖
        float step = moveSpeed * Time.deltaTime;
        // 計算x軸上的平移
        float newX = Mathf.MoveTowards(transform.position.x, targetPosition.x, step);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        if (!isMoving)
        {
            isMoving = true;

            switch (input.GetHandDirection())
            {
                case DirectionDefine.Direction.Up:
                    break;
                case DirectionDefine.Direction.Down:
                    break;
                case DirectionDefine.Direction.Left:
                    if(targetPosition.x < toLeftPosition.x)
                    {
                        // 地圖往右，人物往左，x軸往正方向人物會在最左邊
                        targetPosition = new Vector3(Mathf.Min(targetPosition.x + toLeftPosition.x, toLeftPosition.x), targetPosition.y, targetPosition.z);
                    }
                    break;
                case DirectionDefine.Direction.Right:
                    if (targetPosition.x > toRightPosition.x)
                    {
                        // 地圖往左，人物往右，x軸往負方向人物會在最左邊
                        targetPosition = new Vector3(Mathf.Max(targetPosition.x + toRightPosition.x, toRightPosition.x), targetPosition.y, targetPosition.z);
                    }
                    break;
                default:
                    break;
            }
        }

        // 檢查是否已經到達目標位置
        if ( Mathf.Approximately(transform.position.x, targetPosition.x) )
        {
            isMoving = false;
        }
    }

    #endregion

}
