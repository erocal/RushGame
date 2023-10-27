using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DynamicMap : MonoBehaviour
{
    [Header("變化材質的速度")]
    [SerializeField] float speed = 0.0005f;
    [Header("變化的材質")]
    [SerializeField] Material material;
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

    private void Awake()
    {
        input = GameManagerSingleton.Instance.InputController;
    }

    private void Update()
    {
        DynamicSet_SwerveX();
        // 地圖移動行為
        MoveBehaviour();
    }

    /// <summary>
    /// 在_SwerveX的Range極值之間來回設置shader的數值
    /// </summary>
    private void DynamicSet_SwerveX()
    {
        if (material == null)
        {
            Debug.LogWarning(" 未獲取地圖材質 ");
            return;
        }

        // 獲取最小值和最大值
        var swerveXMin = material.GetFloat("_SwerveX_Min");
        var swerveXMax = material.GetFloat("_SwerveX_Max");

        // 计算新的SwerveX值并限制在范围内
        float swerveXValue = Mathf.Clamp(Mathf.PingPong(Time.time * speed, swerveXMax - swerveXMin) + swerveXMin, swerveXMin, swerveXMax);

        // 設置Shader屬性值
        material.SetFloat("_SwerveX", swerveXValue);
    }

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
}
