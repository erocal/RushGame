using UnityEngine;

/// <summary>
/// �B�z���N����C�V���T����V����
/// </summary>
public class ContinuousMovement : MonoBehaviour
{
    [Header("�C�V���ʪ��Z��")]
    [SerializeField] Vector3 move;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += move;
    }
}
