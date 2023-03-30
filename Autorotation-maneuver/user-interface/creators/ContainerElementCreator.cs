using GTA.UI;

using System.Drawing;

using Autorotation_maneuver.settings;


namespace Autorotation_maneuver.user_interface.creators
{
    internal abstract class ContainerElementCreator
    {
        protected ContainerElement ReturnAnAlreadyConfiguredContainer()
        {
            var settings 
                = new Settings();

            var customPosition 
                = settings
                    .ReturnTheCustomPositionOfCenterOfScreen();

            var offsetPosition
                = new PointF(x: customPosition
                                            .X, 
                             y: customPosition
                                            .Y + 9.5f);

            var customSize 
                = settings
                    .ReturnTheCustomSizeOfTheDefaultLayoutImage();

            var offsetSize
                = new SizeF(width : customSize
                                            .Width, 
                            height: customSize
                                            .Height / 2.0f);

            var color
                = settings
                    .ReturnTheColorOf("Container Element");

            return _ 
                   = new ContainerElement(position: offsetPosition,
                                          size    : offsetSize,
                                          color   : color)
                     {           
                         
                         Centered 
                         = true
                     };
        }
    }
}
