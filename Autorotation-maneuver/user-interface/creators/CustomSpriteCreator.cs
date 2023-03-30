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
                    .ReturnTheCustomPositionOfCenterOfScreen();

            var customSize 
                = settings
                    .ReturnTheCustomSizeOfTheDefaultLayoutImage();

            var color
                = settings
                    .ReturnTheColorOf("Custom Sprite");

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
