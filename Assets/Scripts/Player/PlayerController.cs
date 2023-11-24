using System.Security.Claims;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�b�Ť��U�I�[���O�q")]
    [SerializeField] float gravityDownForce = 50;

    [Space(20)]
    [Header("���D�Ѽ�")]
    [Tooltip("���D�ɦV�W�I�[���O�q")]
    [SerializeField] float jumpForce = 15;
    [Tooltip("�ˬd�P�a���������Z��")]
    [SerializeField] float distanceToGround = 0.1f;

    #region -- �ѼưѦҰ� --

    InputController input;
    CharacterController controller;

    // �U�@�V���D�쪺��V
    private Vector3 jumpDirection;

    #endregion

    #region -- ��l��/�B�@ --

    void Awake()
    {
        input = GameManagerSingleton.Instance.InputController;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // ���D�欰
        JumpBehaviour();
    }

    private void FixedUpdate()
    {
        // ���O
        Gravity();
    }

    #endregion

    #region -- ��k�ѦҰ� --

    /// <summary>
    /// ���ʦ欰
    /// </summary>
    private void JumpBehaviour()
    {
        // ��H���B��a���A���U���D���
        if (input.GetSlideUp() && IsGrounded())
        {
            jumpDirection = Vector3.zero;
            jumpDirection += jumpForce * Vector3.up;
        }
    }

    /// <summary>
    /// �B�z���O
    /// </summary>
    private void Gravity()
    {

        jumpDirection.y -= gravityDownForce * Time.deltaTime;
        jumpDirection.y = Mathf.Max(jumpDirection.y, -gravityDownForce);

        controller.Move(jumpDirection * Time.deltaTime);
    }

    /// <summary>
    /// �˴����a�O�_�b�a�W
    /// </summary>
    /// <returns>�^�Ǫ��a�O�_�b�a�W</returns>
    private bool IsGrounded()
    {
        //Debug.DrawRay(transform.position, -Vector3.up * distanceToGround, Color.yellow);
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround/*, targetMask*/);
    }

    #endregion
}
