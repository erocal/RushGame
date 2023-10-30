using UnityEngine;

public class PickUpCoin : MonoBehaviour
{

    #region -- 把计把σ跋 --

    CameraController cameraController;
    UIManager uiManager;
    PickUp pickUp;
    /// <summary>
    /// 刽基
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

    #region -- よ猭把σ跋 --

    #endregion

    /// <summary>
    /// 具癬刽
    /// </summary>
    /// <param name="player">產</param>
    void OnPick(GameObject player)
    {
        transform.parent.gameObject.SetActive(false);

        uiManager.CoinCalculate(worthOfCoin);

        cameraController?.ActiveParticle("Coin");
    }
}
