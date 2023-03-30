using GTA.UI;

namespace Autorotation_maneuver.user_interface
{
    internal sealed class Elements
    {
        private readonly TextElement _textElement;

        private readonly CustomSprite _customSprite;

        private readonly ContainerElement _containerElement;


        public Elements(CustomSprite customSprite, ContainerElement containerElement, TextElement textElement)
        {
            _textElement 
                = textElement;
            
            _customSprite 
                = customSprite;

            _containerElement 
                = containerElement;
        }
        
        internal void ScaledDraw(string textElementCaption)
        {
            _containerElement
                .ScaledDraw();

            _textElement
                .Caption 
                 = textElementCaption;

            _textElement
                .ScaledDraw();

            _customSprite
                .ScaledDraw();
        }
    }
}