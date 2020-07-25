using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Models;
using Persistence.Context;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using SIgnalR.Services;
using SIgnalR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace SIgnalR.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            //await Clients.Caller.SendAsync("receiveMessage", new Message { Text = "mikhorish?", FromUser = "kir", To = "hert" });

            await base.OnConnectedAsync();
        }
        //public async Task ChangeStatus(string userName)
        //{

        //    return;
        //}

        public async Task SendMessage(Message msg)
        {
            await Clients.All.SendAsync("receiveMessage", msg);
        }
    }
}
