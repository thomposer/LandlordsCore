﻿using System;
using System.Collections.Generic;
using ETModel;

namespace ETHotfix
{
    [MessageHandler]
    public class Actor_GamerGrabLandlordSelect_NttHandler : AMHandler<Actor_GamerGrabLandlordSelect_Ntt>
    {
        protected override void Run(ETModel.Session session, Actor_GamerGrabLandlordSelect_Ntt message)
        {
            UI uiRoom = Game.Scene.GetComponent<UIComponent>().Get(UIType.LandlordsRoom);
            GamerComponent gamerComponent = uiRoom.GetComponent<GamerComponent>();
            Gamer gamer = gamerComponent.Get(message.UserID);
            if (gamer != null)
            {
                if (gamer.UserID == gamerComponent.LocalGamer.UserID)
                {
                    uiRoom.GetComponent<LandlordsRoomComponent>().Interaction.EndGrab();
                }
                gamer.GetComponent<GamerUIComponent>().SetGrab(message.IsGrab);
            }
        }
    }
}
