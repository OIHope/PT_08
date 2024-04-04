using UnityEngine;

namespace Game.Core.Colorize
{
    public class ColorTrigger : MonoBehaviour
    {
        [SerializeField] GameObject renderObject;
        private void OnTriggerEnter2D(Collider2D other)
        {
            ColorManager.ChangeColor(renderObject);
        }
    }
}

