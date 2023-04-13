using GTA.UI;

using Font 
      = GTA.UI.Font;

using System.Drawing;

using Autorotation_maneuver.settings;


namespace Autorotation_maneuver.user_interface.creators
{
    internal abstract class TextElementCreator
    {
        protected TextElement ReturnAnAlreadyConfiguredTextElement()
        {
            var settings 
                = new Settings();

            var customPosition 
                = settings
                    .GetCustomPositionOfCenterOfScreen();

            var offsetPosition
                = new PointF(x: customPosition
                                            .X, 
                             y: customPosition
                                            .Y - 2f);

            var color
                = settings
                    .GetColorOf("TextElement");

            return _ 
                   = new TextElement(caption : string
                                                    .Empty,
                                     position: offsetPosition,
                                     scale   : 0.50f,
                                     color   : color)
                     {
                         Centered 
                         = true,

                         Shadow 
                         = true,

                         Alignment 
                         = Alignment
                                .Center,
                         
                         Font 
                         = Font
                                .HouseScript
                     };
        }
    }
}
