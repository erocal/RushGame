using UnityEngine;

public class GameSystem : MonoBehaviour
{
    #region -- �ѼưѦҰ� --

    InputController input;

    #endregion

    #region -- ��l��/�B�@ --

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
