using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("在空中下施加的力量")]
    [SerializeField] float gravityDownForce = 50;

    #region -- 參數參考區 --

    InputController input;
    CharacterController controller;

    // 下一幀跳躍到的方向
    private Vector3 jumpDirection;

    #endregion

    #region -- 初始化/運作 --

    void Awake()
    {
        input = GameManagerSingleton.Instance.InputController;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // 移動行為
        MoveBehaviour();
    }

    private void FixedUpdate()
    {
        // 重力
        Gravity();
    }

    /// <summary>
    /// 移動行為
    /// </summary>
    private void MoveBehaviour()
    {

    }

    #endregion

    #region -- 方法參考區 --

    /// <summary>
    /// 處理重力
    /// </summary>
    private void Gravity()
    {

        jumpDirection.y -= gravityDownForce * Time.deltaTime;
        jumpDirection.y = Mathf.Max(jumpDirection.y, -gravityDownForce);

        controller.Move(jumpDirection * Time.deltaTime);
    }

    #endregion
}
