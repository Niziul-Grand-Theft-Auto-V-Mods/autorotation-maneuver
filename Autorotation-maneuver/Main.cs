using Autorotation_maneuver.script;
using Autorotation_maneuver.user_interface;
using GTA;

namespace Autorotation_maneuver
{
    internal sealed class Main : Script
    {
        private Script _autorotationManeuver;

        private Script _helicopterBladesSpeedInterface;

        public Main()
        {
            Interval = 5000;

            Tick    += (o, e) =>
            {
                if (GetIfGameIsLoading())
                {
                    return;
                }
                
                if (GetIfPlayerIsInHelicopter())
                {
                    if (_autorotationManeuver           == null
                        ||
                        _helicopterBladesSpeedInterface == null)
                    {
                        _autorotationManeuver
                            = InstantiateScript<AutorotationManeuver>();

                        _helicopterBladesSpeedInterface
                            = InstantiateScript<HelicopterBladesSpeed>();

                        _autorotationManeuver
                            .Resume();

                        _helicopterBladesSpeedInterface
                            .Resume();
                    }

                    if (!_autorotationManeuver          .IsPaused
                        ||
                        !_helicopterBladesSpeedInterface.IsPaused)
                    {
                        return;
                    }

                    _autorotationManeuver
                        .Resume();

                    _helicopterBladesSpeedInterface
                        .Resume();
                }
                {
                    if (_autorotationManeuver           == null
                        ||
                        _helicopterBladesSpeedInterface == null)
                    {
                        return;
                    }

                    if (_autorotationManeuver          .IsPaused
                        ||
                        _helicopterBladesSpeedInterface.IsPaused)
                    {
                        return;
                    }

                    _autorotationManeuver
                        .Pause();

                    _helicopterBladesSpeedInterface
                        .Pause();
                }
            };

            Aborted += (o, e) =>
            {
                if (_autorotationManeuver           == null
                    ||
                    _helicopterBladesSpeedInterface == null)
                {
                    return;
                }

                _autorotationManeuver
                    .Abort();

                _helicopterBladesSpeedInterface
                    .Abort();
            };

            bool GetIfGameIsLoading()
            {
                return Game.IsLoading;
            }

            bool GetIfPlayerIsInHelicopter()
            {
                return Game.Player.Character.IsInHeli;
            }
        }
    }
}