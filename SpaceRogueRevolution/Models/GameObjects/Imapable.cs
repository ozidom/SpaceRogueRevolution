﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRogueRevolution.Models.GameObjects
{
    public interface Imapable
    {
        Tile GetTileForMap();
    }
}