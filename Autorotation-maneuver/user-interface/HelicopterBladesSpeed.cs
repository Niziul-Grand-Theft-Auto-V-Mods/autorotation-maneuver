using GTA;

using Autorotation_maneuver.settings;

using Autorotation_maneuver.user_interface.managers;


namespace Autorotation_maneuver.user_interface
{
    internal sealed class HelicopterBladesSpeed : Script
    {
        public HelicopterBladesSpeed()
        {
            var settings
                = new Settings();

            var interfaceVisibility
                = settings
                    .ReturnTheInterfaceVisibility();

            if (!interfaceVisibility)
                Pause();

            var elements 
                = ReturnTheRequiredElementsForDisplayingTheInterface();


            var isInLoading
                = Game
                    .IsLoading;

            Tick += (o, e) =>
            {
                switch (isInLoading)
                {
                    case true:
                        {
                            isInLoading
                            = Game
                                .IsLoading;

                            return;
                        }
                    case false:
                        {
                            var character
                                = Game
                                    .Player
                                        .Character;

                            var playerIsInVehicleWithRotatingWings
                                = character
                                    .IsInHeli;

                            if (playerIsInVehicleWithRotatingWings)
                            {
                                var currentVehicle
                                    = character
                                        .CurrentVehicle;

                                var helicopterBladesSpeed
                                    = currentVehicle
                                        .HeliBladesSpeed;

                                elements
                                    .ScaledDraw((helicopterBladesSpeed * 100f)
                                                                            .ToString("N1"));
                            }
                        }
                        return;
                }
            };
        }

        private Elements ReturnTheRequiredElementsForDisplayingTheInterface()
        {
            var containerElementManager 
                = new ContainerElementManager();

            var customSpriteManager 
                = new CustomSpriteManager();

            var textElementManager 
                = new TextElementManager();


            var containerElement 
                = containerElementManager
                    .ReturnContainerElement();

            var customSprite 
                = customSpriteManager
                    .ReturnCustomSprite();

            var textElement 
                = textElementManager
                    .ReturnTextElement();

            return _
                   = new Elements(customSprite, 
                                  containerElement, 
                                  textElement);
        }
    }
}
