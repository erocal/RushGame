using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("在空中下施加的力量")]
    [SerializeField] float gravityDownForce = 50;

    #region -- 參數參考區 --

    CharacterController controller;

    // 下一幀跳躍到的方向
    Vector3 jumpDirection;

    #endregion

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // 重力
        Gravity();
    }

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
