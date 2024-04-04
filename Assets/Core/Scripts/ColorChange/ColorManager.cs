using UnityEngine;

namespace Game.Core.Colorize
{
    public class ColorManager : MonoBehaviour
    {
        public static void ChangeColor(GameObject renderObject)
        {
            float red = Random.Range(0f, 1f);
            float green = Random.Range(0f, 1f);
            float blue = Random.Range(0f, 1f);

            SpriteRenderer spriteRenderer = renderObject.GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(red, green, blue);
        }
    }
}

