using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ColorElement : MonoBehaviour
    {
        [SerializeField] private Color _color;
        [SerializeField] private Image _image;

        private void Start()
        {
            _image.color = _color;
        }

        public void SetColor(GameSettings gameSettings)
        {
            gameSettings.SetColor(_color);
        }


    }
}
