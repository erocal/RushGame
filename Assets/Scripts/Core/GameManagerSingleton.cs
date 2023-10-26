using UnityEngine;

// singleton��ҼҦ�
// �i�H�T�O�ͦ���H�u���@�ӹ�Ҧs�b
// �}�o�C���|�Ʊ�Y�����O�u���@�ӹ�Ҥƪ���N�i�H�ϥ�
public class GameManagerSingleton
{
    private GameObject gameObject;

    //���
    private static GameManagerSingleton m_Instance;
    //���f�A�T�{��ҬO�_�s�b
    public static GameManagerSingleton Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameManagerSingleton();
                m_Instance.gameObject = new GameObject("GameManager");
                m_Instance.gameObject.AddComponent<InputController>();
            }
            return m_Instance;
        }
    }

    // �n�OInputController(�@�ӹC���u�|���@��)
    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if (m_InputController == null)
            {
                m_InputController = gameObject.GetComponent<InputController>();
            }
            return m_InputController;
        }
    }
}
