using UnityEngine;

public class PickUpCoin : MonoBehaviour
{

    #region -- �ѼưѦҰ� --

    PickUp pickUp;

    #endregion

    void Start()
    {
        pickUp = GetComponent<PickUp>();

        pickUp.onPick += OnPick;
    }

    /// <summary>
    /// �߰_����
    /// </summary>
    /// <param name="player">���a</param>
    void OnPick(GameObject player)
    {
        transform.parent.gameObject.SetActive(false);
    }
}
