using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�b�Ť��U�I�[���O�q")]
    [SerializeField] float gravityDownForce = 50;

    #region -- �ѼưѦҰ� --

    CharacterController controller;

    // �U�@�V���D�쪺��V
    Vector3 jumpDirection;

    #endregion

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // ���O
        Gravity();
    }

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
