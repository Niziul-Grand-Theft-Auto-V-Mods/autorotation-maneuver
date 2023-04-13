using GTA.UI;

using Autorotation_maneuver.settings;


namespace Autorotation_maneuver.user_interface.creators
{
    internal abstract class CustomSpriteCreator
    {
        protected CustomSprite ReturnAnAlreadyConfiguredCustomSprite()
        {
            var settings 
                = new Settings();

            var customPosition 
                = settings
                    .GetCustomPositionOfCenterOfScreen();

            var customSize 
                = settings
                    .GetCustomSizeOfTheDefaultLayoutImage();

            var color
                = settings
                    .GetColorOf("CustomSprite");

            return _
                   = new CustomSprite(filename: settings
                                                     .PathToTheDefaultLayoutImage,
                                      size    : customSize,
                                      position: customPosition,
                                      color   : color)
                     {
                         Centered
                         = true
                     };
        }
    }
}
