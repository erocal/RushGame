using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�b�Ť��U�I�[���O�q")]
    [SerializeField] float gravityDownForce = 50;

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
        // ���ʦ欰
        MoveBehaviour();
    }

    private void FixedUpdate()
    {
        // ���O
        Gravity();
    }

    /// <summary>
    /// ���ʦ欰
    /// </summary>
    private void MoveBehaviour()
    {

    }

    #endregion

    #region -- ��k�ѦҰ� --

    /// <summary>
    /// �B�z���O
    /// </summary>
    private void Gravity()
    {

        jumpDirection.y -= gravityDownForce * Time.deltaTime;
        jumpDirection.y = Mathf.Max(jumpDirection.y, -gravityDownForce);

        controller.Move(jumpDirection * Time.deltaTime);
    }

    #endregion
}
