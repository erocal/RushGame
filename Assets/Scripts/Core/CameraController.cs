using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("�Y������ɪ��S��")]
    [SerializeField] ParticleSystem getCoinParticle;

    void Awake()
    {
        getCoinParticle.Stop();
    }

    #region -- ��k�ѦҰ� --

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
