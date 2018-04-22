using UnityEngine;

namespace Anysma
{
    /// <summary>
    /// Processes commands from the virtual console.
    /// </summary>
    public class CommandProcessor : MonoBehaviour
    {
        private ConsoleOutput console;
        private GameObject playerGameObject;
        private PlayerMovement playerMovement;
        private WeaponSystem playerWeaponSystem;
        private PlayerTurning playerTurning;

        /// <summary>
        /// Get object references.
        /// </summary>
        private void Start()
        {
            console = GetComponent<ConsoleOutput>();
            playerGameObject = GameObject.Find("PlayerShip");
            playerMovement = playerGameObject.GetComponent<PlayerMovement>();
            playerWeaponSystem = playerGameObject.GetComponent<WeaponSystem>();
            playerTurning = playerGameObject.GetComponent<PlayerTurning>();
        }

        /// <summary>
        /// Process the commands given.
        /// </summary>
        /// <param name="command">Commands to process.</param>
        public void Process(string[] command)
        {
            switch (command[0])
            {
                case "h":
                case "help":
                    console.Print("Commands:");
                    console.Print(" 'move' or 'm' Moves your ship by a specified amount.");
                    console.Print(" 'turn' or 't' Turns your ship by a specified amount in a certain direction.");
                    console.Print(" 'fire' or 'f' Fires your ship's weapons.");
                    console.Print(" 'stop' or 's' Stops the ship.");
                    break;

                case "m":
                case "move":
                    // Make sure it has correct amount of arguments
                    if (command.Length > 1)
                    {
                        // Move the player over time
                        int movementTime = 0;
                        if (int.TryParse(command[1], out movementTime))
                        {
                            playerMovement.SetMoveTime(movementTime);
                            console.Print("Moving...");
                        }
                        else
                        {
                            console.Print("Invalid movement value! Usage: 'move 5'");
                        }
                    }
                    else
                    {
                        console.Print("Invalid number of arguments! Usage: 'move 5'");
                    } 
                    break;

                case "t":
                case "turn":
                    // Make sure it has correct amount of arguments
                    if (command.Length > 2)
                    {
                        // Move the player over time
                        int turnTime = 0;
                        int modifier = 0;
                        if (int.TryParse(command[2], out turnTime))
                        {
                            if (command[1].Equals("right") || command[1].Equals("r"))
                            {
                                modifier = -1;
                            }
                            else if (command[1].Equals("left") || command[1].Equals("l"))
                            {
                                modifier = 1;
                            }
                            playerTurning.SetTurnValue(turnTime, modifier);
                            console.Print("Turning...");
                        }
                        else
                        {
                            console.Print("Invalid turning value! Usage: 'turn right 5'");
                        }
                    }
                    else
                    {
                        console.Print("Invalid number of arguments! Usage: 'turn left 7'");
                    }
                    break;

                case "f":
                case "fire":
                    playerWeaponSystem.Fire();
                    console.Print("Firing...");
                    break;

                case "s":
                case "stop":
                    playerMovement.SetMoveTime(0);
                    playerTurning.SetTurnValue(0, 0);
                    console.Print("Stopping...");
                    break;

                default:
                    console.Print("Unkown command entered! Type 'help' for command list.");
                    break;
            }
        }
    }
}
