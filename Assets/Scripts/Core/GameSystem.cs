using UnityEngine;

public class GameSystem : MonoBehaviour
{
    #region -- 參數參考區 --

    InputController input;

    #endregion

    #region -- 初始化/運作 --

    private void Awake()
    {
        input = GameManagerSingleton.Instance.InputController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion 
}
