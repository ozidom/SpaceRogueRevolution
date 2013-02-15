using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models
{
    public class KeyBoardGameControl : IGameControl
    {
        //For keyboard the command ID is the keyevnt code
        public string takeAction(Command command)
        {
            string actionText = string.Empty;

            switch (command.ID)
            {
                case 37:
                    actionText = "w";

                    break;
                case 38:
                    actionText = "n";

                    break;
                case 39:
                    actionText = "e";

                    break;
                case 40:
                    actionText = "s";

                    break;
            }

            return actionText;
        }
    }
}