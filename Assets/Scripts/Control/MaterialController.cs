using UnityEngine;

public class MaterialController : MonoBehaviour
{

    #region -- 資源參考區 --

    [Header("變化材質的速度")]
    [SerializeField] float speed = 0.0005f;
    [Header("變化的道路材質")]
    [SerializeField] Material roadMaterial;
    [Header("變化的金幣材質")]
    [SerializeField] Material coinMaterial;
    [Header("共通材質的SwerveX")]
    [SerializeField] float swerveXValue;
    [Header("共通材質的SwerveY")]
    [SerializeField] float swerveYValue;

    #endregion

    #region -- 參數參考區 --

    bool isDynamicSet = false;

    #endregion

    #region -- 初始化/運作 --

    void Update()
    {
        if (isDynamicSet)
        {
            DynamicSet_SwerveX(roadMaterial);
            DynamicSet_SwerveX(coinMaterial);
        }
        else MaterialSet_SwerveX();
        MaterialSet_SwerveY();
    }

    #endregion

    #region -- 方法參考區 --

    /// <summary>
    /// 在_SwerveX的Range極值之間來回設置shader的數值
    /// </summary>
    /// <param name="material">傳入要更改的Material</param>
    private void DynamicSet_SwerveX(Material material)
    {

        // 獲取最小值和最大值
        float swerveXMin = material.GetFloat("_SwerveX_Min");
        float swerveXMax = material.GetFloat("_SwerveX_Max");

        // 計算新的_SwerveX值並限制在範圍內
        swerveXValue = Mathf.Clamp(Mathf.PingPong(Time.time * speed, swerveXMax - swerveXMin) + swerveXMin, swerveXMin, swerveXMax);

        // 設置Shader屬性值
        material.SetFloat("_SwerveX", swerveXValue);

    }

    /// <summary>
    /// 更改_SwerveX的值
    /// </summary>
    private void MaterialSet_SwerveX()
    {
        roadMaterial.SetFloat("_SwerveX", swerveXValue);
        coinMaterial.SetFloat("_SwerveX", swerveXValue);
    }

    /// <summary>
    /// 更改_SwerveY的值
    /// </summary>
    private void MaterialSet_SwerveY()
    {
        roadMaterial.SetFloat("_SwerveY", swerveYValue);
        coinMaterial.SetFloat("_SwerveY", swerveYValue);
    }

    /// <summary>
    /// 通過slider變更_SwerveX的值
    /// </summary>
    /// <param name="slidervalue">滑桿的值</param>
    public void SetSwerveXValue(float slidervalue)
    {
        swerveXValue = slidervalue;
    }

    /// <summary>
    /// 通過slider變更_SwerveY的值
    /// </summary>
    /// <param name="slidervalue">滑桿的值</param>
    public void SetSwerveYValue(float slidervalue)
    {
        swerveYValue = slidervalue;
    }

    /// <summary>
    /// 是否要動態設置_SwerveX
    /// </summary>
    /// <param name="isDynamicSet"></param>
    public void IsDynamicSet(bool isDynamicSet)
    {
        this.isDynamicSet = isDynamicSet;
    }

    #endregion
}
