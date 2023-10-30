using UnityEngine;

public class PickUpCoin : MonoBehaviour
{

    #region -- �ѼưѦҰ� --

    CameraController cameraController;
    UIManager uiManager;
    PickUp pickUp;
    /// <summary>
    /// ����������
    /// </summary>
    int worthOfCoin = 1;

    #endregion

    private void Awake()
    {
        uiManager = GameObject.FindGameObjectWithTag("UI")?.GetComponent<UIManager>();
        cameraController = GameObject.FindGameObjectWithTag("MainCamera")?.GetComponent<CameraController>();
    }

    void Start()
    {
        pickUp = GetComponent<PickUp>();

        pickUp.onPick += OnPick;
    }

    #region -- ��k�ѦҰ� --

    #endregion

    /// <summary>
    /// �߰_����
    /// </summary>
    /// <param name="player">���a</param>
    void OnPick(GameObject player)
    {
        transform.parent.gameObject.SetActive(false);

        uiManager.CoinCalculate(worthOfCoin);

        cameraController?.ActiveParticle("Coin");
    }
}
