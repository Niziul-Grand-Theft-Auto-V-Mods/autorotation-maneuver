using GTA;

using Autorotation_maneuver.settings;

using Autorotation_maneuver.user_interface.managers;


namespace Autorotation_maneuver.user_interface
{
    internal sealed class HelicopterBladesSpeed : Script
    {
        private Elements _elements;

        public HelicopterBladesSpeed()
        {
            var settings
                = new Settings();

            var interfaceVisibility
                = settings
                    .ReturnTheInterfaceVisibility();

            if (!interfaceVisibility)
                Pause();

            var isToBeDisplayedOnlyInAutorotation
                = settings
                    .ReturnTheInterfaceDisplayBehavior();

            var character
                = Game.Player.Character;

            Tick += (o, e) =>
            {
                if (Game.IsLoading)
                {
                    return;
                }

                var playerIsInVehicleWithRotatingWings
                    = character
                            .IsInHeli;

                if (playerIsInVehicleWithRotatingWings)
                {
                    var currentVehicle
                        = character
                            .CurrentVehicle;

                    if (isToBeDisplayedOnlyInAutorotation
                        &&
                        currentVehicle
                            .IsEngineRunning
                        ||
                        currentVehicle
                            .IsStopped
                        ||
                        !currentVehicle
                            .IsInAir
                        ||
                        character
                            .IsJumpingOutOfVehicle
                        ||
                        character
                            .IsGettingIntoVehicle
                        ||
                        !character
                            .IsSittingInVehicle()
                        )
                    {
                        return;
                    }

                    if (_elements == null)
                        _elements
                                = ReturnTheRequiredElementsForDisplayingTheInterface();

                    _elements
                        .ScaledDraw((currentVehicle.HeliBladesSpeed * 100f)
                                                                        .ToString("N1"));

                    return;
                }

                if (_elements != null)
                    _elements
                            = null;
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