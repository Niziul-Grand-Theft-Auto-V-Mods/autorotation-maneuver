using GTA;
using System;
using System.Drawing;
using System.IO;
using GTAScreen
      = GTA.UI.Screen;

namespace Autorotation_maneuver.settings
{
    internal sealed class Settings
    {
        internal string PathToTheAutorotationManeuverFolder
        {
            get
            {
                return _
                       = Directory
                            .GetCurrentDirectory()
                         +
                         @"\scripts\AutorotationManeuver";
            }
        }
        internal string PathToTheDefaultLayoutImage
        {
            get
            {
                return _
                       = PathToTheAutorotationManeuverFolder
                         +
                         @"\UserInterfaceResources\CustomSprite\DefaultLayout.png";
            }
        }

        internal string PathToDisplayCompatibilityFile
        {
            get
            {
                return _
                       = PathToTheAutorotationManeuverFolder
                         +
                         @"\UserInterfaceResources\DisplayCompatibility.ini";
            }
        }

        internal string PathToBehaviorOfUserInterfaceElementsFile
        {
            get
            {
                return _
                       = PathToTheAutorotationManeuverFolder
                         +
                         @"\BehaviorOfUserInterfaceElements.ini";
            }
        }

        internal Boolean GetInterfaceVisibility()
        {
            var behaviorOfUserInterfaceElementsFile
                = ScriptSettings
                    .Load(PathToBehaviorOfUserInterfaceElementsFile);

            var interfaceVisibility
                = false;

            var section
                = "InterfaceVisibility";

            var key
                = "_";

            var value
                = behaviorOfUserInterfaceElementsFile
                    .GetAllValues<string>(section,
                                          key)[0];

            if (value != null 
                &&
                value == "On")
            {
                interfaceVisibility
                = true;
            }

            return interfaceVisibility;
        }

        internal Boolean GetInterfaceDisplayBehavior()
        {
            var behaviorOfUserInterfaceElementsFile
                = ScriptSettings
                    .Load(PathToBehaviorOfUserInterfaceElementsFile);

            var interfaceDiplayBehavior
                = false;

            var section
                = "DisplayOnlyInAutorotation";

            var key
                = "_";

            var value
                = behaviorOfUserInterfaceElementsFile
                    .GetAllValues<string>(section,
                                          key)[0];

            if (value != null
                &&
                value == "On")
            {
                interfaceDiplayBehavior
                = true;
            }

            return interfaceDiplayBehavior;
        }

        internal PointF GetPositionOfCenterOfScreen()
        {
            return _
                   = new PointF(x: GTAScreen
                                        .ScaledWidth / 2f,
                                y: 0f);
        }
        internal PointF GetCustomPositionOfCenterOfScreen()
        {
            var positionOfCenterOfScreen 
                = GetPositionOfCenterOfScreen();

            return _
                   = new PointF(x: positionOfCenterOfScreen
                                                         .X,
                                y: 680f);
        }
        
        internal SizeF GetSizeOfTheDefaultLayoutImage()
        {
            var sizeOfDefaultLayoutImage 
                = new SizeF();

            using (var defaultLayoutImage = Image
                                                .FromFile(PathToTheDefaultLayoutImage))
            {
                sizeOfDefaultLayoutImage 
                = defaultLayoutImage
                                    .Size;
            }
            

            return sizeOfDefaultLayoutImage;
        }
        internal SizeF GetCustomSizeOfTheDefaultLayoutImage()
        {
            var sizeOfDefaultLayoutImage
                = GetSizeOfTheDefaultLayoutImage();

            return _
                   = new SizeF(width: sizeOfDefaultLayoutImage
                                                        .Width / 3f,
                               height: sizeOfDefaultLayoutImage
                                                        .Height / 3f);
            
        }
        
        internal Color GetColorOf(string section)
        {
            var behaviorOfUserInterfaceElementsFile
                = ScriptSettings
                    .Load(PathToBehaviorOfUserInterfaceElementsFile);

            var keys 
                = new[]
                {
                    "Color - A",
                    "Color - R",
                    "Color - G",
                    "Color - B"
                };

            var unconvertedColor
                = new string[4];

            var convertedColor
                = new byte[4];

            for (var i = (byte)0; i < keys
                                        .Length; i++)
            {
                unconvertedColor
                [i] = behaviorOfUserInterfaceElementsFile
                        .GetAllValues<string>(section, 
                                              keys[i])[0];

                convertedColor
                [i] = byte
                        .Parse(unconvertedColor[i]);
            }

            return _
                   = Color
                        .FromArgb(alpha: convertedColor[0],
                                  red  : convertedColor[1],
                                  green: convertedColor[2],
                                  blue : convertedColor[3]);
        }
    }
}
