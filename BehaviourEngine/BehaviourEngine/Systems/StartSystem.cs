﻿using EngineBuilder;
using System.Collections.Generic;

namespace BehaviourEngine
{
    internal class StartSystem : System<IStartable>
    {
        public override void Update()
        {
            base.Update();

            for (int i = 0; i < items.Count; i++)
            {
                if (!items[i].IsStarted && items[i].Enabled)
                {
                    items[i].Start();
                }
            }
        }
    }
}