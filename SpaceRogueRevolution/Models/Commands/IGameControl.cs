using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceRogueRevolution.Models
{
    public interface IGameControl
    {
        string takeAction(Command command);
    }
}
