using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GammaController : MonoBehaviour
{
    public Volume volume; 
    public Slider gammaSlider; 
    public LiftGammaGain liftGammaGain;
   
    void Start()
    {
        gammaSlider.value = PlayerPrefs.GetFloat("Gamma", 1f);

        if (volume.profile.TryGet(out liftGammaGain))
        {
           
            gammaSlider.value = liftGammaGain.gamma.value.w;
            gammaSlider.onValueChanged.AddListener(UpdateGamma);
        }
    }


    public void UpdateGamma(float sliderValue)
    {


        if (liftGammaGain != null)
        {

            PlayerPrefs.SetFloat("Gamma", sliderValue);
            Vector4 gamma = liftGammaGain.gamma.value;
            gamma.w = sliderValue;
            liftGammaGain.gamma.value = gamma;

        }

    }
}
