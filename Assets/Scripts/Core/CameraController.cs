using UnityEngine;

public class CameraController : MonoBehaviour
{

    #region -- 資源參考區 --

    [Header("吃到金幣時的特效")]
    [SerializeField] ParticleSystem getCoinParticle;

    #endregion

    #region -- 初始化/運作 --

    void Awake()
    {
        getCoinParticle.Stop();
    }

    #endregion

    #region -- 方法參考區 --

    public void ActiveParticle(string particleName)
    {
        switch (particleName)
        {
            case "Coin":
                getCoinParticle.Play();
                break;
            default: 
                break;
        }
    }

    #endregion
}
