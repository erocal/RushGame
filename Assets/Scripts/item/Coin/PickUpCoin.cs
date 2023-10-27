using UnityEngine;

public class PickUpCoin : MonoBehaviour
{

    #region -- 參數參考區 --

    PickUp pickUp;

    #endregion

    void Start()
    {
        pickUp = GetComponent<PickUp>();

        pickUp.onPick += OnPick;
    }

    /// <summary>
    /// 撿起金幣
    /// </summary>
    /// <param name="player">玩家</param>
    void OnPick(GameObject player)
    {
        transform.parent.gameObject.SetActive(false);
    }
}
