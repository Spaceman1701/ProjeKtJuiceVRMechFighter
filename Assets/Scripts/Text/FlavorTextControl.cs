using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class FlavorTextControl : MonoBehaviour
{
    public Image logo;
    public float textDuration = 20f;
    private CanvasGroup group;
    public float textFadeDuration = 0.2f;
    public float timeToFade = 1f;
    public List<string> flavorTextStrings = new List<string>();
    public TextMeshProUGUI text;
    private int textIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        group = GetComponent<CanvasGroup>();
        flavorTextStrings.Add("11 years ago, our world was irreparably changed. The events of the Occurrence have long been shrouded in layers of corporate secrecy, but everyone alive knows the importance of that world-shattering discovery - JUICE.");
        flavorTextStrings.Add("Long had humanity searched for a source of endless power, but it was not found among the gilded halls of alchemy. This holy grail was found in a far humbler place: the Bar of the Multiverse.");
        flavorTextStrings.Add("The knowledge of Juice, long dormant, resurfaced in 2077. Our search for unlimited energy has ended. The mech wars have just begun.");
        //text.faceColor = new Color32(254, 254 , 254, 1);
        text.text = flavorTextStrings[0];
        text.faceColor = new Color32(255, 255, 255, 0);

        logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        int diff = 2;

        if (Time.time > (textDuration / flavorTextStrings.Count) * textIndex)
        {
            if ((float)text.faceColor.a >= diff)
            {
                text.faceColor = new Color32(text.faceColor.r, text.faceColor.g, text.faceColor.b, (byte)((float)text.faceColor.a - diff));
            }
            else if (textIndex < flavorTextStrings.Count)
            {
                text.text = flavorTextStrings[textIndex];
                textIndex++;
            }
        }
        else
        {
            if ((float)text.faceColor.a <= 255-diff && textIndex <= flavorTextStrings.Count) // Don't fade up after last
            {
                text.faceColor = new Color32(text.faceColor.r, text.faceColor.g, text.faceColor.b, (byte)((float)text.faceColor.a + diff));
            }

        }

        if (Time.time > textDuration)
        {
            text.faceColor = new Color32(0, 0, 0, 0);
            logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, 1f);
        }
        if (Time.time > textDuration+7)
        {
            StartCoroutine(FadeToZeroAlpha());
            if(group.alpha == 0)
            {
                Destroy(this);
            }
        }
    }


    public IEnumerator FadeText()
    {
        Color32 col = text.faceColor;
        float diff = (Time.deltaTime / textFadeDuration)*255;

        while (col.r > 0)
        {
            text.faceColor = new Color(col.r-diff, col.g-diff, col.b-diff, col.a);
            yield return null;
        }
    }
    
    public IEnumerator FadeToZeroAlpha()
    {
        while (group.alpha > 0.0f)
        {
            group.alpha = group.alpha - (Time.deltaTime / timeToFade);
            yield return null;
        }
    }
}
