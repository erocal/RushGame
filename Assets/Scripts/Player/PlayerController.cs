using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("い琁秖")]
    [SerializeField] float gravityDownForce = 50;

    #region -- 把计把σ跋 --

    CharacterController controller;

    // 碫铬臘よ
    Vector3 jumpDirection;

    #endregion

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // 
        Gravity();
    }

    #region -- よ猭把σ跋 --

    /// <summary>
    /// 矪瞶
    /// </summary>
    private void Gravity()
    {

        jumpDirection.y -= gravityDownForce * Time.deltaTime;
        jumpDirection.y = Mathf.Max(jumpDirection.y, -gravityDownForce);

        controller.Move(jumpDirection * Time.deltaTime);
    }

    #endregion
}
