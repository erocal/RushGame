using System.Security.Claims;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("在空中下施加的力量")]
    [SerializeField] float gravityDownForce = 50;

    [Space(20)]
    [Header("跳躍參數")]
    [Tooltip("跳躍時向上施加的力量")]
    [SerializeField] float jumpForce = 15;
    [Tooltip("檢查與地面之間的距離")]
    [SerializeField] float distanceToGround = 0.1f;

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
        // 跳躍行為
        JumpBehaviour();
    }

    private void FixedUpdate()
    {
        // 重力
        Gravity();
    }

    #endregion

    #region -- 方法參考區 --

    /// <summary>
    /// 移動行為
    /// </summary>
    private void JumpBehaviour()
    {
        // 當人物處於地面，按下跳躍鍵時
        if (input.GetSlideUp() && IsGrounded())
        {
            jumpDirection = Vector3.zero;
            jumpDirection += jumpForce * Vector3.up;
        }
    }

    /// <summary>
    /// 處理重力
    /// </summary>
    private void Gravity()
    {

        jumpDirection.y -= gravityDownForce * Time.deltaTime;
        jumpDirection.y = Mathf.Max(jumpDirection.y, -gravityDownForce);

        controller.Move(jumpDirection * Time.deltaTime);
    }

    /// <summary>
    /// 檢測玩家是否在地上
    /// </summary>
    /// <returns>回傳玩家是否在地上</returns>
    private bool IsGrounded()
    {
        //Debug.DrawRay(transform.position, -Vector3.up * distanceToGround, Color.yellow);
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround/*, targetMask*/);
    }

    #endregion
}
