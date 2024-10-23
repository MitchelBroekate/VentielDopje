using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GammaController : MonoBehaviour
{
    public Volume volume; // Het volume waar de Lift Gamma Gain op staat
    public Slider gammaSlider; // De slider voor gamma-aanpassing
    private LiftGammaGain liftGammaGain;

    void Start()
    {
        // Zorg ervoor dat het Volume-component correct is toegewezen
        if (volume.profile.TryGet(out liftGammaGain))
        {
            // Stel de slider in op de huidige gamma-waarde (als je dat wilt)
            gammaSlider.value = liftGammaGain.gamma.value.w;
            gammaSlider.onValueChanged.AddListener(UpdateGamma);
        }
    }

    // Functie die de gamma-waarde bijwerkt op basis van de slider
    void UpdateGamma(float value)
    {
        if (liftGammaGain != null)
        {
            Vector4 gamma = liftGammaGain.gamma.value;
            gamma.w = value; // Pas alleen de gamma (w-component) aan
            liftGammaGain.gamma.value = gamma;
        }
    }
}
