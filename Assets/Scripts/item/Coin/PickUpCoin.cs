using UnityEngine;

public class PickUpCoin : MonoBehaviour
{

    #region -- 把计把σ跋 --

    PickUp pickUp;

    #endregion

    void Start()
    {
        pickUp = GetComponent<PickUp>();

        pickUp.onPick += OnPick;
    }

    /// <summary>
    /// 具癬刽
    /// </summary>
    /// <param name="player">產</param>
    void OnPick(GameObject player)
    {
        transform.parent.gameObject.SetActive(false);
    }
}
