using GTA;
using GTA.UI;

using System.IO;
using System.Drawing;
using System;

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
        
        internal Boolean ReturnTheInterfaceVisibility()
        {
            var behaviorOfUserInterfaceElementsFile
                = ScriptSettings
                    .Load(PathToBehaviorOfUserInterfaceElementsFile);

            var interfaceVisibility
                = false;

            var section
                = "Interface Visibility";

            var key
                = "_";

            var value
                = behaviorOfUserInterfaceElementsFile
                    .GetAllValues<string>(section,
                                          key)[0];

            if (value != null)
            {
                if (value == "On")
                    interfaceVisibility = true;
            }

            return interfaceVisibility;
        }

        internal PointF ReturnThePositionOfCenterOfScreen()
        {
            var displayCompatibility 
                = ScriptSettings
                    .Load(PathToDisplayCompatibilityFile);

            var aspectRatio 
                = Screen
                    .AspectRatio;

            var screenCompatibility 
                = displayCompatibility
                    .GetAllValues<string>(section: "Compatibility",
                                          name   : $"{aspectRatio}")[0];

            var screenCenterPosition 
                = displayCompatibility
                    .GetAllValues<string>(section: screenCompatibility,
                                          name   : "Screen Center Position")[0];

            return _ 
                   = new PointF(x: float
                                    .Parse(screenCenterPosition),
                                y: 0f);
        }
        internal PointF ReturnTheCustomPositionOfCenterOfScreen()
        {
            var positionOfCenterOfScreen 
                = ReturnThePositionOfCenterOfScreen();

            return _
                   = new PointF(x: positionOfCenterOfScreen
                                                       .X,
                                y: 680f);
        }
        
        internal SizeF ReturnTheSizeOfTheDefaultLayoutImage()
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
        internal SizeF ReturnTheCustomSizeOfTheDefaultLayoutImage()
        {
            var sizeOfDefaultLayoutImage
                = ReturnTheSizeOfTheDefaultLayoutImage();

            return _
                   = new SizeF(width: sizeOfDefaultLayoutImage
                                                        .Width / 3f,
                               height: sizeOfDefaultLayoutImage
                                                        .Height / 3f);
            
        }
        
        internal Color ReturnTheColorOfThisSection(string section)
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
