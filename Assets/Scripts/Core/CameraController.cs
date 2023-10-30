using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("吃到金幣時的特效")]
    [SerializeField] ParticleSystem getCoinParticle;

    void Awake()
    {
        getCoinParticle.Stop();
    }

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
