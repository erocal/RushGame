using UnityEngine;

public class PickUpCoin : MonoBehaviour
{

    #region -- 變數參考區 --

    CameraController cameraController;
    UIManager uiManager;
    PickUp pickUp;
    /// <summary>
    /// 金幣的價值
    /// </summary>
    int worthOfCoin = 1;

    #endregion

    #region -- 初始化/運作 --

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

    #endregion

    #region -- 方法參考區 --

/// <summary>
    /// 撿起金幣
    /// </summary>
    /// <param name="player">玩家</param>
    void OnPick(GameObject player)
    {
        transform.parent.gameObject.SetActive(false);

        uiManager.CoinCalculate(worthOfCoin);

        cameraController?.ActiveParticle("Coin");
    }

    #endregion
    
}
