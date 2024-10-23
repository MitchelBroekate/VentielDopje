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
        
        if (volume.profile.TryGet(out liftGammaGain))
        {
           
            gammaSlider.value = liftGammaGain.gamma.value.w;
            gammaSlider.onValueChanged.AddListener(UpdateGamma);
        }
    }

    
    public void UpdateGamma(float value)
    {
        if (liftGammaGain != null)
        {

            Vector4 gamma = liftGammaGain.gamma.value;
            gamma.w = value; 
            liftGammaGain.gamma.value = gamma;
            print(gamma);
        }
    }
}
